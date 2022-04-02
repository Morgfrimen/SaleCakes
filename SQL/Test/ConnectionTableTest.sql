create table cakeDesign
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	cakeId uniqueidentifier foreign key references cake(id),
	tierId uniqueidentifier foreign key references tiers(id),
);

create table clientDesign
(
	id uniqueidentifier DEFAULT NEWID() PRIMARY KEY (id),
	clientId uniqueidentifier foreign key references client(id),
	orderId uniqueidentifier foreign key references order_client(id),

);