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

CREATE TABLE role(
    role_id INT IDENTITY(1, 1) NOT NULL,
    name VARCHAR(200) NOT NULL,
    org_id INT NOT NULL,
    CONSTRAINT PK_role_id PRIMARY KEY (role_id),
    CONSTRAINT FK_role_org FOREIGN KEY (org_id) REFERENCES organization(org_id)
);
GO

CREATE TABLE user(
    user_id BIGINT IDENTITY(1, 1) NOT NULL,
    name_local_lang NVARCHAR(500) NOT NULL,
    name VARCHAR(500) NOT NULL,
    email  VARCHAR(200) NOT NULL,
    password_hash VARCHAR(200) NOT NULL,
    org_id INT NOT NULL,
    role_id INT NOT NULL,
    CONSTRAINT PK_user_id PRIMARY KEY (user_id),
    CONSTRAINT FK_user_org FOREIGN KEY (org_id) REFERENCES organization(org_id),
    CONSTRAINT FK_user_role FOREIGN KEY (role_id) REFERENCES role(role_id),
);
GO




