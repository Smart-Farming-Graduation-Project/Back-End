def update_google_sheet(issue_number, issue_title, assignee, assigned_date, closed_at, issue_state, issue_link):
    SPREADSHEET_ID = "17eMiDmtMaqnpfzDzzB5IQyT0rB5udHprYdDlB-W7Krw"  # Replace with your Google Sheet ID
    RANGE_NAME = "Web!A:K"  # Modify this based on your column structure
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
        # Ensure the row has at least 3 columns before accessing row[2]
        if len(row) > 2 and str(row[2]) == str(issue_number):
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
