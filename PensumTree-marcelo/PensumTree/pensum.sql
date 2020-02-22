create database pensum;

create table facultad(
	id int unsigned not null primary key AUTO_INCREMENT,
    nombre varchar(255) not null,
    estado bit not null
);

create table tipo_carrera(
	id int unsigned not null primary key AUTO_INCREMENT,
    nombre varchar(255) not null,
    minUv int unsigned not null,
    estado bit not null
);

create table escuela(
	id int unsigned not null primary key AUTO_INCREMENT,
    nombre varchar(255) not null,
    estado bit not null
);

create table carrera(
	id int unsigned not null primary key AUTO_INCREMENT,
    nombre varchar(255) not null,
    idFacultad int unsigned not null,
    idTipo int unsigned not null,
    FOREIGN KEY(idFacultad) REFERENCES facultad(id),
    FOREIGN KEY(idTipo) REFERENCES tipo_carrera(id),
    estado bit not null
);

create table materia(
	id int unsigned not null primary key AUTO_INCREMENT,
    nombre varchar(255) not null,
    uv int unsigned not null,
    codigo char(6) not null,
    primerCiclo bit not null,
    segundoCiclo bit not null,
    lab bit not null,
    electiva bit not null,
    idEscuela int unsigned not null,
    idPrerreq1 int unsigned,
    idPrerreq2 int unsigned,
    idPrerreq3 int unsigned,
    idPrerreq4 int unsigned,
    FOREIGN KEY(idEscuela) REFERENCES escuela(id),
    FOREIGN KEY(idPrerreq1) REFERENCES materia(id),
    FOREIGN KEY(idPrerreq2) REFERENCES materia(id),
    FOREIGN KEY(idPrerreq3) REFERENCES materia(id),
    FOREIGN KEY(idPrerreq4) REFERENCES materia(id),
    estado bit not null
);

create table plan(
	id int unsigned not null primary key AUTO_INCREMENT,
    idCarrera int unsigned not null,
    inicio int unsigned not null,
    fin int unsigned not null,
    FOREIGN KEY(idCarrera) REFERENCES carrera(id),
    estado bit not null
);

create table pensum(
	id int unsigned not null primary key AUTO_INCREMENT,
    idPlan int unsigned not null,
    idMateria int unsigned not null,
    corr int unsigned not null,
    ciclo int unsigned not null,
    FOREIGN KEY(idPlan) REFERENCES plan(id),
    FOREIGN KEY(idMateria) REFERENCES materia(id),
    estado bit not null
);