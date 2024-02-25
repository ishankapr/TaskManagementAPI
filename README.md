# Steps to Run

1) Clone backend solution
2) Run the SQL script provided to generate database and tables
3) Make sure change the connection string in the appsettings.json file to relevant server and database name

# TaskManagement

This is the backend application of Task Management application. this has Authentication and Task management related CURD operations

Please use below credentials to login. Those values are hardcoded now since this use simple username and password authentication. You can see those values in AuthService.cs file

<br>

**Username = "testuser1", Password = "testpassword1" <br>
Username = "testuser2", Password = "testpassword2"**

<br>
This can further improve if we can follow JWT authentication, Auth0 or session management techniques and then can use [Authorize] filtering in .net core

# Test 

Unit tests added to check the CURD operations in a separate project. Since it is using in memory databases no need to change any configurations.
