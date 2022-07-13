use master;
go

IF EXISTS (SELECT * FROM Sysdatabases WHERE name='Academia')
begin
	drop database Universidad
end

----------------------------------------------------------------------------------
create database Universidad
go
------------------------------------------------------------------------------------

use Universidad

CREATE TABLE Alumnos(
	  Ci INT PRIMARY KEY  NOT NULL,
	  Nombre NVARCHAR(30) NOT NULL,
	  Direccion NVARCHAR(30),
	)
go

CREATE TABLE  Materias(
	  IdMateria INT PRIMARY KEY  NOT NULL,
	  Nombre NVARCHAR(20),
	  CargaHoraria INT
	);
	go
	
CREATE TABLE  Inscripcion(
	  Ci INT NOT NULL,
	  IdMateria INT NOT NULL,
	  Año INT NOT NULL,
	  PRIMARY KEY (Ci, IdMateria ),
	  FOREIGN KEY (Ci) REFERENCES Alumnos(Ci),
	  FOREIGN KEY (IdMateria) REFERENCES Materias(IdMateria)
	);
go

------------------------------------------------------------------------------------
insert into Alumnos values (111111,'Ana','Carrua 4444')
insert into Alumnos values (666666,'Luchi','Yi 2222')
insert into Alumnos values (333333,'Ceci','Yaro 2222')
insert into Alumnos values (555555,'Nacho','Rocha 1111')
insert into Alumnos values (444444,'Laura','Rocha 1111')
insert into Alumnos values (222222,'Ceci','Chuy 3333')
go

insert into Materias values (1,'BdeD',60)
insert into Materias values (2,'Redes',60)
insert into Materias values (3,'PrgIntro',120)
insert into Materias values (4,'PrgWeb',120)
go
	
insert into Inscripcion values( 111111,1,1998)
insert into Inscripcion values( 111111,2,1999)
insert into Inscripcion values( 222222,1,1999)
insert into Inscripcion values( 222222,2,2000)
insert into Inscripcion values( 222222,4,2005)
insert into Inscripcion values( 555555,1,2004)
insert into Inscripcion values( 555555,2,2005)
insert into Inscripcion values( 111111,4,2000)
insert into Inscripcion values( 555555,4,2007)
go

------------------------------------------------------------------------------------
CREATE PROC Agregar  @IdMateria int, @Nombre NVARCHAR(20), @carga INT AS
begin
	If (exists(select * from materias where IdMAteria = @IdMateria))
		return -1;

	INSERT INTO materias VALUES (@Idmateria,@nombre,@carga);

		IF (@@ERROR<>0)
			RETURN -2
		ELSE
			RETURN 1	
			
end
go

CREATE PROC Modificar  @IdMateria int, @Nombre NVARCHAR(20), @carga INT AS
begin
	If (not exists(select * from materias where IdMAteria = @IdMateria))
		return -1
		
	Update Materias
	Set Nombre = @Nombre, CargaHoraria = @carga
	where IdMateria = @IdMateria
	
		IF (@@ERROR<>0)
			RETURN -2
		ELSE
			RETURN 1
				
end
go

CREATE PROC Eliminar  @IdMateria int AS
begin
	If (not exists(select * from materias where IdMAteria = @IdMateria))
		return -1
		
	If (exists (select * from Inscripcion where IdMAteria = @IdMateria))
		return -2
		
	Delete 
	From Materias
	where IdMateria = @IdMateria
	
		IF (@@ERROR<>0)
			RETURN -2
		ELSE
			RETURN 1
				
end
go

CREATE PROCEDURE BuscarMateria @Id int AS
Begin
	Select *
	From Materias
	where IdMateria=@id
End
go

CREATE PROCEDURE InscriptosAmateria @id int AS
Begin
	Select A.*
	From Alumnos A inner join Inscripcion I on A.Ci = I.Ci
	where I.IdMateria = @id
End
go

Create Proc Salida @Id int, @Nom Nvarchar(20) output AS
Begin
		Select @nom = nombre
		From materias
		Where IdMateria = @id
end
go