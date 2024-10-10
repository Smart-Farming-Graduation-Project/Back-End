import os
import json
import sys
from google.oauth2.service_account import Credentials
from googleapiclient.discovery import build

# Set up Google Sheets API credentials
def get_sheets_service():
    creds_dict = json.loads(os.getenv('GOOGLE_SHEETS_CREDENTIALS'))
    creds = Credentials.from_service_account_info(creds_dict, scopes=["https://www.googleapis.com/auth/spreadsheets"])
    return build('sheets', 'v4', credentials=creds)

# Function to update an existing row or append new data if not found
def update_google_sheet(issue_number, issue_title, issue_body, issue_state, assignee, created_at, closed_at):
    SPREADSHEET_ID = "your-spreadsheet-id"  # Replace with your Google Sheet ID
    RANGE_NAME = "Sheet1!A:H"  # Modify this based on your column structure
    service = get_sheets_service()

    # Fetch current data from the sheet
    result = service.spreadsheets().values().get(spreadsheetId=SPREADSHEET_ID, range=RANGE_NAME).execute()
    values = result.get('values', [])

    # Check if the issue already exists in the sheet based on the issue number
    issue_row = None
    for i, row in enumerate(values):
        if row[0] == issue_number:  # Assuming the issue number is in column A
            issue_row = i + 1  # Sheet rows are 1-indexed

    # Prepare data to insert/update
    row_data = [issue_number, issue_title, issue_body, issue_state, assignee, created_at, closed_at]

    if issue_row:
        # Update the existing row
        range_to_update = f"Sheet1!A{issue_row}:G{issue_row}"
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
    issue_number = sys.argv[1]
    issue_title = sys.argv[2]
    issue_body = sys.argv[3]
    issue_state = sys.argv[4]
    assignee = sys.argv[5] or 'Unassigned'
    created_at = sys.argv[6]
    closed_at = sys.argv[7] or 'N/A'

    update_google_sheet(issue_number, issue_title, issue_body, issue_state, assignee, created_at, closed_at)
