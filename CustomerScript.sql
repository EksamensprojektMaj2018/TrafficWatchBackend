CREATE TABLE Customer ( id INT NOT NULL IDENTITY(1,1), email NVARCHAR NOT NULL, 
firstName NVARCHAR NOT NULL, lastName NVARCHAR NOT NULL, address_id INT, 
alarm_id INT, route_id INT, adminstartor INT NOT NULL, PRIMARY KEY (id))

CREATE TABLE Address (id INT NOT NULL IDENTITY(1,1), 
zip_code int, city NVARCHAR, road NVARCHAR, house_nr INT, 
PRIMARY KEY(id))

CREATE TABLE Alarm ( id INT NOT NULL IDENTITY(1,1), wake_up DATETIME NOT NULL, delay INT, PRIMARY KEY(id))

CREATE TABLE Route ( id INT NOT NULL IDENTITY(1,1), address_id_departure INT, address_id_arrival INT, PRIMARY KEY(id),
CONSTRAINT FK_Departure FOREIGN KEY (address_id_departure) REFERENCES Address(id),
CONSTRAINT FK_Arrival FOREIGN KEY (address_id_arrival) REFERENCES Address(id))

CREATE TABLE CustomerAlarm (customer_id INT, alarm_id INT, 
CONSTRAINT FK_CustomerAlarm FOREIGN KEY (alarm_id) REFERENCES Alarm(id), CONSTRAINT FK_AlarmCustomer FOREIGN KEY (customer_id) REFERENCES Customer(id))

CREATE TABLE AddressCustomer(address_id INT, customer_id INT, 
CONSTRAINT FK_CustomerAddress FOREIGN KEY (customer_id) REFERENCES Customer(id), CONSTRAINT FK_AddressCustomer FOREIGN KEY (address_id) REFERENCES Address(id))
