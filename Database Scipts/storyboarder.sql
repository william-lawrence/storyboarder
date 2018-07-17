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

Create TABLE board (
    id              int             IDENTITY(1,1),
    title           VARCHAR(256)    NOT NULL,
    author_first    VARCHAR(64)     NOT NULL,
    author_last     VARCHAR(64)     NOT NULL,
    description     VARCHAR(512)    NOT NULL,

    CONSTRAINT pk_boards PRIMARY KEY (id)
);

COMMIT TRANSACTION;

SET IDENTITY_INSERT board ON;
INSERT INTO board (id, title, author_first, author_last, description) VALUES (1, 'Hamlet', 'William', 'Shakespeare','A boy is told by the ghost of his father to kill his uncle.');
INSERT INTO board (id, title, author_first, author_last, description) VALUES (1, 'Romeo and Juliet', 'William', 'Shakespeare','A love story, but like REALLY sad.');
INSERT INTO board (id, title, author_first, author_last, description) VALUES (1, 'King Lear', 'William', 'Shakespeare', 'Something about socialism.');
SET IDENTITY_INSERT board OFF;
