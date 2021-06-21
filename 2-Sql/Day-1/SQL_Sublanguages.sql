--This is a single line comment
/*
    This let us
    have multiple
    line comments
*/

----------------- DDL or Data Definition Language -----------------

--Will create a new table called avenger
create table avenger (
    superhero_name varchar(30),
    superhero_power varchar(30),
    real_name varchar(30),
    power_level int
);


--Alter statement is changing the table itself by adding a new column
alter table avenger add active bit;

--Can also remove columns
alter table avenger drop column active;

--Deletes the contents of the table
truncate table avenger;

--Drops/Removes the table
drop table avenger;

----------------- DML or Data Manipulation Language -----------------

--Will insert data into a table (also known as Seeding)
insert into avenger(superhero_name, superhero_power, real_name, power_level)
    values ('Capt. America', 'Drugs', 'Steve Rogers', 25),
            ('Spiderman', 'Web', 'Peter Parker', 37);

--Will update either a specific or multiple rows
update avenger set power_level = 30
where power_level < 20;

--Will delete either a specific or multiple rows
delete from avenger 
where real_name = 'Steve Rogers';

insert into avenger (superhero_name, superhero_power, real_name, power_level)
    values ('Ironman', 'Money and knowledge', 'Tony Stark', 85);

----------------- DQL or Data Query Language -----------------

--Will grabe all the data from a table
select * from avenger

--Will grab a specific data from a table
select * from avenger
where superhero_name = 'Ironman';

--Will grab a specific column from a table
select superhero_name, superhero_power from avenger;

--Alias, renames the column of a table
select superhero_name as Name from avenger; --you can also do as "Name with space"

----------------- TCL or Transaction Control Language -----------------

--truncate the table for a clean slate

begin transaction --The start of a transaction in postgres

truncate table avenger; --Cleans the table from previous data

insert into avenger(superhero_name, superhero_power, real_name, power_level)
    values ('Capt. America', 'Super String Frisbee', 'Steve Rogers', 25),
        ('Thor', 'Lightning', 'Thor Odinson', 256);

save transaction my_save; --Saves the current state of the transaction

update avenger set power_level = 30 where real_name = 'Steve Rogers';
update avenger set power_level = 300 where real_name = 'Thor Odinson';

rollback transaction my_save; --rollbacks all the changes to the database back to the savepoint

commit transaction --The end of the transaction

----------------- Aggregate Functions -----------------

--Summation of the entire column
select sum(power_level) from avenger;

--Average
select avg(power_level) from avenger;

--Count
select count(*) from avenger;

--Minimal
select min(power_level) from avenger;

--Maximal
select max(power_level) from avenger;

----------------- Scalar Functions -----------------

--Will uppercase the string
SELECT upper(superhero_name) FROM avenger
--lower() will lowercase the string

--Will return the number of characters in a string
SELECT superhero_name, len(superhero_name) AS name_length FROM avenger

--You can also use scalar functions in where clause
SELECT superhero_name FROM avenger
WHERE len(superhero_name) > 5

--Time scalar function
SELECT getdate()

----------------- Multiplicity -----------------

-- One to One relationship
Create table person (
    SSN integer,
    person_name varchar(30),
    person_age int,

    constraint primary_key primary key (SSN)
);

create table heart(
    heart_size int,
    healthy bit,
    person int unique, -- Must use unique constraint to make 1 to 1 relationship

    constraint foreign_key foreign key(person) references person(SSN)
);

insert into person(ssn, person_name, person_age) values (1, 'James', 21);
insert into heart(heart_size, healthy, person) values (5, 1, 1);
--insert into heart(heart_size, healthy, person) values (10,0,1); --Will not work because of the unique constraint

--Ont to Many relationship
create table finger (
	finger_length int,
	finger_type varchar(30),
	person int, -- No unique constraint so you can relate as many fingers to a person
	
	constraint finger_foreign_key foreign key (person) references person(ssn)
)

insert into finger(finger_length, finger_type, person)
	values (3, 'Pointy finger', 1),
		(4, 'Middle finger', 1),
		(3, 'Ring finger', 1),
		(2, 'Pinky finger', 1),
		(1, 'Thumb', 1);
		
--Many to Many relationship
create table course(
	course_id int primary key, --Another way to establish a primary key (You cannot name the primary key)
	course_name varchar(30),
	course_type varchar(30)
)

--Join table
create table person_course (
	person_ssn int references person(ssn),
	course_id int references course(course_id)
)

insert into person(ssn, person_name, person_age) values (2, 'Stephen', 25);
insert into course(course_id, course_name, course_type) 
	values (1, 'Sql Course', 'SQL'),
		(2, '.Net Course', 'C#');

--Both Stephen and James will take SQL course but Stephen will also take .Net course
insert into person_course (person_ssn, course_id)
	values (1,1), (2,1), (2,2);
	
----------------- Joins -----------------

select * from person p 
inner join heart h on p.SSN = h.person;

select * from person p 
left join heart h on p.SSN = h.person;

--Someone donated a heart to a hospital
insert into heart(heart_size, healthy, person) values (10, 1, null)

select * from person p 
right join heart h on p.SSN = h.person;

select * from person p 
full join heart h on p.SSN = h.person;

select * from person --Multiply the # of rows from the left table with the # of rows from the right table
cross join heart;

--This is how you inner join many to many relationship
select p.person_name , c.course_name from person p 
inner join person_course pc on pc.person_ssn = p.SSN 
inner join course c on c.course_id = pc.course_id;

----------------- Subqueries -----------------

--Old way
select avg(power_level) from avenger;

select * from avenger
where power_level > 140;

/*
 * Doesn't work because where clause cannot use aggregate functions
 * Select * from avenger
 * where power_level > avg(power_level)
 */

--Subquery way
select * from avenger
where power_level > (
	select avg(power_level) from avenger
);

/*
 * Now with subqueries you can use 
 * in, not in, exists, any, for the important ones
 * https://docs.microsoft.com/en-us/sql/t-sql/language-elements/in-transact-sql?view=sql-server-ver15
 * https://www.w3schools.com/sql/ - Best resource for all things sql
 * /
