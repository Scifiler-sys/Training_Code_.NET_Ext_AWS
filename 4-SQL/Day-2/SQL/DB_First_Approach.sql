--Removing our previous table
drop table avengers;

drop table person_course;

drop table finger;

drop table heart;

drop table course;

drop table person;

--Creating our database architecture

create table Restaurant(
	Id int primary key identity, --Identity will auto-increment the column every time you add a new entry
	Name varchar(50),
	City varchar(30),
	State varchar(30)
)

create table Review(
	Id int primary key identity,
	Rating float,
	Desciption varchar(100)
)

--Seeding our database architecture
INSERT INTO Restaurant
(Name, City, State)
VALUES('Mcdonald', 'Houston', 'Texas'),
	('Jack in the Box', 'Reston', 'Virginia'),
	('Taco Bell', 'Dallas','Texas');

INSERT INTO Review
(Rating, Desciption, RestaurantId)
VALUES(4, 'Good', 1),
	(3, 'Meh', 1),
	(5, 'God like', 2);
