
-------------------- Our initial setup of Database -------------------- 
CREATE TABLE roles (
	roles_id serial PRIMARY KEY,
	roles_title varchar(50),
	roles_salary integer
);


CREATE TABLE employees (
	employee_id serial PRIMARY KEY,
	f_name varchar(30),
	l_name varchar(30),
	hire_date date, --Format AS YYYY-MM-DD 
	role_id integer REFERENCES roles(roles_id) --FOREIGN KEY REFERENCES TO the roles TABLE specifically the roles_id column
);

INSERT INTO roles(roles_title, roles_salary)
	VALUES ('CEO', 100000),
			('Scientist', 80000),
			('Fry Cook', 50000),
			('Cashier', 27000),
			('Interns', 10000);
			
INSERT INTO employees (f_name, l_name, hire_date, role_id)
	VALUES ('Eugene', 'Krabs', '1977-10-01', 1),
			('Spongebob', 'Squarepant', '1997-05-12', 3),
			('Sandy', 'Cheeks', '1998-06-12', 2),
			('Squidward', 'Tentacles', '1997-01-10', 4),
			('Sheldon', 'Plankton', '1977-10-01', 2);

-------------------- End of Statement -------------------- 


-------------------- Group By and Having -------------------- 
--They are mosly used with conjucture with aggregate FUNCTIONS 

--Goup By lets us combine records based on equiavlent VALUES 
--We want to group our result based on start date
SELECT hire_date, count(f_name)
FROM employees GROUP BY hire_date;

--Having behaves like where clause, but it is only used for aggregate FUNCTIONS 
SELECT hire_date, count(f_name)
FROM employees GROUP BY hire_date
HAVING count(f_name) > 1;

-------------------- Order BY -------------------- 
--It lets you order your select queries

SELECT f_name, l_name FROM employees
ORDER BY f_name; --ADD DESC (descending) IF you want TO flip the ORDER
--By default it is in ASC (Ascending)

-------------------- User-defined Functions -------------------- 

--A function that will delete spongebob from our employees
CREATE OR REPLACE FUNCTION squidward_kills_spongebob()
RETURNS void
AS 
'delete from employees where f_name = ''Spongebob''; '
LANGUAGE SQL; 

--You can also remove functions using Drop statement
--drop function squidward_kills_spongebob();

SELECT squidward_kills_spongebob();

SELECT * FROM employees

--A function that will add two numbers
CREATE OR REPLACE FUNCTION addTwoNums(num1 integer, num2 integer)
RETURNS integer 
LANGUAGE plpgsql
AS 
$$ --It IS just used TO DEFINED a USER-DEFINED functions
DECLARE
	--Where you put variable declarations
	total integer;
BEGIN
	SELECT (num1+num2)
	INTO total;
	
	RETURN total;
END;
$$

SELECT addTwoNums(8,10);

--A function that will get average and summation of our employee's salary
CREATE OR REPLACE FUNCTION getAvgAndSum(
	OUT avg_salary integer,
	OUT sum_salary integer
)
LANGUAGE plpgsql
AS 
$$
BEGIN 
	SELECT avg(roles_salary), sum(roles_salary)
	INTO avg_salary, sum_salary
	FROM (
		SELECT r.roles_salary FROM employees e
		INNER JOIN roles r ON r.roles_id = e.role_id
	) AS test_table;
END;
$$

SELECT getAvgAndSum(); --Gives you a record OR a whole ROW 
SELECT * FROM getAvgAndSum();

-------------------- Procedure Statements --------------------
CREATE OR REPLACE PROCEDURE procedure_delete_spongebob()
LANGUAGE plpgsql
AS 
$$
	BEGIN 
		DELETE FROM employees WHERE f_name = 'Spongebob';
		
		COMMIT;
	END;
$$

CALL procedure_delete_spongebob();

SELECT * FROM employees

INSERT INTO employees (f_name, l_name, role_id) VALUES ('Spongebob', 'Squarepants', 3);

-------------------- Prepared Statements -------------------- 

--Creates a prepared statement in which you fill in certain portions of your statement (i.e. $variable)
--When you call the prepared statement
PREPARE create_employee
AS
INSERT INTO employees (f_name, l_name, hire_date,role_id)
	VALUES ($1, $2, $3, $4);

EXECUTE create_employee('Spongebob', 'Squarepants', '1997-05-12', 3);

SELECT * FROM employees

--DEALLOCATE create_employee deletes the PREPARED statement

-------------------- Triggers -------------------- 
--They are a special type of function that will run when a certain event happens such as insert, update, or delete queries
--You must create a function first then a trigger

--Function will add everyone's salary if an employee is removed
CREATE OR REPLACE FUNCTION employee_removed()
RETURNS TRIGGER
LANGUAGE plpgsql
AS
$$
	BEGIN
		UPDATE roles SET roles_salary = roles_salary + 10000;
		RETURN null;
	END;
$$

CREATE TRIGGER employee_removed AFTER DELETE ON employees
FOR EACH ROW EXECUTE PROCEDURE employee_removed(); --FOR EACH ROW will EXECUTE the FUNCTION AS many times AS the amount OF ROWS has been updated

SELECT * FROM roles
SELECT * FROM employees
DELETE FROM employees WHERE employee_id = 7

--Function will remove a portion of everyone's salary if an employee is added
CREATE OR REPLACE FUNCTION employee_added()
RETURNS TRIGGER 
LANGUAGE plpgsql
AS 
$$
	BEGIN 
		UPDATE roles SET roles_salary = roles_salary - 10000;
		RETURN NULL;
	END;
$$

CREATE TRIGGER employee_added AFTER INSERT ON employees
FOR EACH ROW EXECUTE PROCEDURE employee_added();

INSERT INTO employees (f_name, l_name, hire_date, role_id) 
	VALUES ('test', 'testl', '1578-10-05', 4)
