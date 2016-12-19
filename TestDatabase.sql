create database Test
go

USE Test
GO

CREATE TABLE Curso (
	IdCurso INT NOT NULL identity(1, 1) PRIMARY KEY
	,Descripcion VARCHAR(250) NOT NULL
	)
GO

CREATE TABLE Alumno (
	IdAlumno INT NOT NULL identity(1, 1) PRIMARY KEY
	,Dni CHAR(8) NOT NULL UNIQUE
	,Nombre VARCHAR(250) NOT NULL
	,Apellido VARCHAR(250) NOT NULL
	,Edad INT NOT NULL
	,Promedio DECIMAL NOT NULL
	,FechaRegistro DATETIME
	,FechaModificacion DATETIME
	,IdCurso INT
	)
GO

ALTER TABLE Alumno ADD CONSTRAINT fk_alumno_curso FOREIGN KEY (IdCurso) REFERENCES Curso (IdCurso)
GO

CREATE PROC usp_Alumno_list
AS
BEGIN
	SELECT a.IdAlumno
		,a.Dni
		,a.Nombre
		,A.Edad
		,a.Promedio
		,a.Apellido
		,a.FechaRegistro
		,a.FechaModificacion
		,c.Descripcion
	FROM Alumno a
	INNER JOIN Curso c ON c.IdCurso = a.IdCurso
	WHERE 1 = 1
	ORDER BY a.IdAlumno DESC
END
GO

CREATE PROC usp_Alumno_get @idAlumno INT = NULL
AS
BEGIN
	SELECT a.IdAlumno
		,a.Dni
		,a.Nombre
		,A.Edad
		,a.Promedio
		,a.Apellido
		,a.FechaRegistro
		,a.FechaModificacion
		,c.Descripcion
		,c.IdCurso
	FROM Alumno a
	INNER JOIN Curso c ON c.IdCurso = a.IdCurso
	WHERE 1 = 1
		AND a.IdAlumno = @idAlumno
	ORDER BY a.IdAlumno DESC
END
GO

CREATE PROC usp_Curso_list
AS
BEGIN
	SELECT IdCurso
		,Descripcion
	FROM Curso
	WHERE 1 = 1
END
GO

CREATE PROC usp_Alumno_add @dni CHAR(8) = NULL
	,@nombre VARCHAR(250) = NULL
	,@apellido VARCHAR(250) = NULL
	,@edad INT = NULL
	,@promedio DECIMAL = NULL
	,@idCurso INT = NULL
AS
BEGIN
	INSERT INTO Alumno (
		dni
		,Nombre
		,Apellido
		,Edad
		,Promedio
		,FechaRegistro
		,IdCurso
		)
	VALUES (
		@dni
		,@nombre
		,@apellido
		,@edad
		,@promedio
		,getdate()
		,@idCurso
		)
END
GO

CREATE PROC usp_Alumno_update @dni CHAR(8) = NULL
	,@nombre VARCHAR(250) = NULL
	,@apellido VARCHAR(250) = NULL
	,@edad INT = NULL
	,@promedio DECIMAL = NULL
	,@idCurso INT = NULL
	,@idAlumno INT = NULL
AS
BEGIN
	UPDATE Alumno
	SET dni = @dni
		,Nombre = @nombre
		,Apellido = @apellido
		,Edad = @edad
		,Promedio = @promedio
		,FechaModificacion = getdate(),
		IdCurso=@idCurso
	WHERE IdAlumno = @idAlumno
END
GO



