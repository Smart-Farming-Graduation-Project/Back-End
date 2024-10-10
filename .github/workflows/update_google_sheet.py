if len(sys.argv) < 10:  # Expecting 9 arguments
    print("Error: Missing arguments. Ensure all required arguments are passed.")
    sys.exit(1)

ID = sys.argv[1]  # Issue number
Task_Name = sys.argv[2]  # Issue title
Assigned_Member = sys.argv[5] or 'Unassigned'  # Assignee login or 'Unassigned'
Assigned_Date = sys.argv[6]  # Created date
Deadline = 'N/A'  # No deadline provided in the workflow
Date_Completed = sys.argv[7] if len(sys.argv) > 7 else 'N/A'  # Closed date
Status = sys.argv[4]  # Issue state (open/closed)
Task_Quality = 5  # Fixed value, no input for task quality
repo_owner = sys.argv[8]  # Repository owner
repo_name = sys.argv[9]  # Repository name

# Construct the GitHub issue URL for comments
Comments = f"https://github.com/{repo_owner}/{repo_name}/issues/{ID}"
