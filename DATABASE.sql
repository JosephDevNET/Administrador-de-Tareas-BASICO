create database DbRecordatorios
use DbRecordatorios

create table Notas (
	ID int primary key identity(1,1) not null,
	Nombre varchar(140) not null,
	Fecha_Inicio datetime not null default Getdate(),
	Fecha_Final datetime not null,
	Cuerpo nvarchar(MAX),
	Estado varchar(30) not null default 'pendiente'
);