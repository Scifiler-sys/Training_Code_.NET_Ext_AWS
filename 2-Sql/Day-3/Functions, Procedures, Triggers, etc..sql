--------------- Our initial setup of Database ---------------

create table role (
	role_id int primary key identity,
	role_title varchar(50),
	role_salary int
)

create table employee (
	employee_id int primary key identity,
	first_name varchar(30),
	last_name varchar(30),
	role_id int references role(role_id)
)

INSERT INTO role
(role_title, role_salary)
VALUES('CEO', 100000),
	('Scientist', 80000),
	('Fry Cook', 50000),
	('Cashier', 27000),
	('Interns', 10000);

INSERT INTO employee
(first_name, last_name, role_id)
VALUES('Eugene', 'Krabs', 1),
	('Spongebob');