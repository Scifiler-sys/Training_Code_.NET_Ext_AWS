---Creating the tables required---
create table Saleman(
	saleId int identity(1,1) primary key,
	saleName varchar(50),
	phoneNumber varchar(50) --phoneNumber depends on SalemanId so we can just put it as a column
);

create table Route(
	-- It is possible to just make the abreviation a primary key since it will be unique based on the PNG
	routeId int identity(1,1) primary key,
	routeAbr varchar(3)
);

create table Product(
	-- It is possible to just make the product Name a primary key since it will be unique based on the PNG
	productId int identity(1,1) primary key,
	productName varchar(50)
);

---Altering tables/creating join tables to establish relationships---
--Many to Many with saleman and routes
create table salemans_routes(
	salemanId int foreign key references Saleman(saleId),
	routeId int foreign key references Route(routeId)
);

--Many to Many with saleman and products
create table salemans_products(
	salemanId int foreign key references Saleman(saleId),
	productId int foreign key references Product(productId)
);

---Adding values into tables---
insert into Saleman 
values ('Bob the Builder','510-BUI-LDIT'),
	('Fred Belotte', '415-HEY-FRED'),
	('Nick Enscalada', '888-GET-COFI'),
	('Pushpinder Kaur', '213-TRA-INER'),
	('Mark "Less is" Moore', '635-SLI-DES!'),
	('Jacob Davis', '415-SEA-HAWK'),
	('Marielle The Martian', '510-FLY-MARS');
	
insert into Route(routeAbr, salemanId)
values('SFO'),
	('LAX'),
	('DFW'),
	('IAH'),
	('SAT'),
	('DAL'),
	('AUS'),
	('TPA'),
	('SEA'),
	('STL'),
	('OAK'),
	('MNL');

insert into Product(productName)
values ('hammer'),
	('nails'),
	('screws'),
	('pizza'),
	('coffee'),
	('espresso'),
	('latte'),
	('cookies'),
	('cakes'),
	('books'),
	('tea'),
	('hot chocolate');

insert into salemans_routes 
values (1,1),
	(1,2),
	(2,3),
	(2,4),
	(2,5),
	(3,6),
	(3,4),
	(3,7),
	(4,8),
	(4,3),
	(4,6),
	(5,3),
	(6,9),
	(6,10),
	(6,4),
	(7,11),
	(7,1),
	(7,12),
	(7,6)

insert into salemans_products 
values (1,1),
	(1,2),
	(1,3),
	(2,4),
	(3,5),
	(3,6),
	(3,7),
	(4,8),
	(4,9),
	(5,10),
	(6,5),
	(7,5),
	(7,11),
	(7,12)

--Querying specific data!--
	
--Select only the product's name from Bob the builder
select p.productName from Saleman s 
inner join salemans_products sp on s.saleId = sp.salemanId
inner join Product p on p.productId = sp.productId 
where s.saleName = 'Bob the Builder'

--Select only the routes from Marielle The Martian
select r.routeAbr from Saleman s 
inner join salemans_routes sr on s.saleId = sr.salemanId 
inner join Route r on r.routeId = sr.routeId 
where s.saleName = 'Marielle the Martian'

--Select every saleman's name that has the route 'DAL'
select s.saleName from Saleman s 
inner join salemans_routes sr on s.saleId = sr.salemanId 
inner join Route r on r.routeId = sr.routeId 
where r.routeAbr = 'DAL'

--Select only the product's name from Nick Enscalada
select p.productName from Saleman s 
inner join salemans_products sp on s.saleId = sp.salemanId 
inner join Product p on p.productId = sp.productId 
where s.saleName = 'Nick Enscalada'

--Select every saleman's name that has both route 'IAH' and product 'coffee'
select s.saleName from Saleman s 
inner join salemans_products sp on s.saleId = sp.salemanId 
inner join Product p on p.productId = sp.productId 
inner join salemans_routes sr on sr.salemanId = s.saleId 
inner join Route r on r.routeId = sr.routeId
where r.routeAbr = 'IAH' and p.productName = 'coffee'