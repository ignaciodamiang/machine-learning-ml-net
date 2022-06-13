create table evaluar_comentario (id_evaluar_comentario int primary key identity(1,1),
								 descripcion varchar(100) not null,
								 porcentaje float not null,
								 valor bit not null)