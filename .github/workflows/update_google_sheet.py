import os
import json
import sys
from google.oauth2.service_account import Credentials
from googleapiclient.discovery import build

# Set up Google Sheets API credentials
def get_sheets_service():
    creds_dict = json.loads(os.getenv('GOOGLE_SHEET_CREDENTIALS'))
    creds = Credentials.from_service_account_info(creds_dict, scopes=["https://www.googleapis.com/auth/spreadsheets"])
    return build('sheets', 'v4', credentials=creds)

# Function to update the Google Sheet
def update_google_sheet(issue_title, issue_body, issue_state):
    SPREADSHEET_ID = "1atfohlYVp6LcswuRapXt6Xf5GJmEH2OXo8mESezyPQc"  # Replace with your Google Sheet ID
    RANGE_NAME = "Sheet1!A:C"  # Replace with your range
    service = get_sheets_service()

    # Data to append
    values = [
        [issue_title, issue_body, issue_state]
    ]

    body = {
        'values': values
    }

    # Call the Sheets API to append data
    result = service.spreadsheets().values().append(
        spreadsheetId=SPREADSHEET_ID,
        range=RANGE_NAME,
        valueInputOption="RAW",
        insertDataOption="INSERT_ROWS",
        body=body
    ).execute()

    print(f'{result.get("updates").get("updatedCells")} cells updated.')

if __name__ == "__main__":
    issue_title = sys.argv[1]
    issue_body = sys.argv[2]
    issue_state = sys.argv[3]
    update_google_sheet(issue_title, issue_body, issue_state)
