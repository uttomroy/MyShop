IF DB_ID('my_shop') IS NULL
  CREATE DATABASE my_shop
Go

USE my_shop
GO


CREATE TABLE organization(
	org_id INT IDENTITY(1, 1) NOT NULL,
	name VARCHAR(500) NOT NULL,
	address VARCHAR(500) NOT NULL,
	district VARCHAR(200) NOT NULL,
	country_id INT NOT NULL,
	CONSTRAINT PK_org_id PRIMARY KEY (org_id)
);
GO




