---Create statement--
create table Employee(
	empId int identity(1,1) primary key,
	empName varchar(50),
	empSalary smallmoney
);

create table Department(
	depId int identity(1,1) primary key,
	depName varchar(50)
);

--Established relationships--
create table employees_departments(
	empId int foreign key references Employee(empId),
	depId int foreign key references Department(depId)
);

--Inserting values--
insert into Employee 
values('John Doe', 65000),
	('Ollie Abbott', 80000),
	('Emanual Dean', 110000),
	('Ernest Rowe', 55000),
	('Janice Oliver', 66000);

insert into Department
values ('Software Engineer'),
	('Manager');

insert into employees_departments 
values (1,1),
	(2,1),
	(3,2),
	(4,1),
	(5,1);

------ Subquery --------

--I want to take the average of all software engineer's salary
select avg(e.empSalary) as 'Average Software Engineer Salary' from Employee e 
inner join employees_departments ed on e.empId = ed.empId 
inner join Department d on d.depId = ed.depId 
where d.depName = 'Software Engineer';

--I want to select every software engineer that have a higher than average software engineer
--Seems like a very simple question but got really complicated real fast
--With subquery it is just better to run the query first and then copy and paste where required
select e.empName, e.empSalary from Employee e
inner join employees_departments ed on e.empId = ed.empId 
inner join Department d on d.depId = ed.depId 
where d.depName = 'Software Engineer' and e.empSalary > 
(select avg(e.empSalary) from Employee e 
inner join employees_departments ed on e.empId = ed.empId 
inner join Department d on d.depId = ed.depId 
where d.depName = 'Software Engineer');