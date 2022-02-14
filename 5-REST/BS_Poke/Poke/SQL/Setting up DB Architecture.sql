--Creating table
create table Player(
	playerId int identity(1,1) primary key,
	playerName varchar(50),
	playerGender bit
);

create table Pokemon (
	pokeId int IDENTITY(1,1) primary key,
	pokeName varchar(50),
	pokeAttack int,
	pokeDefense int,
	pokeHealth int,
	pokeSpeed int
);

CREATE TABLE Ability (
	abId int IDENTITY(1,1) primary key,
	abName varchar(50),
	abPower int,
	abAccuracy int
);

--Creating relationships
create table Team(
	teamId int identity(1,1) primary key,
	pokeId int foreign key references Pokemon(pokeId),
	playerId int foreign key references Ability(abId),
	pokeLevel int
);

create table Arsenal(
	pokeId int foreign key references Pokemon(pokeId),
	abId int foreign key references Ability(abId),
	currentPP int
);

--Inserting data
update Pokemon
set pokeName = '', pokeLevel = 1, pokeAttack = 1, pokeDefense = 1, pokeHealth = 1
where pokeId = 1

INSERT INTO Ability
(abName, abPower, abAccuracy)
VALUES('Tackle', 40, 100),
	('Vine Whip', 45, 100);