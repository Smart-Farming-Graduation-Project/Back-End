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
        Comments            # Comments
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
        body = {
            'values': [row_data]
        }
        service.spreadsheets().values().append(
            spreadsheetId=SPREADSHEET_ID, range=RANGE_NAME,
            valueInputOption="RAW", insertDataOption="INSERT_ROWS", body=body).execute()
        print(f"Task {ID} appended to the sheet.")

if __name__ == "__main__":
    # Read arguments from the command line
    ID = sys.argv[1]
    Task_Name = sys.argv[2]
    Assigned_Member = sys.argv[3]
    Assigned_Date = sys.argv[4]
    Deadline = sys.argv[5]
    Date_Completed = sys.argv[6] or 'N/A'
    Status = sys.argv[7]
    Task_Quality = sys.argv[8]
    Comments = sys.argv[9]

    # Call the function to update or append the Google Sheet
    update_google_sheet(ID, Task_Name, Assigned_Member, Assigned_Date, Deadline, Date_Completed, Status, Task_Quality, Comments)
