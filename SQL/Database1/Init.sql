CREATE DATABASE SaleCakes;
	
USE SaleCakes;

create table Users(
    id uniqueidentifier DEFAULT NEWID(),
	user_role VARCHAR(500),

	CONSTRAINT PK_guid_user PRIMARY KEY (id)
);

create table authorization_user(
	id uniqueidentifier DEFAULT NEWID(),
	user_guid uniqueidentifier references Users(id),
	user_login VARCHAR(500),
	user_password varchar(20),
	createdAt Date,

	CONSTRAINT PK_guid_authorization PRIMARY KEY (id)
);

/*TODO: Employee, Condites,seller?*/

create table order_client(
id uniqueidentifier DEFAULT NEWID(),
order_createdAt Date not null,
order_adress VARCHAR(1000) not null,
order_cake VARCHAR(1000) not null,
order_condites VARCHAR(1000) not null,
order_emoloyee VARCHAR(1000) not null,
order_seller VARCHAR(1000) not null,
 
CONSTRAINT PK_guid_order_client PRIMARY KEY (id)	
);

create table client(
	id uniqueidentifier DEFAULT NEWID(),
	client_name VARCHAR(500) not null,
	client_surname VARCHAR(500) not null,
	client_patronymic VARCHAR(500),
	client_phone varchar(30),
	client_email varchar(500),
	client_orders uniqueidentifier foreign key references order_client(id)

	CONSTRAINT PK_guid_client PRIMARY KEY (id)
);