# ACID
* A set of properties of database transaction that is intended to guarantee validity even in the event of catostrophic error or system failures
* Basically, you ensure that your database won't be corrupted if something bad happens

## Transaction
* Think of a method in C# meaning it can run multiple query statements in a single transaction
* They will help prevent data inconsistency because they will either execute all sql statement inside the transaction or not
* Essentially, they will rollback (put everything back the way it was) all the change they did if something bad happens

## Atomicity
* Either all query statements should execute or none of them will
* Meaning all sql statements inside some function/stored procedure/trigger (or just use transaction) should execute all its sql statement or none of them

## Consistency
* There should be a transparent consistency in your database
* Data should be consistent before and after a transaction
* Ex: transferring funds from checking to savings should equal to the total value of funds in both accounts
    * $100 (checking) - $10 (transfer) = $90 (checking) and $10 (savings)
    * $90 (checking) + $10(savings) = $100

## Isolation
* The state of a transaction should be invisible to other transaction
* Can't access the result of other transaction until the transaction completes
### Degrees of isolation
* Read uncommitted - does not protect the transaction from any bad phenomenon
* Read committed (default) - Prevents data from being read by a transaction that is updating it until it finishes committing
    * Prevents Dirty read
* Repeatable read - forces the second transaction to wait for the first transaction to update the data
    * Prevents dirty read and non-repeatable read
* Serializable - Forces the second transaction to wait for insert, delete, update, etc. to be finished from the first transaction
    * Highest degree of isolation and prevents all phenomenons
    * Essentially stops all concurrent transactions from happening
### Different bad phenomenon that occurs during concurrent transaction
* Dirty read - reading data that has not been committed
    * If transaction 1 updated a row followed by transaction 2 reading that updated row and all sudden something went wrong with transaction 1 it will roll back the changes and now transaction 2 had read data that basically never existed
* Non-repeatable read - when data was read twice but comes out different on each time
    * If transaction 1 read a row (it has a value of 5) and transaction 2 updates that row (to be 10) and transaction 1 reads that same row (it has a value of 10) and it came out different than the first read. 
* Phantom read - when data was added or removed by another transaction
    * If transaction 1 finds the average of a column and transaction 2 comes in and add a new number to that column and transaction 1 finds the average of the column again and it'll changed because of that new row that was added 

## Durability
* Once a transation is completed, the changes that it made is permanent in the database
* If there is a system failure, all data is safegaurded (meaning it is still there after the failure)


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