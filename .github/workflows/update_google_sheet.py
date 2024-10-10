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

def format_date(iso_date):
    if not iso_date or iso_date == 'N/A':
        return 'N/A'
    try:
        # Parse the ISO date and format it
        parsed_date = datetime.strptime(iso_date, '%Y-%m-%dT%H:%M:%SZ')
        return parsed_date.strftime('%d %b %y')  # Converts to '10 Oct 24'
    except ValueError:
        # Handle invalid date format gracefully
        print(f"Invalid date format: {iso_date}")
        return 'N/A'

    
# Function to map assignee GitHub username to custom names
def custom_assignee_name(assignee):
    if assignee == 'Mohamedzonkol':
        return 'Mohamed Elsayed'
    elif assignee == 'redaelsayed':
        return 'Reda Elsayed'
    # Default case, if no specific mapping is needed
    return assignee


def update_google_sheet(issue_number, issue_title, assignee, assigned_date, closed_at, issue_state, issue_link):
    SPREADSHEET_ID = "17eMiDmtMaqnpfzDzzB5IQyT0rB5udHprYdDlB-W7Krw"  # Replace with your Google Sheet ID
    RANGE_NAME = "Web!A:J"  # Modify this based on your column structure
    service = get_sheets_service()

    # Fetch current data from the sheet
    result = service.spreadsheets().values().get(spreadsheetId=SPREADSHEET_ID, range=RANGE_NAME).execute()
    values = result.get('values', [])

    # Format dates and assignee
    formatted_assigned_date = format_date(assigned_date)
    formatted_closed_at = format_date(closed_at)
    custom_assignee = custom_assignee_name(assignee)
    status = 'Closed' if issue_state == 'closed' else 'Open'

    # Prepare data to insert/update
    row_data = [
        issue_number,               # TaskId
        issue_title,                # Task Name
        custom_assignee,            # Assigned Member
        formatted_assigned_date,    # Assigned Date
        'N/A',                      # Deadline (You can set this manually)
        formatted_closed_at,        # Date Completed
        status,                     # Status
        0,                          # Task Quality (1-5), default to 0
        issue_link                  # Comments (link to issue)
    ]

    # Check if the issue already exists in the sheet
    issue_row = None
    for i, row in enumerate(values, start=1):  # Start from 1 to match Google Sheets row index
        if str(row[1]) == str(issue_number):
            issue_row = i + 1  # Google Sheets is 1-indexed, so add 1 to match

    if issue_row:
        # Update the existing row
        range_to_update = f"Web!A{issue_row}:I{issue_row}"
        body = {
            'values': [row_data]
        }
        service.spreadsheets().values().update(
            spreadsheetId=SPREADSHEET_ID, range=range_to_update,
            valueInputOption="RAW", body=body).execute()
        print(f"Issue {issue_number} updated in row {issue_row}.")
    else:
        # Append new data if the issue does not exist
        body = {
            'values': [row_data]
        }
        service.spreadsheets().values().append(
            spreadsheetId=SPREADSHEET_ID, range=RANGE_NAME,
            valueInputOption="RAW", insertDataOption="INSERT_ROWS", body=body).execute()
        print(f"Issue {issue_number} appended to the sheet.")

if __name__ == "__main__":
    issue_number = sys.argv[1]  # TaskId
    issue_title = sys.argv[2]   # Task Name
    issue_state = sys.argv[3]   # Status (open/closed)
    assignee = sys.argv[4] or 'Unassigned'  # Assigned Member
    assigned_date = sys.argv[5]  # Assigned Date
    closed_at = sys.argv[6] or 'N/A'  # Date Completed
    repo_owner = sys.argv[7]
    repo_name = sys.argv[8]

    # Construct the issue link
    issue_link = f"https://github.com/{repo_owner}/{repo_name}/issues/{issue_number}"

    update_google_sheet(issue_number, issue_title, assignee, assigned_date, closed_at, issue_state, issue_link)

