# Introduction to SQL
* Structured Query Language
* Just a language made to be really good at storing and querying (grabbing data) information from a database
* Now it isn't really a programming langauge (I know confusing) since it lacks basic tools that a normal programming language has
    * Control flow statements? HA non-existent
    * To re-cap, control flow statements are the for loops and if statements
* It is just a query langauge because it is a language made to get data
* However, down the line, people didn't like this so they created multiple versions of SQL that acts like a proper programming language 
    * Ex: Pl/pgSQL, T-SQL, PL-SQL, etc. (<- you don't need to know the different type of SQL except for T-SQL)
## Database
* It is just an organized collection of data stored in some format
* They allow us to input, manage, organize, and retrieve data quickly
* With most databases, they are organized into tables and each table will have a row and a column
    * Think of a Microsoft Excel sheet
    * Data is the actual intersection between a row and column 
## Rational Database Management System (RDBMS)
* A more advance form of a database with an even fancier name.
* So instead of just storing data like a database, it gives "relationships" between data
    * Look at Multiplicity section to showcase "relationship" between data

## SQL Sublanguages
* Essentially, people decided to organized what each statement (They decided to call it statements instead of functions so... start thinking they are the same thing) does in our RDBMS
## Data Definition Langauge (DDL)
* It is used for the creation/alteration of tables, 
* CREATE - most commonly used to create tables
