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
	PP int,
	abPower int,
	abAccuracy int,
	abType varchar(20)
);

--Creating relationships
create table Team(
	teamId int identity(1,1) primary key,
	pokeId int foreign key references Pokemon(pokeId),
	playerId int foreign key references Ability(abId),
	pokeLevel int
);

create table Arsenal(
	teamId int foreign key references Team(teamId),
	abId int foreign key references Ability(abId),
	currentPP int
);


--Inserting data
update Pokemon
set pokeName = '', pokeLevel = 1, pokeAttack = 1, pokeDefense = 1, pokeHealth = 1
where pokeId = 1

INSERT INTO Ability
VALUES('Tackle',35, 40, 100),
	('Vine Whip',40, 45, 100),
	('Scratch',35, 40, 100),
	('Ember', 25, 40, 100),
	('Water Gun', 25, 40, 100),
	('Thunder Shock', 30, 40, 100);