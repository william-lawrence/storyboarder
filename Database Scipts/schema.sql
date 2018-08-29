-- Switch to the system (aka master) database.
USE master;
GO

-- Delete the Storyboarder database (IF EXISTS)
IF EXISTS(SELECT * FROM sys.databases WHERE name='Storyboarder')
DROP DATABASE Storyboarder;
GO

-- Create a new Storyboarder database.
CREATE DATABASE Storyboarder;
GO

-- Switch to the Storyboarder database.
USE Storyboarder
GO

-- Create Tables
BEGIN TRANSACTION

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	CONSTRAINT pk_users PRIMARY KEY (id)
);

-- Create all the boards
Create TABLE boards (
    id              int             IDENTITY(1,1),
	[user_id]		int				NOT NULL,
    title           VARCHAR(256)    NOT NULL,
    [description]   VARCHAR(512)    NOT NULL,

    CONSTRAINT pk_boards PRIMARY KEY (id),
	CONSTRAINT fk_boards_users FOREIGN KEY ([user_id]) REFERENCES users (id)
);

-- Create all the story cards
CREATE TABLE cards (
    id              int             IDENTITY(1,1),
    board_id        int             NOT NULL,
    [number]        int             NOT NULL,
    title           VARCHAR(256)    NOT NULL,
    [description]   text            NOT NULL,

    CONSTRAINT pk_cards PRIMARY KEY (id),
   CONSTRAINT fk_cards_boards FOREIGN KEY (board_id) REFERENCES boards (id)
);



COMMIT TRANSACTION;
