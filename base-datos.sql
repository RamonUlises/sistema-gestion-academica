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
    partida_nacimiento VARCHAR(255) NOT NULL,
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
    modalidad VARCHAR(255) NOT NULL,
    repitente BOOLEAN DEFAULT FALSE,
    id_grado INT,
    id_seccion INT,
    id_turno INT,
    id_centro INT,
    id_estudiante INT,
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

CREATE TRIGGER trigger_datos_academicos
BEFORE INSERT ON datos_academicos
FOR EACH ROW
BEGIN
    IF CHAR_LENGTH(NEW.codigo_estudiante) != 20 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El código del estudiante tiene el que tener 20 caracteres';
    END IF;
END;
//

DELIMITER;

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

// Agregar pais a la tabla paises

INSERT INTO paises (pais) VALUES 
("Guatemala"),
("Honduras"),
("El Salvador"),
("Nicaragua"),
("Costa Rica"),
("Panamá");

// Agregar departamentos de Guatemala a la tabla departamentos

INSERT INTO departamentos (id_pais, departamento) VALUES 
(1, "Alta Verapaz"),
(1, "Baja Verapaz"),
(1, "Chimaltenango"),
(1, "Chiquimula"),
(1, "El Progreso"),
(1, "Escuintla"),
(1, "Guatemala"),
(1, "Huehuetenango"),
(1, "Izabal"),
(1, "Jalapa"),
(1, "Jutiapa"),
(1, "Petén"),
(1, "Quetzaltenango"),
(1, "Quiché"),
(1, "Retalhuleu"),
(1, "Sacatepéquez"),
(1, "San Marcos"),
(1, "Sacatepéquez"),
(1, "Santa Rosa"),
(1, "Sololá"),
(1, "Suchitepéquez"),
(1, "Totonicapán"),
(1, "Zacapa");

// Agregar departamentos de Honduras a la tabla departamentos

INSERT INTO departamentos (id_pais, departamento) VALUES 
(2, "Atlántida"),
(2, "Choluteca"),
(2, "Colón"),
(2, "Comayagua"),
(2, "Copán"),
(2, "Cortés"),
(2, "El Paraíso"),
(2, "Francisco Morazán"),
(2, "Gracias a Dios"),
(2, "Intibucá"),
(2, "Islas de la Bahía"),
(2, "La Paz"),
(2, "Lempira"),
(2, "Ocotepeque"),
(2, "Olancho"),
(2, "Santa Bárbara"),
(2, "Valle"),
(2, "Yoro");

// Agregar departamentos de El Salvador a la tabla departamentos

INSERT INTO departamentos (id_pais, departamento) VALUES 
(3, "Ahuachapán"),
(3, "Cabañas"),
(3, "Chalatenango"),
(3, "Cuscatlán"),
(3, "La Libertad"),
(3, "La Paz"),
(3, "La Unión"),
(3, "Morazán"),
(3, "San Miguel"),
(3, "San Salvador"),
(3, "San Vicente"),
(3, "Santa Ana"),
(3, "Sonsonate"),
(3, "Usulután");

// Agregar departamentos de Nicaragua a la tabla departamentos

INSERT INTO departamentos (id_pais, departamento) VALUES 
(4, "Boaco"),
(4, "Carazo"),
(4, "Chinandega"),
(4, "Chontales"),
(4, "Estelí"),
(4, "Granada"),
(4, "Jinotega"),
(4, "León"),
(4, "Madriz"),
(4, "Managua"),
(4, "Masaya"),
(4, "Matagalpa"),
(4, "Nueva Segovia"),
(4, "Río San Juan"),
(4, "Rivas"),
(4, "RAAN"),
(4, "RAAS");

// Agregar departamentos de Costa Rica a la tabla departamentos

INSERT INTO departamentos (id_pais, departamento) VALUES 
(5, "Alajuela"),
(5, "Cartago"),
(5, "Guanacaste"),
(5, "Heredia"),
(5, "Limón"),
(5, "Puntarenas"),
(5, "San José");

// Agregar departamentos de Panamá a la tabla departamentos

INSERT INTO departamentos (id_pais, departamento) VALUES 
(6, "Bocas del Toro"),
(6, "Coclé"),
(6, "Colón"),
(6, "Chiriquí"),
(6, "Darién"),
(6, "Herrera"),
(6, "Los Santos"),
(6, "Panamá"),
(6, "Veraguas"),
(6, "Panamá Oeste"),
(6, "Emberá-Wounaan"),
(6, "Guna Yala"),
(6, "Ngäbe-Buglé");

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
("Mestizo"),
("Ladino"),
("Indígena"),
("Afrodescendiente"),
("Garífuna"),
("Xinca");

// Agregar lenguas a la tabla lenguas

INSERT INTO lenguas (lengua) VALUES 
("Español"),
("Inglés"),
("Francés"),
("Alemán"),
("Italiano"),
("Portugués"),
("Chino"),
("Japonés"),
("Coreano");

// Agregar discapacidades a la tabla discapacidades

INSERT INTO discapacidades (discapacidad) VALUES 
("Física"),
("Auditiva"),
("Visual"),
("Mental"),
("Intelectual"),
("Síndrome de Down"),
("Autismo"),
("Asperger"),
("TGD"),
("TDAH");

// Agregar turnos a la tabla turnos

INSERT INTO turnos (turno) VALUES 
("Matutino"),
("Vespertino"),
("Nocturno");

// Agregar periodos a la tabla periodos

INSERT INTO periodos (periodo) VALUES 
("Primer Semestre"),
("Segundo Semestre"),
("Tercer Semestre"),
("Cuarto Semestre");
