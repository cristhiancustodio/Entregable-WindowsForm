set dateformat dmy
use master
if DB_ID ('Colegio') is not null
   drop database Colegio
go
create database Colegio
go
use Colegio

GO 

create table alumnos(
	idAlumno int primary key not null,
    primer_nombre varchar(50) not null,
    segundo_nombre varchar(50)  ,
    primer_apellido varchar(50)  not null,
    segundo_apellido varchar(50)  not null,
    telefono varchar(10)  ,
    celular varchar(10)  not null,
    direccion varchar(50)  not null,
    email varchar(50)  not null,
    fecha_nacimiento date  not null,
    observacion varchar(255) 
);

create table PROFESORES(
	idProfesor varchar(50) primary key not null,
    nombre varchar(50) not null,
    apellido varchar(50) not null
);

create table CURSOS(
	cod_curso varchar(50) primary key not null,
    materia varchar(50) not null
);

create table CURSO_PROFE(
	codigo varchar(50) not null primary key,
    idProfesor varchar(50) not null,
    cod_curso varchar(50) not null,
    constraint fk_id_profesor
    foreign key(idProfesor) references PROFESORES(idProfesor)
	on update cascade
	on delete cascade,
    constraint fk_cod_curso
    foreign key(cod_curso) references CURSOS(cod_curso)
	on update cascade
	on delete cascade
);

create table CLASES(
	idAlumno int not null,
    codigo varchar(50) not null,
    constraint fk_idAlumno
    foreign key(idAlumno) references alumnos(idAlumno)
	on update cascade
	on delete cascade,
    constraint fk_codigo
    foreign key(codigo) references CURSO_PROFE(codigo)
	on update cascade
	on delete cascade
);
GO

insert into cursos values
('C-001','Matematica'),
('C-002','Algebra'),
('C-003','Comunicacion'),
('C-004','Historia'),
('C-005','Ciencias'),
('C-006','Ingles'),
('C-007','Educaci�n Fisica'),
('C-008','Civica')
 
insert into profesores values
('S10','Miriam','Alvia'),
('S11','Juan','Capcha'),
('S12','Bertha','Castro'),
('S14','Augusto','Diaz'),
('S15','Elio','Figueroa'),
('S16','Jose','La Rosa'),
('S17','Victor','Pinto'),
('S18','Raquel','Garces');
 
insert into curso_profe values
('A20','S10','C-002'),
('A30','S14','C-004'),
('B14','S16','C-008'),
('B18','S11','C-001'),
('C03','S15','C-003'),
('C16','S18','C-005'),
('M40','S12','C-006'),
('P30','S14','C-007')



/*Procedimientos almacenados*/

/*CRUD PARA EL ALUMNO*/
create procedure sp_insertarAlumno
@_idAlumno int,
@_p_nombre varchar(50),
@_s_nombre varchar(50),
@_p_apellido varchar(50),
@_s_apellido varchar(50),
@_telefono varchar(50),
@_celular varchar(50),
@_direccion varchar(50),
@_email varchar(50),
@_fecha date,
@_observacion varchar(255)

as
insert dbo.alumnos values(@_idAlumno,@_p_nombre, @_s_nombre,@_p_apellido,@_s_apellido,@_telefono,@_celular,@_direccion,@_email,@_fecha,@_observacion)
go

/* ------READ ---------- */

/*ver todos los alumnos*/
create procedure sp_VerAlumnos
as
	select * from alumnos
go
/*ver un alumno*/

create procedure sp_verUnicoAlumno
@_idAlumno int
as 
select * from dbo.alumnos where idAlumno = @_idAlumno
go



/*------UPDATE---------*/
create procedure sp_ActualizarAlumno
@_idAlumno int,
@_p_nombre varchar(50),
@_s_nombre varchar(50),
@_p_apellido varchar(50),
@_s_apellido varchar(50),
@_telefono varchar(50),
@_celular varchar(50),
@_direccion varchar(50),
@_email varchar(50),
@_fecha date,
@_observacion varchar(255)
as
	update dbo.alumnos set
idAlumno  = @_idAlumno,
primer_nombre = @_p_nombre,
segundo_nombre = @_s_nombre,
primer_apellido = @_p_apellido,
segundo_apellido = @_s_apellido,
telefono  = @_telefono,
celular  = @_celular,
direccion  = @_direccion,
email  = @_email,
fecha_nacimiento =@_fecha,
observacion =@_observacion where idAlumno = @_idAlumno
go
/*------DELETE---------*/
create procedure sp_EliminarAlumno
@_idAlumno int 
as
	delete from alumnos where idAlumno = @_idAlumno;
go

/*------------------*CRUD PARA PROFESOR--------------------------*/

/*CREATE*/
create procedure sp_InsertProfe
@idProfesor varchar(50),
@nombre varchar(50),
@apellido varchar(50)
as
	insert dbo.PROFESORES values (@idProfesor,@nombre,@apellido)
go

/*READ*/

/*ver unico profesores*/
create procedure sp_verProfesor
@idProfesor varchar(50)
as
	select * from dbo.PROFESORES where idProfesor = @idProfesor
go
/*Ver todos los profesor*/
create procedure sp_verTodosProfesores
as
	select * from dbo.PROFESORES
go

/*UPDATE*/
create procedure sp_actualizarProfe
@idProfe varchar(50),
@nombre varchar(50),
@apellido varchar(50)
as 
	update dbo.PROFESORES set
idProfesor = @idProfe,
nombre = @nombre,
apellido = @apellido where idProfesor = @idProfe
go

/*DELETE*/
create procedure sp_eliminarProfe
@idProfe varchar(50)
as
	delete from dbo.PROFESORES where idProfesor = @idProfe
go


/*------------------------CRUD PARA MATERIAS --------------------------*/

/*CREATE*/

create procedure sp_InserCurso
@cod_curso varchar(50),
@materia varchar(50)
as 
	insert into dbo.CURSOS values (@cod_curso,@materia)
go


/*READ*/
/*VER TODOS LOS CURSOS*/


create procedure sp_verCursos
as
	select * from dbo.CURSOS
go

create procedure sp_verUnicoCurso
@_idCurso varchar(50)
as 
	select * from dbo.CURSOS where cod_curso = @_idCurso
go
/*UPDATE*/
create procedure sp_actualizarMateria
@cod_curso varchar(50),
@materia varchar(50)
as 
	 update dbo.CURSOS set
cod_curso = @cod_curso,
materia = @materia
go

/*DELETE*/
create procedure sp_eliminarCurso
@cod_curso varchar(50)
as
	delete from dbo.CURSOS  where cod_curso = @cod_curso
go


/*Procedimientos almacenados para las clases de los alumnos*/
create procedure sp_verCursoProfe
as
	select CURSO_PROFE.codigo as Codigo, PROFESORES.apellido as Apellido,CURSOS.materia as Materia from PROFESORES 
	inner join CURSO_PROFE on CURSO_PROFE.idProfesor=PROFESORES.idProfesor 
	inner join CURSOS on CURSO_PROFE.cod_curso= CURSOS.cod_curso  
go


/*editar esta linea de codigo para registrar clases*/
/*create procedure sp_RegistrarClase
@idAlumno int,
@apellido varchar(50),
@materia varchar(50
as
	insert into CLASES values*/

create procedure sp_verClaseAlumno
as
	select CLASES.idAlumno as IdAlumno,PROFESORES.apellido as Apellido,CURSOS.materia as Materia from CLASES 
	inner join CURSO_PROFE on CURSO_PROFE.codigo = CLASES.codigo
	inner join PROFESORES on PROFESORES.idProfesor = CURSO_PROFE.idProfesor
	inner join CURSOS on CURSOS.cod_curso = CURSO_PROFE.cod_curso
go

