# Transaction

# ACID

# Isolation levels

# ADO.NET
* Another library (that already exists in our .NET 6 framework) that specializes in connecting to different types of databases/data sources to do CRUD operations on
    * CRUD - create/read/update/delete data on the database
* It provides helpful classes that handles the connection, execution, and reading of the data from a database
* We used System.Data.SqlClient external package to specify we are specifically connecting to a SQL Server database
    * This package will change if you change the engine of your database

## SqlConnection (Can also be named as just Connection)
* A class that is used to establish a connection to a Sql Server database
* You can think of the SqlConnection object as a representation of an existing connection to a database
* The very first step required to start messing with a database

## SqlCommand (Can also be named as just Command)
* A class that is used to execute SQL statements to a SQL Server database
* You can think of the SqlCommand object as a representation of the query statement you want to execute

## SqlDataReader (Can also be name as just DataReader)
* A class that is used to read what is exactly given to you when you execute a SQL statement
* Since C# only understands classes and objects while SQL only understands tables, this class is the middle man that will provide the conversion tools required to convert SQL datatypes to C# datatypes
* You still have to map things manually but at least you can grab the data and convert it into datatypes that C# understands
### DataSet
* This is the actual model that SQLDataReader uses to grab a "table" in C#
* You can think of it as a representation of a table in SQL but in C#

## SqlDataAdapter
* A class that we don't need to use (mostly because the other classes I stated above already uses this class to do their operations) but it is the actual class that stores information in a DataSet after grabbing information from a database
* Essentially it is the translator that converts SQL table into C# object (which is the DataSet)

# Architecture of ADO.NET
* Ha! I scared you there for a second, no we don't need to know another architecture and how they structured and make ADO.net work
* Instead, we just need to know the two types of architecture and what's their difference
## Connected Architecture
* Your application has a constant connection to a database
    * At its core that is really all this means
* As a programmer, that means utilizing SqlConnection class so we are doing connected architecture
    * Remember .Open() method? Yeah that means we have an active connection
## Disconnected Architecture
* Your application only establishes a connection if it needs something with the database
* As a programmer, you need to utilize SqlDataAdapter class instead 
    * Feel free to look up what that code looks like but we don't need to apply it