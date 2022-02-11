--Creating table
create table Player(
	playerId int identity(1,1) primary key,
	playerName varchar(50),
	playerGender bit
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
	PP int
);

--Inserting data
update Pokemon
set pokeName = '', pokeLevel = 1, pokeAttack = 1, pokeDefense = 1, pokeHealth = 1
where pokeId = 1