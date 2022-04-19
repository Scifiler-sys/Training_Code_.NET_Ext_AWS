# Subquery
* When one sql statement is not enough
* It allows you to add a query statement upon a query statement and so on and on...

# Common Table Expression (CTE)
* Creating a temporary table in SQL to do some operations on
* Almost the same as a subquery but it generates a temporary table
* Seems very useless to us (because it is at the moment) but more complex databases that have 30-50 tables can make temporary tables extremely useful to save work and rewriting the same join statement 50 times

# Set Operations
* Special type of join
* It doesn't need to specify what the two tables needs to match on
* It will combine two queries together
    * They need to have the same # of columns and same datatype

## Union
* It will show every value from both queries only once
* Any duplicated values will only display once

## Union All
* It will display every value from both queries including duplicated values

## Except
* It will show only unique values from the right query
* It will not show any duplicated values

## Intersect
* It will show only duplicated values from both queries

# Procedures
* Almost the same as the methods in C# but has certain unique characteristics
* Like a method, it can accept input parameters but it can also output multiple parameters
* Essentially, it can return **multiple datatypes**
* You can also have optional parameters
* Like a method, it is reusable

# Triggers
* They are a special type of procedure that will run when a certain event happens such as insert, update, or delete
* You can specify when you want the trigger to happen such as:
    * After/For - execute trigger after the event
    * Instead of - executes the trigger's operation instead of the event