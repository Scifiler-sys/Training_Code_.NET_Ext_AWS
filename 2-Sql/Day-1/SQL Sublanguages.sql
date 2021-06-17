--This is a single line comment
/*
    This let us
    have multiple
    line comments
*/

----------------- DDL or Data Definition Language -----------------

--Will create a new table called Avengers
create table avengers (
    superhero_name varchar(30),
    superhero_power varchar(30),
    real_name varchar(30),
    power_level int
);

--Alter statement is changing the table itself by adding a new column
alter table avengers add active bit;

--Can also remove columns
alter table avengers drop column active;

--Deletes the contents of the table
truncate table avengers;

--Drops/Removes the table
drop table avengers;

----------------- DML or Data Manipulation Language -----------------

--Will insert data into a table
insert into avengers(superhero_name, superhero_power, real_name, power_level)
    values ('Capt. America', 'Drugs', 'Steve Rogers', 25),
            ('Spiderman', 'Web', 'Peter Parker', 37);

--Will update either a specific or multiple rows
update avengers set power_level = 30
where power_level < 20;

--Will delete either a specific or multiple rows
delete from avengers 
where real_name = 'Steve Rogers';

insert into avengers (superhero_name, superhero_power, real_name, power_level)
    values ('Ironman', 'Money and knowledge', 'Tony Stark', 85);

----------------- DQL or Data Query Language -----------------

--Will grabe all the data from a table
select * from avengers

--Will grab a specific data from a table
select * from avengers
where superhero_name = 'Ironman';

--Will grab a specific column from a table
select superhero_name, superhero_power from avengers;

--Alias, renames the column of a table
select superhero_name as Name from avengers; --you can also do as "Name with space"

----------------- TCL or Transaction Control Language -----------------

--truncate the table for a clean slate

begin transaction --The start of a transaction in postgres

truncate table avengers; --Cleans the table from previous data

insert into avengers(superhero_name, superhero_power, real_name, power_level)
    values ('Capt. America', 'Super String Frisbee', 'Steve Rogers', 25),
        ('Thor', 'Lightning', 'Thor Odinson', 256);

save transaction my_save; --Saves the current state of the transaction

update avengers set power_level = 30 where real_name = 'Steve Rogers';
update avengers set power_level = 300 where real_name = 'Thor Odinson';

rollback transaction my_save; --rollbacks all the changes to the database back to the savepoint

commit transaction --The end of the transaction

----------------- Aggregate Functions -----------------

--Summation of the entire column
select sum(power_level) from avengers;

--Average
select avg(power_level) from avengers;

--Count
select count(*) from avengers;

--Minimal
select min(power_level) from avengers;

--Maximal
select max(power_level) from avengers;

----------------- Multiplicity -----------------

-- One to One relationship
Create table person (
    SSN integer,
    person_name varchar(30),
    person_age int,

    constraint primary_key primary key (SSN)
)

create table heart(
    
)