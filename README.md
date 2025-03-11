# Enterprise.Manager.WebApi
WebApi developed in NET 6

Clone the public GitHub repository: https://github.com/AndreaSilasAS/Enterprise.Manager.WebApi

Open the solution of the cloned repository in Visual Studio.

Review the connection string in the EnterpriseDbContext class to ensure that the server name where the database was installed is correct. If different, update the connection string accordingly. 

Run the project in debug mode (Swagger will open in a browser window).

Database Setup (SQL Server Required):
Install SQL Server: You will need to have SQL Server installed to follow the setup instructions below. This can be either a full SQL Server

Using SQL Server Management Studio, log in with an administrator account to a SQL Server instance that supports both SQL Server Authentication and Windows Authentication.

If the user EnterpriseManager is not created, create a new SQL Server login with the following credentials:

Username: EnterpriseManager
Password: test
Grant the new user permissions to create databases (e.g., sysadmin permissions).
