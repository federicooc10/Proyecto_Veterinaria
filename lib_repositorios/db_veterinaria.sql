CREATE DATABASE db_veterinaria;
GO
USE db_veterinaria;
GO

CREATE TABLE [Clientes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Documento] INT NOT NULL ,
	[Nombre] NVARCHAR(50) NOT NULL,
);

INSERT INTO [Clientes] ([Documento],[Nombre]) VALUES 
	(1000407371, 'Vale'),
	(1023525415, 'Fede'),
	(42684127, 'Marta'),
	(70844122, 'Oscar'),
	(80001010, 'Stiven'),
	(10222240, 'Daniela')
	;

SELECT * FROM [Clientes];

CREATE TABLE [Veterinarios] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Documento] INT NOT NULL ,
	[Nombre] NVARCHAR(50) NOT NULL,
);

INSERT INTO [Veterinarios] ([Documento],[Nombre]) VALUES 
	(71722937, 'Pedro'),
	(43604052, 'Pablo'),
	(1011401261, 'Javier'),
	(15141312, 'Camila')
	;

SELECT * FROM [Veterinarios];

CREATE TABLE [Razas] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
);

INSERT INTO [Razas] ([Nombre]) VALUES 
	('Bulldog'),
	('Poodle'),
	('Birmano'),
	('Chihuahua'),
	('Bombay'),
	('Pitbull')
	;

SELECT * FROM [Razas];

CREATE TABLE [Medicamentos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
);

INSERT INTO [Medicamentos] ([Nombre]) VALUES 
	('Meloxicam'),
	('Colirio'),
	('Metronid'),
	('Aciflux'),
	('Stomorgyl')
	;

SELECT * FROM [Medicamentos];

CREATE TABLE [Mascotas] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Raza] INT NOT NULL REFERENCES [Razas] ([Id])
);

INSERT INTO [Mascotas] ([Nombre], [Raza]) VALUES 
	('Coco', 1),
	('Funny', 2),
	('Niño', 3),
	('Bruno', 4),
	('Kira', 5),
	('Thanos', 6)
	;

SELECT * FROM [Mascotas];

CREATE TABLE [Formulas] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Codigo] NVARCHAR(50) NOT NULL,
	[Mascota] INT NOT NULL REFERENCES [Mascotas] ([Id])
);

INSERT INTO [Formulas] ([Codigo], [Mascota]) VALUES 
	('A1', 1),
	('B1', 2),
	('C1', 4),
	('D1', 3),
	('E1', 1),
	('F1', 5),
	('G1', 6)
	;

SELECT * FROM [Formulas];

CREATE TABLE [Formulas_Medicamentos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Formula] INT NOT NULL REFERENCES [Formulas] ([Id]),
	[Medicamento] INT NOT NULL REFERENCES [Medicamentos] ([Id]),
	[Cantidad] INT NOT NULL
);

INSERT INTO [Formulas_Medicamentos] ([Formula], [Medicamento], [Cantidad]) VALUES 
	(1, 1, 1),
	(1, 2, 2),
	(2, 1, 1),
	(3, 3, 2),
	(4, 4, 1),
	(5, 5, 3),
	(6, 2, 2),
	(7, 4, 1)
	;

SELECT * FROM [Formulas_Medicamentos];

CREATE TABLE [Historiales_Clinicos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Codigo] NVARCHAR(50) NOT NULL,
    [Fecha] DATETIME NOT NULL,
    [Cliente] INT NOT NULL REFERENCES [Clientes] ([Id]),
	[Formula] INT NOT NULL REFERENCES [Formulas] ([Id]),
	[Veterinario] INT NOT NULL REFERENCES [Veterinarios] ([Id])
);

INSERT INTO [Historiales_Clinicos] ([Codigo],[Fecha],[Cliente],[Formula],[Veterinario]) VALUES 
	('AAA','2001-01-02',1,1,1),
	('BBB','2002-02-04',2,2,2), 
	('CCC','2003-08-06',1,3,3), 
	('DDD','2004-05-02',3,4,3), 
	('AAA','2005-01-02',4,5,2), 
	('EEE','2006-02-02',5,6,4), 
	('FFF','2007-09-03',6,7,4)
	;

SELECT * FROM [Historiales_Clinicos];

CREATE TABLE [Auditorias] (
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Usuario] NVARCHAR (50),
	[Entidad] NVARCHAR (50),
	[Operacion] NVARCHAR (50),
	[Datos] NVARCHAR (250),
	[Fecha] DATETIME 
);

SELECT * FROM [Auditorias];