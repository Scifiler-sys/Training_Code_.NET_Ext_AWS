--Removing our previous table
drop table avengers;

drop table person_course;

drop table finger;

drop table heart;

drop table course;

drop table person;

--Creating our database architecture

create table Restaurant(
	Id int primary key identity,
	Name varchar(50),
	City varchar(30),
	State varchar(30)
)

create table Review(
	Id int primary key identity,
	Rating float,
	Desciption varchar(100)
)