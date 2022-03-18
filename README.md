# Assignment3 (CREATE A WEB API)

.net core Web API project
1) This API is created using Visual Studio 2022 and NetFramework 6.03
2) For the DataBase SQL Server Management Studio v.15 is used,  this is constructed in ASP.NET Core through EFCore with a RESTful API to allow users to Manipulate Data

# SETUP DATABASE AND SEED DATA - CODE FIRST
In order To create and Setup the data base EF core is used against DB. 
1) Adjust Connection String to propper settings (Application Settings.json)
2) Run "update-database DB" in the Package Management Console(includes seeding data) .
3) 3 Tables are created for Movies , Characters and Franchise
4) The relationship between tables are stablish. M2M between Movies and Characters. OneToMany for Franchise to Movies.
5) Some dummy data is seeded

# WEBAPI using ASP.NET
1) Generic CRUD is created for all the entities
2) Data Transfer Objects are created for all the Models 
3) AUTO MAP is used between entities and DTOs.
4) Swagger is used for documentation
5) Additional reporting and updating 
