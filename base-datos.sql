CREATE DATABASE sistema_gestion_academica;

USE sistema_gestion_academica;

CREATE TABLE sexos(
    id_sexo INT PRIMARY KEY AUTO_INCREMENT,
    sexo VARCHAR(20) NOT NULL
);

CREATE TABLE paises(
    id_pais INT PRIMARY KEY AUTO_INCREMENT,
    pais VARCHAR(50) NOT NULL
);

CREATE TABLE departamentos(
    id_departamento INT PRIMARY KEY AUTO_INCREMENT,
    departamento VARCHAR(50) NOT NULL,
    id_pais INT,
    FOREIGN KEY (id_pais) REFERENCES paises(id_pais)
);

CREATE TABLE municipios(
    id_municipio INT PRIMARY KEY AUTO_INCREMENT,
    municipio VARCHAR(50) NOT NULL,
    id_departamento INT,
    FOREIGN KEY (id_departamento) REFERENCES departamentos(id_departamento)
);

CREATE TABLE nacionalidades(
    id_nacionalidad INT PRIMARY KEY AUTO_INCREMENT,
    nacionalidad VARCHAR(50) NOT NULL,
    id_pais INT,
    FOREIGN KEY (id_pais) REFERENCES paises(id_pais)
);

CREATE TABLE etnias(
    id_etnia INT PRIMARY KEY AUTO_INCREMENT,
    etnia VARCHAR(50) NOT NULL
);

CREATE TABLE lenguas(
    id_lengua INT PRIMARY KEY AUTO_INCREMENT,
    lengua VARCHAR(50) NOT NULL
);

CREATE TABLE discapacidades(
    id_discapacidad INT PRIMARY KEY AUTO_INCREMENT,
    discapacidad VARCHAR(50) NOT NULL
);

CREATE TABLE turnos(
    id_turno INT PRIMARY KEY AUTO_INCREMENT,
    turno VARCHAR(100) NOT NULL
);

CREATE TABLE periodos (
    id_periodo INT PRIMARY KEY AUTO_INCREMENT,
    periodo VARCHAR(100) NOT NULL
);

CREATE TABLE centros (
    id_centro INT PRIMARY KEY AUTO_INCREMENT,
    centro VARCHAR(150) NOT NULL
);

CREATE TABLE grados (
    id_grado INT PRIMARY KEY AUTO_INCREMENT,
    grado INT(2) NOT NULL
);

CREATE TABLE secciones (
    id_seccion INT PRIMARY KEY AUTO_INCREMENT,
    seccion CHAR(1) NOT NULL
);

CREATE TABLE modalidades (
    id_modalidad INT PRIMARY KEY AUTO_INCREMENT,
    modalidad VARCHAR(100) NOT NULL
);

CREATE TABLE tutores_x_estudiantes(
    id_tutor_x_estudiante INT PRIMARY KEY AUTO_INCREMENT,
    nombres VARCHAR(255) NOT NULL,
    apellidos VARCHAR(255) NOT NULL,
    cedula VARCHAR(16) NOT NULL,
    telefono VARCHAR(9) NOT NULL
);

CREATE TABLE estudiantes(
    id_estudiante INT PRIMARY KEY AUTO_INCREMENT,
    nombres VARCHAR(255) NOT NULL,
    apellidos VARCHAR(255) NOT NULL,
    cedula VARCHAR(16),
    fecha_nacimiento DATE NOT NULL,
    direccion VARCHAR(255) NOT NULL, 
    telefono VARCHAR(9),
    partida_nacimiento BOOLEAN NOT NULL,
    fecha_matricula DATE NOT NULL,
    barrio VARCHAR(255) NOT NULL,
    peso DECIMAL(50, 2) DEFAULT 0,
    talla DECIMAL(50, 2) DEFAULT 0,
    territorio_indigena VARCHAR(255),
    comunidad_indigena VARCHAR(255),
    id_sexo INT,
    id_pais INT,
    id_departamento INT,
    id_municipio INT,
    id_nacionalidad INT,
    id_etnia INT,
    id_lengua INT,
    id_discapacidad INT,
    id_tutor_x_estudiante INT,
    FOREIGN KEY (id_sexo) REFERENCES sexos(id_sexo),
    FOREIGN KEY (id_pais) REFERENCES paises(id_pais),
    FOREIGN KEY (id_departamento) REFERENCES departamentos(id_departamento),
    FOREIGN KEY (id_municipio) REFERENCES municipios(id_municipio),
    FOREIGN KEY (id_nacionalidad) REFERENCES nacionalidades(id_nacionalidad),
    FOREIGN KEY (id_etnia) REFERENCES etnias(id_etnia),
    FOREIGN KEY (id_lengua) REFERENCES lenguas(id_lengua),
    FOREIGN KEY (id_discapacidad) REFERENCES discapacidades(id_discapacidad),
    FOREIGN KEY (id_tutor_x_estudiante) REFERENCES tutores_x_estudiantes(id_tutor_x_estudiante)
);

CREATE TABLE datos_academicos (
    codigo_estudiante VARCHAR(20) PRIMARY KEY,
    fecha_matricula DATE NOT NULL,
    nivel_educativo VARCHAR(255) NOT NULL,
    repitente BOOLEAN DEFAULT FALSE,
    modalidad INT,
    id_grado INT,
    id_seccion INT,
    id_turno INT,
    id_centro INT,
    id_estudiante INT,
    FOREIGN KEY (modalidad) REFERENCES modalidades(id_modalidad),
    FOREIGN KEY (id_grado) REFERENCES grados(id_grado),
    FOREIGN KEY (id_seccion) REFERENCES secciones(id_seccion),
    FOREIGN KEY (id_turno) REFERENCES turnos(id_turno),
    FOREIGN KEY (id_centro) REFERENCES centros(id_centro),
    FOREIGN KEY (id_estudiante) REFERENCES estudiantes(id_estudiante)
);

CREATE TABLE traslados (
    id_traslado INT PRIMARY KEY AUTO_INCREMENT,
    motivo_traslado VARCHAR(255) NOT NULL,
    fecha_traslado DATE NOT NULL,
    codigo_estudiante VARCHAR(20),
    id_centro INT,
    id_periodo INT,
    id_estudiante INT,
    FOREIGN KEY (codigo_estudiante) REFERENCES datos_academicos(codigo_estudiante),
    FOREIGN KEY (id_centro) REFERENCES centros(id_centro),
    FOREIGN KEY (id_periodo) REFERENCES periodos(id_periodo),
    FOREIGN KEY (id_estudiante) REFERENCES estudiantes(id_estudiante)
);

DELIMITER //

CREATE TRIGGER trigger_estudiantes
BEFORE INSERT ON estudiantes
FOR EACH ROW
BEGIN
    IF NEW.cedula NOT REGEXP '^[0-9]{3}-[0-9]{6}-[0-9]{4}[A-Z]{1}$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La cedula del estudiante debe tener el formato 000-000000-0000A';
    END IF;
    IF NEW.telefono NOT REGEXP '^[0-9]{4}-[0-9]{4}$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El telefono del estudiante debe tener el formato 0000-0000';
    END IF;
END;

// DELIMITER;

DELIMITER //

CREATE TRIGGER trigger_tutores_x_estudiantes
BEFORE INSERT ON tutores_x_estudiantes
FOR EACH ROW
BEGIN
    IF NEW.cedula NOT REGEXP '^[0-9]{3}-[0-9]{6}-[0-9]{4}[A-Z]{1}$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La cedula del tutor debe tener el formato 000-000000-0000A';
    END IF;
    IF NEW.telefono NOT REGEXP '^[0-9]{4}-[0-9]{4}$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El telefono del tutor debe tener el formato 0000-0000';
    END IF;
END;

// DELIMITER;

// REINICIE LA TERMINAL DE MYSQL PARA HACER LOS INSERTS

USE sistema_gestion_academica;

// Agregar sexos a la tabla sexo

INSERT INTO sexos (sexo) VALUES 
("Masculino"),
("Femenino");

// AGREGAR LOS PAISES, DEPARTAMENTO Y MUNICIPIOS QUE ESTAN EN EL ARCHIVO paises.sql

// Agregar nacionalidades a la tabla nacionalidades
INSERT INTO nacionalidades (nacionalidad, id_pais) VALUES 
("Guatemalteco", 1),
("Hondureño", 2),
("Salvadoreño", 3),
("Nicaragüense", 4),
("Costarricense", 5),
("Panameño", 6);

// Agregar etnias a la tabla etnias

INSERT INTO etnias (etnia) VALUES 
("Miskitu"),
("Mayagna"),
("Rama"),
("Ulwa"),
("Creole"),
("Garífuna"),
("Meztizo Costa Caribe"),
("Matagalpa"),
("Chorotega"),
("Nahoa-Niquirano"),
("Xia-Sutiaba"),
("Meztizo Pacífico Central Norte"),
("Otra");

// Agregar lenguas a la tabla lenguas

INSERT INTO lenguas (lengua) VALUES 
("Español"),
("Inglés"),
("Miskitu"),
("Mayagna Tuahka"),
("Mayagna Panamahka"),
("Ulwa"),
("Creole"),
("Rama"),
("Garífuna");

// Agregar discapacidades a la tabla discapacidades

INSERT INTO discapacidades (discapacidad) VALUES 
("Intelectual"),
("Autismo"),
("Hipoacusia"),
("Baja Visión"),
("Multidiscapacidad"),
("Física Motora"),
("Sordo"),
("Ciego"),
("Sordo Ciego"),
("Ninguna");

// Agregar turnos a la tabla turnos

INSERT INTO turnos (turno) VALUES 
("Matutino"),
("Vespertino"),
("Nocturno"),
("Sabatino"),
("Dominical"),
("Diurno");

// Agregar periodos a la tabla periodos

INSERT INTO periodos (periodo) VALUES 
("Primer Semestre"),
("Segundo Semestre"),
("Tercer Semestre"),
("Cuarto Semestre"),
("Quinto Semestre"),
("Sexto Semestre"),
("Séptimo Semestre"),
("Octavo Semestre"),
("Noveno Semestre"),
("Décimo Semestre");

// Agregar grados a la tabla grados

INSERT INTO grados (grado) VALUES
(7),
(8),
(9),
(10),
(11);

// Agregar secciones a la tabla secciones

INSERT INTO secciones (seccion) VALUES
("A"),
("B"),
("C"),
("D"),
("E"),
("F"),
("G"),
("H");

// Agregar centros a la tabla centros

INSERT INTO centros (centro) VALUES 
("Instituto Nacional Reino de Suecia Estelí"),
("Instituto Nacional Gillermo Cano Balladares "),
("Instituto Nacional Francisco Luis Espinoza"),
("Instituto Nacional Pablo Antonio Cuadra (INPAC)"),
("Colegio Adonay"),
("Colegio San Francisco - Hermanos Maristas"),
("Colegio Nuestra Señora del Rosario"),
("Colegio San Ramón Wanda"),
("Colegio SOS Hermann Gmeiner"),
("Colegio Liceo Católico María Auxiliadora"),
("Colegio Divine Mercy Bilingual School");

// Agregar modalidades a la tabla modalidades

INSERT INTO modalidades (modalidad) VALUES 
("Presencial"),
("Virtual");

// Agregar tutores a la tabla tutores_x_estudiantes

INSERT INTO tutores_x_estudiantes (nombres, apellidos, cedula, telefono) VALUES 
("Juan", "Pérez", "123-456789-0000A", "1234-5678"),
("María", "González", "987-654321-0000A", "8765-4321");

// Agregar estudiantes a la tabla estudiantes

INSERT INTO estudiantes (nombres, apellidos, cedula, fecha_nacimiento, direccion, telefono, partida_nacimiento, fecha_matricula, barrio, peso, talla, territorio_indigena, comunidad_indigena, id_sexo, id_pais, id_departamento, id_municipio, id_nacionalidad, id_etnia, id_lengua, id_discapacidad, id_tutor_x_estudiante) VALUES 
("Carlos David", "González Briones", "123-456789-0000A", "2000-01-01", "Barrio San Judas", "1234-5678", 1, "2020-01-01", "Barrio San Judas", 50, 1.70, "Territorio Indigena", "Comunidad Indigena", 1, 1, 1, 1, 1, 1, 1, 1, 1),
("María José", "Pérez Estrada", "987-654321-0000A", "2000-01-01", "Barrio San Judas", "1234-5678", 0, "2020-01-01", "Barrio San Judas", 50, 1.70, "Territorio Indigena", "Comunidad Indigena", 2, 2, 2, 2, 2, 2, 2, 2, 2);

// Agregar datos academicos a la tabla datos_academicos

INSERT INTO datos_academicos (codigo_estudiante, fecha_matricula, nivel_educativo, repitente, modalidad, id_grado, id_seccion, id_turno, id_centro, id_estudiante) VALUES 
("1234567890000A200001", "2020-01-01", "Secundaria", 0, 1, 1, 1, 1, 1, 1),
("9876543210000A200001", "2020-01-01", "Secundaria", 0, 1, 1, 1, 1, 1, 2);

// Agregar traslados a la tabla traslados

INSERT INTO traslados (motivo_traslado, fecha_traslado, codigo_estudiante, id_centro, id_periodo, id_estudiante) VALUES 
("Cambio de Centro", "2020-01-01", "1234567890000A200001", 1, 1, 1),
("Cambio de Centro", "2020-01-01", "9876543210000A200001", 1, 1, 2);
