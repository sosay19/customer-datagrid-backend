-- Create Database
CREATE DATABASE TableManagementDB;
GO


-- Use the database
USE TableManagementDB;


-- Drop the existing table if it exists
IF OBJECT_ID('Corporations', 'U') IS NOT NULL
DROP TABLE Corporations;
-- Create Corporations Table
CREATE TABLE Corporations (
    id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-increment primary key
    name NVARCHAR(100) NOT NULL UNIQUE  -- Unique name for each corporation
);

-- Create Districts Table
CREATE TABLE Districts (
    id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-increment primary key
    name NVARCHAR(100) NOT NULL UNIQUE  -- Unique name for each district
);

-- Create Projects Table
CREATE TABLE Projects (
    id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-increment primary key
    name NVARCHAR(100) NOT NULL,  -- Project name
    corporationId INT NOT NULL,  -- Foreign key referencing Corporations table
    districtId INT NOT NULL,  -- Foreign key referencing Districts table
    FOREIGN KEY (corporationId) REFERENCES Corporations(id),
    FOREIGN KEY (districtId) REFERENCES Districts(id)
);
-- Insert Dummy Data into Projects Table
INSERT INTO Projects (name, corporationId, districtId) VALUES
('Project X', 1, 1),
('Project Y', 2, 2),
('Project Z', 3, 3);

-- Drop the existing table if it exists
IF OBJECT_ID('Records', 'U') IS NOT NULL
DROP TABLE Records;

-- Create Records Table
CREATE TABLE Records (
    id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-increment primary key
    projectId INT NOT NULL,  -- Foreign key referencing Projects table
    DummyCorpName NVARCHAR(100) NOT NULL,  -- Name of the corporation
    DummyDistrictName NVARCHAR(100) NOT NULL,  -- Name of the district
    DummyWorkDone DECIMAL(10, 2) NOT NULL,  -- Work done in meters
    DummyManDays INT NOT NULL,  -- Number of man-days
    DummyManpowerCost DECIMAL(10, 2) NOT NULL,  -- Cost of manpower
    DummyEquipmentCost DECIMAL(10, 2) NOT NULL,  -- Cost of equipment
    DummyTotalCost DECIMAL(10, 2) NOT NULL,  -- Total cost
    FOREIGN KEY (projectId) REFERENCES Projects(id)
);
-- Insert dummy data into Records table
INSERT INTO Records (projectId, DummyCorpName, DummyDistrictName, DummyWorkDone, DummyManDays, DummyManpowerCost, DummyEquipmentCost, DummyTotalCost)
VALUES 
(1, 'Corp A', 'District A', 100.00, 5, 5000.00, 2000.00, 9000.00),
(2, 'Corp B', 'District B', 150.00, 8, 8000.00, 3000.00, 11000.00),
(3, 'Corp C', 'District C', 200.00, 10, 10000.00, 4000.00, 14000.00);


-- Insert Dummy Data into Corporations Table
INSERT INTO Corporations (name) VALUES
('Corp A'),
('Corp B'),
('Corp C');

-- Insert Dummy Data into Districts Table
INSERT INTO Districts (name) VALUES
('District A'),
('District B'),
('District C');







select * from Records;


