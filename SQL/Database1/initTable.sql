create table app_users
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	user_role VARCHAR(500)
);

create table authorization_user
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	user_guid uniqueidentifier references app_users(id),
	user_login VARCHAR(500),
	user_password varchar(20),
	createdAt Date
);

CREATE TABLE cake
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	weight DECIMAL(18,2) not null,
	tier int not null DEFAULT 1,

);

CREATE TABLE stuffing
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	name VARCHAR(500) not null,
	price VARCHAR(500) not null
);

CREATE TABLE decor
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	name VARCHAR(500) not null,
	price VARCHAR(500) not null
);

create table order_client
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	order_createdAt Date not null,
	order_adress VARCHAR(1000) not null,
	order_cake uniqueidentifier foreign key references cake(id),
	order_condites uniqueidentifier foreign key references authorization_user(id),
	order_emoloyee uniqueidentifier foreign key references authorization_user(id),
	order_seller VARCHAR(1000) not null
);

create table client
(
	id uniqueidentifier DEFAULT NEWID()  PRIMARY KEY (id),
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
	employee_phone varchar(30) not null,
	employee_email varchar(500) not null
);