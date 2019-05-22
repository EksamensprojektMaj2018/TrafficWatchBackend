CREATE TABLE [dbo].[Customer] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [email]         NVARCHAR (50) NOT NULL,
    [firstName]     NVARCHAR (50) NOT NULL,
    [lastName]      NVARCHAR (50) NOT NULL,
	[addressId] INT,
	[routeId] INT,
	[alarmId] INT, 
	CONSTRAINT [FK_customer_address_id] FOREIGN KEY ([addressId]) REFERENCES [dbo].[Address] ([id]),
	CONSTRAINT [FK_customer_route_id] FOREIGN KEY ([routeId]) REFERENCES [dbo].[Route] ([id]),
	CONSTRAINT [FK_customer_alarm_id] FOREIGN KEY ([alarmId]) REFERENCES [dbo].[Alarm] ([id]),
    [administrator] BIT           NULL,
	PRIMARY KEY (id)

CREATE TABLE [dbo].[Address] (
    [id]       INT          IDENTITY (1, 1) NOT NULL,
    [zip_code] INT           NULL,
    [city]     NVARCHAR (50) NULL,
    [road]     NVARCHAR (50) NULL,
    [house_nr] INT           NULL,
	[customer_id] INT NOT NULL,
	CONSTRAINT [FK_CustomerAddress] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]),
    PRIMARY KEY (id)
 	
CREATE TABLE [dbo].[Alarm] (
    [id]      INT      IDENTITY (1, 1) NOT NULL,
    [wake_up] DATETIME NOT NULL,
    [delay]   INT      NULL,
	[customer_id] INT NOT NULL,
	CONSTRAINT [FK_CustomerAlarm] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]),
    PRIMARY KEY([id])

CREATE TABLE [dbo].[Route] (
    [id]                   INT IDENTITY (1, 1) NOT NULL,
    [address_id_departure] INT NULL,
    [address_id_arrival]   INT NULL,
	[customer_id] INT NOT NULL,
	CONSTRAINT [FK_CustomerRoute] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]),
    CONSTRAINT [FK_Departure] FOREIGN KEY ([address_id_departure]) REFERENCES [dbo].[Address] ([id]),
    CONSTRAINT [FK_Arrival] FOREIGN KEY ([address_id_arrival]) REFERENCES [dbo].[Address] ([id]),
	PRIMARY KEY ([id])
