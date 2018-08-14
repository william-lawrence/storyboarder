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

SET IDENTITY_INSERT users ON;
INSERT INTO users(id, username, password, salt, role) VALUES (1, 'billyshakes', 'xgV7qpr1mh3JPEBFpxG2MUo3teA=', '10Ck0gS4oas=', 'role');
SET IDENTITY_INSERT users OFF;

-- Add initial boards data to the database.
SET IDENTITY_INSERT boards ON;
INSERT INTO boards(id, [user_id], title, [description]) VALUES (1, 1,'Hamlet', 'A boy is told by the ghost of his father to kill his uncle.');
INSERT INTO boards (id, [user_id], title, [description]) VALUES (2, 1,'Romeo and Juliet','A love story, but like REALLY sad.');
INSERT INTO boards (id, [user_id], title, [description]) VALUES (3, 1, 'King Lear', 'Something about socialism.');
SET IDENTITY_INSERT boards OFF;

-- Add initial cards data to the database.
SET IDENTITY_INSERT cards ON;
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (1, 1, 1, 'The Ghost Appears', 'The ghost of hamlets dad appears');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (2, 1, 2, 'THE MONOLOGUE', 'To be or not to be.');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (3, 1, 3, 'Ophelia Dies', 'She drowns or something dumb');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (4, 2, 1, 'They Meet', 'Romeo and Juliet meet');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (5, 2, 2, 'They Fall in love', 'like way to fast');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (6, 2, 3, 'They Die', 'A little communication wouldnt hurt.');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (7, 3, 1, 'They decide to kill the king', 'uh oh');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (8, 3, 2, 'They gouge his eyes out', 'eww');
INSERT INTO cards(id, board_id, [number], title, [description]) VALUES (9, 3, 3, 'Only when he is blind can he see', 'ironic.');
SET IDENTITY_INSERT cards OFF;

