# .NET NHhibernate app
Test console application to work NHibernate framework with PostgreSQL db.

1) DBScript.sql should be run in PostgreSQL database to create new database and import data;<br/>
2) Set connection string to PostgreSQL database (first string in Main method in Program.cs of PB_NHibernateTestApp application);<br/>

Console application shows the following opportunities work NHibernate framework with PostgreSQL db (based on PBNHibernate_test db):<br/>
1. Create a new company (with departments list) - one-to-many relationship;<br/>
2. Update the company (with departments list) - one-to-many relationship;<br/>
3. Insert a new department (with duties list) - many-to-many relationship;<br/>
4. Insert a new duty (with department list) - many-to-many relationship;<br/>
5. Update the department (and adding new duty) - many-to-many relationship.<br/>
