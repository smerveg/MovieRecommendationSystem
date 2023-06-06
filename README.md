It is a N-tier .NET MVC project.
TMDB API is used as movie database.
MSSQL  is used as database.
Code-First approach is used.
Fluent validation is used for validation. 
AutoMapper is used for mapping. 
Role-based authorization is used.

System is developed for 2 different roles.

1) Admin can access every page in the system. It has permission to change the user status.
Also Admin can load the movie language and genre from the configuration page. 
In this process, system retrives the movie language and genre data from the api then insert them to the database. 
(Before run the system, admin must be registered the system as a user. Then the role id and role code must be changed.(role id=0, role code="A") )
2) Users can get recommendations according to filters, access the lists. If user registers the system, user can add comment to the movies. 
