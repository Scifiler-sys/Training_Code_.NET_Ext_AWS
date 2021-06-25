------------------- Database Architecture -------------------
create table Saleman(
	SalemanId int primary key identity,
	SalemanName varchar(80),
	phoneNumber varchar(12)
);

create table Route(
	RouteName varchar(30) primary key
);

create table Product(
	ProductName varchar(30) primary key
);

create table NamesRoutes(
	SalemanId int references Saleman(SalemanId),
	RouteName varchar(30) references Route(RouteName)
);

create table NamesProducts(
	SalemanId int references Saleman(SalemanId),
	ProductName varchar(30) references Product(ProductName)
);

------------------- Seeding -------------------

--Saleman
insert into Saleman(SalemanName, phoneNumber)
	values ('Bob The Builder', '510-BUI-LDIT'),
		('Fred Belotte', '415-HEY-FRED'),
		('Nick Enscalada','88-GET-COFI'),
		('Pushpinder Kaur', '213-TRA-INER'),
		('Mark "Less is" Moore', '635-SLI-DES!'),
		('Jacob Davis','415-SEA-HAWK'),
		('Stephen Pagdilao', '586-PLS-TEXT');

--Route
insert into Route(RouteName)
	values('SFO'), ('LAX'),
		('DFW'), ('IAH'),
		('SAT'), ('DAL'),
		('AUS'), ('TPA'),
		('SEA'), ('STL'),
		('OAK'), ('MNL');
		
--Product
insert into Product(ProductName)
	values('hammer'), ('nails'),
		('screws'), ('pizza'),
		('coffee'), ('espresso'),
		('latte'), ('cookies'),
		('cakes'), ('books'),
		('tea'), ('hot chocolate');
		
--Name and Route join table
insert into NamesRoutes(SalemanId, RouteName)
	values(1, 'SFO'), (1, 'LAX'),
		(2, 'DFW'), (2, 'IAH'), (2, 'SAT'),
		(3, 'DAL'), (3,'IAH'), (3, 'AUS'),
		(4, 'TPA'), (4, 'DFW'), (4, 'DAL'),
		(5, 'DFW'),
		(6, 'SEA'), (6, 'STL'), (6, 'IAH'),
		(7, 'OAK'), (7,'SFO'), (7, 'MNL'), (7, 'DAL');

--Select statement to see if our relationships are working
select s.SalemanName, r.RouteName from Saleman s 
inner join NamesRoutes nr on s.SalemanId = nr.SalemanId 
inner join Route r on r.RouteName = nr.RouteName;

--Name and Product join table
insert into NamesProducts(SalemanId, ProductName)
	values(1, 'hammer'), (1,'nails'), (1,'screws'),
		(2,'pizza'),
		(3,'coffee'), (3,'espresso'), (3,'latte'),
		(4,'cookies'), (4,'cakes'),
		(5,'books'),
		(6,'coffee'),
		(7,'coffee'), (7,'tea'), (7,'hot chocolate');

--Select statement to see if our relationships are working
select s.SalemanName, p.ProductName from Saleman s 
inner join NamesProducts np on s.SalemanId = np.SalemanId 
inner join Product p on p.ProductName = np.ProductName;