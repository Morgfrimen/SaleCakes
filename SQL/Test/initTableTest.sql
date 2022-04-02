create table app_users
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	user_role VARCHAR(500) unique
);

create table authorization_user
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	user_guid uniqueidentifier references app_users(id),
	user_login VARCHAR(500) unique not null ,
	user_password varchar(20) not null,
	createdAt Date
);

CREATE TABLE shortcake
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	name VARCHAR(500) unique not null,
	price DECIMAL(18,2) not null
);


CREATE TABLE decor
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	name VARCHAR(500) unique not null,
	price DECIMAL(18,2) not null
);

CREATE TABLE stuffing
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	name VARCHAR(500) unique not null,
	price DECIMAL(18,2) not null
);

CREATE TABLE tiers
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	stuffing uniqueidentifier foreign key references stuffing(id),
	decor uniqueidentifier foreign key references decor(id),
	shortcake uniqueidentifier foreign key references shortcake(id)
);

CREATE TABLE cake
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	weight DECIMAL(18,2) not null,
	name varchar(500) unique not null,
);

create table order_client
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	order_createdAt Date not null,
	order_adress VARCHAR(1000) not null,
	order_cake uniqueidentifier foreign key references cake(id),
	order_condites uniqueidentifier foreign key references authorization_user(id),
	order_emoloyee uniqueidentifier foreign key references authorization_user(id),
	order_seller DECIMAL(18,2) not null
);

create table client
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	client_name VARCHAR(500) not null,
	client_surname VARCHAR(500) not null,
	client_patronymic VARCHAR(500),
	client_phone varchar(30),
	client_email varchar(500),
	client_orders uniqueidentifier foreign key references order_client(id)
);

create table employee
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	autorized_data uniqueidentifier unique FOREIGN KEY REFERENCES authorization_user(id),
	employee_name VARCHAR(500) not null,
	employee_surname VARCHAR(500) not null,
	employee_patronymic VARCHAR(500),
	employee_phone varchar(30) unique not null,
	employee_email varchar(500) unique not null,
	isWork bit not null
);