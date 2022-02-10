# Moar Design Patterns
* Because we have 99 problems with coding but design patterns won't be one
## Repository Design Pattern
* When your application has a layer between your actual application and your database using interface or abstraction for accessing the database directly
    * We already implemented it and it is our Data Layer project
* Essentially, we have a middle man between your app and the database that has a sole responsiblity of anything data accessing to the database
* Since we use abstraction, nothing will "break" when updating just your data layer and you can use as many C# files that can tap to multiple data source, tables, etc.
## Unit of Work Design Pattern
* For the most part, your repository should only have simple CRUD operations that messes with the database
* Any "complex" operations that require more than one CRUD operations from the repository should be handled in the Unit of Work layer (our BL)
* This is another layer that is before your application and it's sole responsiblility is to act like a **transaction**
    * Meaning it either executes all of the query statements or none at all
* A design pattern that follows the Atomicity property to prevent **Data inconsistency**

# Mocking
* An important aspect of unit testing as your classes become more complex
* Essentially, when you unit test a single class you have to make sure that any problem that arises, it is solely because of that class fault
    * Unfortunately, this isn't the case when a class starts to depend on another class to even work
* Introduce Mocking, we make it so we imitate any dependencies that class have in order to guarantee they will always work. In this way, if your unit tests fails it because of the class itself and nothing else
* We use the Moq external package to imitate our dependencies and for our example, we made them gaurantee to always return something (in this way the mock object will always work)

# Things I didn't go over but QC might ask
* Main reason I didn't go over it because using it can lead to so many data inconsistency if used improperly
## Cascading delete
* You know how deleting information from a table can lead to an error if that data is being referenced by another table
* Well adding cascading delete will essentially ignore that safety net and delete it anyway and any data that referenced to it will be replaced with a NULL value instead
* Rarely used because it can lead to massive amount of **data inconsistency**
* Ex:
    Imagine a scenario of 50 tables all referencing one table. You did cascading delete operation and now all those 50 tables have NULL values and trying to clean your database will be a massive hassle. 
* It is possible to also just delete the row instead of putting NULL values but then that leads to massive lose of information so... lose lose situation either way
## Indexing
* Didn't go over because it is also not relevant in our case but really useful when your database have 50 tables
* It is just a way to query data really fast from the database by... cheating almost
* Basically, it will take the most commonly done query statements in your database and just save that query result
    * So instead of doing the operation, it just gives you the result right away because sql already have it stored
* Biggest con about it is just memory space since you are saving the information and that can get ridiculously big 
    * Sometimes double the size of the table