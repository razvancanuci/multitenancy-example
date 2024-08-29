# multitenancy-example

This is a basic example of a multitenancy application which is created in C#.
There is a common database which stores all the users' data and one database per each organization registered in the system.
User has an organization assigned to see which database he's allowed to access.
App was created in ASP.NET using EntityFrameworkCore and Identity.EntityFrameworkCore with PostgreSQL.
