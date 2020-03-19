create database pensum;
use pensum;
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


insert into facultad(nombre, estado) values('Ingeniería',1);
insert into tipo_carrera(nombre, minUv, estado) values('Ingeniería',160,1);
insert into escuela(nombre, estado) values('Humanística',1);
insert into escuela(nombre, estado) values('Ciencias Básicas',1);
insert into escuela(nombre, estado) values('Computación',1);
insert into escuela(nombre, estado) values('Electrónica',1);
insert into escuela(nombre, estado) values('Industrial',1);
insert into carrera(nombre, idFacultad, idTipo, estado) values('Ingeniería en Ciencias de la Computación',1,1,1);

insert into materia(nombre,uv,codigo,primerCiclo,segundoCiclo,lab,electiva,idEscuela,idPrerreq1,idPrerreq2,idPrerreq3,idPrerreq4,estado) VALUES
	('Cálculo Diferencial',4,'CAD501',1,1,0,0,2,null,null,null,null,1),
	('Química General',4,'QUG501',1,1,1,0,2,null,null,null,null,1),
	('Comunicación Oral y Escrita',3,'COE201',1,1,0,0,1,null,null,null,null,1),
	('Programación Estructurada',4,'PRE104',1,0,1,0,3,null,null,null,null,1),
	('Álgebra Vectorial y Matrices',3,'AVM501',1,1,0,0,2,null,null,null,null,1),
	('Cálculo Integral',4,'CAI501',1,1,0,0,2,1,null,null,null,1),
	('Cinemática y Dinámica de Partículas',4,'CDP501',1,1,1,0,2,1,null,null,null,1),
	('Programación Orientada a Objetos',4,'POO104',0,1,1,0,3,4,null,null,null,1),
	('Modelamiento y Diseño de Base de Datos',4,'MDB104',0,1,1,0,3,4,null,null,null,1),
	('Cálculo de Varias Variables',4,'CVV5501',1,1,0,0,2,5,6,null,null,1),
	('Electricidad y Magnetismo',4,'EYM501',1,1,1,0,2,2,6,7,null,1),
	('Estadística Aplicada',4,'ESA501',1,1,0,0,2,6,null,null,null,1),
	('Programación con Estructuras de Datos',4,'PED104',1,0,1,0,3,8,null,null,null,1),
	('Análisis y Diseño de Sistemas Informáticos',4,'ADS104',1,0,0,0,3,8,9,null,null,1),
	('Ecuaciones Diferenciales',4,'EDI501',1,1,0,0,2,10,null,null,null,1),
	('Cálculo Avanzado',4,'CAA501',1,1,0,0,2,10,null,null,null,1),
	('Oscilaciones, Fluidos y Calor',4,'OFC501',1,1,1,0,2,6,7,null,null,1),
	('Datawarehouse y Minería de Datos',4,'DMD104',0,1,1,0,3,9,null,null,null,1),
	('Lenguajes Interpretados en el Cliente',4,'LIC104',0,1,1,0,3,8,9,null,null,1),
	('Análisis de Circuitos Eléctricos',4,'ACE102',1,1,1,0,4,11,null,null,null,1),
	('Gestión Ambiental',4,'GEA106',1,1,0,0,5,2,null,null,null,1),
	('Análisis y Evaluación Económica',4,'AEE106',1,1,0,0,5,12,null,null,null,1),
	('Antropología Filosófica',3,'ANF231',1,1,0,0,1,null,null,null,null,1),
	('Arquitectura de Computadoras',4,'ACO101',1,0,1,0,4,4,11,null,null,1),
	('Dirección de Proyectos',4,'DDP106',1,1,1,0,5,21,22,null,null,1),
	('Sistemas Operativos',4,'SIO104',0,1,1,0,3,24,null,null,null,1),
	('Pensamiento Social Cristiano',3,'PSC231',1,1,0,0,1,null,null,null,null,1),
	('Diseño de Redes de Datos',4,'DRD101',1,1,1,0,4,null,null,null,null,1),
	('Aplicación de Métodos Numéricos',4,'AMN401',1,1,1,0,2,4,15,20,null,1),
	('Ingeniería de Software',3,'ISO104',1,0,0,0,3,14,25,null,null,1),
	('Lenguajes Interpretados en el Servidor',4,'LIS104',1,0,1,0,3,19,null,null,null,1),
	('Interconexión de Redes de Datos',4,'IRD101',1,1,1,0,4,28,null,null,null,1),
	('Autómatas y Compiladores',3,'AYC104',0,1,1,0,3,13,29,null,null,1),
	('Gestión de la Calidad del Software',3,'GCS104',0,1,0,0,3,30,null,null,null,1),
	('Diseño y Programación de Software Multiplataforma',4,'DPS104',0,1,1,0,3,13,18,null,null,1),
	('Diseño de Sistemas de Seguridad para Redes de Datos',4,'DSS101',0,1,1,0,4,32,null,null,null,1),
	('Normalización de Tecnologías de Información',4,'NTI104',1,0,0,0,3,30,null,null,null,1),
	('Desarrollo de Software para Móviles',4,'DSM104',1,0,1,0,3,35,null,null,null,1),
	('Administración e Implementación de Servicios de Red con Sistemas Operativos Propietarios',4,'ASR104',1,0,1,0,3,32,null,null,null,1),
	('Auditoría de Sistemas',4,'AUS104',0,1,0,0,3,30,null,null,null,1),
	('Desarrollo de Software Empresarial',4,'DSE104',0,1,1,0,3,18,31,null,null,1),
	('Administración e Implementación de Servicios de Red con Sistemas Operativos Libres',4,'ASI104',0,1,1,0,3,32,null,null,null,1);
	