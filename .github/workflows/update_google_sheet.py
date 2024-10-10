import os
import json
import sys
from datetime import datetime
from google.oauth2.service_account import Credentials
from googleapiclient.discovery import build

# Set up Google Sheets API credentials
def get_sheets_service():
    creds_dict = json.loads(os.getenv('GOOGLE_SHEETS_CREDENTIALS'))
    creds = Credentials.from_service_account_info(creds_dict, scopes=["https://www.googleapis.com/auth/spreadsheets"])
    return build('sheets', 'v4', credentials=creds)

# Function to format ISO date to "10 Oct 24"
def format_date(iso_date):
    if not iso_date or iso_date == 'N/A':
        return 'N/A'
    parsed_date = datetime.strptime(iso_date, '%Y-%m-%dT%H:%M:%SZ')
    return parsed_date.strftime('%d %b %y')


# Function to map assignee GitHub username to custom names
def custom_assignee_name(assignee):
    if assignee == 'Mohamedzonkol':
        return 'Zonkol'
    elif assignee == 'redaelsayed':
        return 'reda'
    return assignee
# Function to handle assignee, fall back to 'Unassigned' if empty
def custom_assignee(assignee):
    if assignee == 'Mohamedzonkol':
        return 'Mohamed Elsayed'
    elif assignee == 'redaelsayed':
        return 'reda'
    return assignee
# Function to set the deadline to 2 days from assigned date by default
def get_default_deadline(assigned_date):
    if assigned_date == 'N/A':
        return 'N/A'
    parsed_date = datetime.strptime(assigned_date, '%Y-%m-%dT%H:%M:%SZ')
    deadline = parsed_date + timedelta(days=2)
    return deadline.strftime('%d %b %y')
# Function to handle task state, "open" becomes "in progress" and "closed" becomes "done"
def custom_status(status):
    if status.lower() == 'open':
        return 'In Progress'
    elif status.lower() == 'closed':
        return 'Done'
    return status  # Return as is if the status is something else
# Function to update an existing row or append new data if not found
def update_google_sheet(ID, Task_Name, Assigned_Member, Assigned_Date, Deadline, Date_Completed, Status, Task_Quality, Comments):
    SPREADSHEET_ID = "17eMiDmtMaqnpfzDzzB5IQyT0rB5udHprYdDlB-W7Krw"  # Replace with your Google Sheet ID
    RANGE_NAME = "Web!A:I"  
    service = get_sheets_service()

    # Fetch current data from the sheet
    result = service.spreadsheets().values().get(spreadsheetId=SPREADSHEET_ID, range=RANGE_NAME).execute()
    values = result.get('values', [])

    # Check if the task ID already exists in the sheet
    task_row = None
    for i, row in enumerate(values):
        if len(row) > 0 and row[0] == ID:  # Ensure the row has content before checking
            task_row = i + 1  # Google Sheets rows are 1-indexed

    # Prepare data to insert/update
    row_data = [
        ID,                 # Task ID
        Task_Name,          # Task Name
        Assigned_Member,    # Assigned Member
        Assigned_Date,      # Assigned Date
        Deadline,           # Deadline
        Date_Completed,     # Date Completed
        Status,             # Task Status (Open/Closed)
        Task_Quality,       # Task Quality (if applicable)
        Comments            # Comments (GitHub URL)
    ]

    if task_row:
        # Update the existing row
        range_to_update = f"Web!A{task_row}:I{task_row}"
        body = {
            'values': [row_data]
        }
        service.spreadsheets().values().update(
            spreadsheetId=SPREADSHEET_ID, range=range_to_update,
            valueInputOption="RAW", body=body).execute()
        print(f"Task {ID} updated in row {task_row}.")
    else:
        # Append new data if the task does not exist
        append_range = f"Web!A{len(values) + 1}:I{len(values) + 1}"  # Get the next available row
        body = {
            'values': [row_data]
        }
        service.spreadsheets().values().append(
            spreadsheetId=SPREADSHEET_ID, range=append_range,
            valueInputOption="RAW", insertDataOption="INSERT_ROWS", body=body).execute()
        print(f"Task {ID} appended to the sheet.")

if __name__ == "__main__":
    # Check if enough arguments are provided
    if len(sys.argv) < 10:  # Expecting 9 arguments
        print("Error: Missing arguments. Ensure all required arguments are passed.")
        sys.exit(1)

    ID = sys.argv[1]  # Issue number
    Task_Name = sys.argv[2]  # Issue title
    Assigned_Member = custom_assignee(sys.argv[5]) or 'Unassigned'  # Use the custom assignee function
    Assigned_Date = format_date(sys.argv[6])  # Use the format_date function
    Deadline = get_default_deadline(sys.argv[6])
    Date_Completed = format_date(sys.argv[7]) if len(sys.argv) > 7 else 'N/A'  # Use format_date for completed date
    Status =  custom_status(sys.argv[4])
    Task_Quality = 5  # Fixed value, no input for task quality
    repo_owner = sys.argv[8]  # Repository owner
    repo_name = sys.argv[9]  # Repository name

    # Construct the GitHub issue URL for comments
    Comments = f"https://github.com/{repo_owner}/{repo_name}/issues/{ID}"

    # Call the function to update or append the Google Sheet
    update_google_sheet(ID, Task_Name, Assigned_Member, Assigned_Date, Deadline, Date_Completed, Status, Task_Quality, Comments)
