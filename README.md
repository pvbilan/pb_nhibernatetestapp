# .NET app with NHibernate
The test console application to work NHibernate framework with PostgreSQL db.

1) DBScript.sql should be run in PostgreSQL database to create the new database and import data;<br/>
2) Set connection string to PostgreSQL database (first record in Main method in Program.cs of PB_NHibernateTestApp application);<br/>

The console application shows the following opportunities work NHibernate framework with PostgreSQL db (based on PBNHibernate_test db):<br/>
1. Create a new company (with departments list) - one-to-many relationship;<br/>
2. Update a company (with departments list) - one-to-many relationship;<br/>
3. Insert a new department (with duties list) - many-to-many relationship;<br/>
4. Insert a new duty (with department list) - many-to-many relationship;<br/>
5. Update a department (and adding new duty) - many-to-many relationship;<br/>
6. Get departments count of companies - group by and count;<br/>
7. Get companies, which departments count greater than 2 - group by with conditions, NHiberante Future opportunities.<br/>
