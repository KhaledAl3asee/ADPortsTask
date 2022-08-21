# ADPortsTask
ADPorts Assessment

1.	Frontend (using Angular 13.3.2) only login is working using jwt token 
2.	Backend service (using .NET core 5)full crud (authenticated and authorized)  using repository pattern ,error handling , dtos
3.	Database (MSSQL 2017)
4.	JWT authentication
5.	API gateway
6. docker files provided.
7. signalR configured in startup.cs file only , not publishin notifications





Running Steps :
1- Open the project using visual studio community 2019+
2- delete current migration folder 
3- open nugget package manager console 
  - add-migration
  - update-database 
4- now you are all set our database migrated to our MSSql Server , just run 


Postman 
url (set method to post)                                                                               :http://localhost:5000/api/auth/login 
url (set method to get :kindly provide the access token (bearer)that you got from the former link )http://localhost:5000/api/Employee/1
url (set method to delete , provide id as param)http://localhost:5000/api/Employee/1
url (set method to delete , provide id and title(employee name)as param )http://localhost:5000/api/Employee/1





