CREATE TABLE Customer (id INT NOT NULL IDENTITY(1,1), email NVARCHAR(50) NOT NULL, first_name NVARCHAR(50) NOT NULL, last_name NVARCHAR(50) NOT NULL,
address_id INT, route_id INT, alarm_id INT, administrator BIT, PRIMARY KEY(id))

CREATE TABLE Address (id INT NOT NULL IDENTITY(1,1), zip_code INT, city NVARCHAR(50), road NVARCHAR(50), house_nr INT, customer_id INT NOT NULL, PRIMARY KEY(id))

CREATE TABLE Alarm (id INT NOT NULL IDENTITY(1,1), wake_up DATETIME NOT NULL, delay INT, customer_id INT NOT NULL, PRIMARY KEY (id))

CREATE TABLE Route (id INT NOT NULL IDENTITY(1,1), address_id_departure INT, address_id_arrival INT, customer_id INT NOT NULL, PRIMARY KEY(id))