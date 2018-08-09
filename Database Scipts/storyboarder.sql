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

-- Create all the boards
Create TABLE boards (
    id              int             IDENTITY(1,1),
    title           VARCHAR(256)    NOT NULL,
    author_first    VARCHAR(64)     NOT NULL,
    author_last     VARCHAR(64)     NOT NULL,
    [description]   VARCHAR(512)    NOT NULL,

    CONSTRAINT pk_boards PRIMARY KEY (id)
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

-- Add initial boards data to the database.
SET IDENTITY_INSERT boards ON;
INSERT INTO boards(id, title, author_first, author_last, [description]) VALUES (1, 'Hamlet', 'William', 'Shakespeare','A boy is told by the ghost of his father to kill his uncle.');
INSERT INTO boards (id, title, author_first, author_last, [description]) VALUES (2, 'Romeo and Juliet', 'William', 'Shakespeare','A love story, but like REALLY sad.');
INSERT INTO boards (id, title, author_first, author_last, [description]) VALUES (3, 'King Lear', 'William', 'Shakespeare', 'Something about socialism.');
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