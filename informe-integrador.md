## Introducción
El proceso manual de la gestión de matrículas, registro académico y proceso de traslado de una institución a otra, representa una inversión de tiempo y recursos físicos, lo que implica una gran cantidad de trabajo administrativo, como la recopilación de información de estudiantes activos, retirados o reprobados.

Este enfoque práctico es propenso a errores y retrasos de tiempo, que podría invertirse en actividades académicas más productivas, además, la falta de automatización dificulta el acceso rápido y eficiente de la información sobre los miembros de la comunidad educativa, lo que puede afectar en toma de decisiones y la comunicación asertiva con los responsables del estudiante y demás personal de la institución.

Se propone la implementación de un sistema de gestión académica integral y automatizado, basado en tecnologías de información y comunicación (TIC), que permitirá mejorar procesos administrativos relacionados con la matrícula y registro académico de datos de estudiantes, proporcionando una solución eficiente para las necesidades de la institución, en la que se reduzca la carga de trabajo y los errores en ingresos de datos manuales.

Un sistema de gestión académica es una herramienta integral que proporciona una serie de beneficios y objetivos para mejorar la administración y operación de una institución educativa, pues aporta en la toma de decisiones, facilita la comunicación, promueve la transparencia y optimiza el uso de recursos. Esto contribuye significativamente a una mejor calidad y experiencia escolar más efectiva para todos los involucrados. (Carvalho, 2024)
 
## Descripción General
SGA, Sistema de gestión académica para el Instituto Nacional Reino de Suecia - Estelí, es una herramienta informática diseñada para funcionar en computadoras dentro de la institución educativa. Esta aplicación ofrecerá una interfaz gráfica intuitiva que permitirá al usuario acceder a diversas funcionalidades y realizar tareas relacionadas con la gestión de la información académica y administrativa.

1. Funciones

Este sistema ofrecerá funciones específicamente diseñadas para gestionar de manera eficiente diversos aspectos dentro de una institución educativa, se incluye la capacidad de realizar matrículas de forma segura y eficiente, almacenando tanto la información personal como académica de los nuevos estudiantes en una base de datos. Para estudiantes que se transfieren o se trasladan de centro a otro, el sistema generará campos predefinidos que automatizan el proceso de ingreso de datos, reduciendo así la posibilidad de errores asociados con la escritura manual. Del mismo modo, para estudiantes que vuelven a matricularse, se solicitarán datos específicos para actualizar su información existente.

Estas características en conjunto contribuirán a mejorar la comunicación y el seguimiento del progreso académico en la institución, fomentando un entorno educativo más eficaz y colaborativo.

2. Usuarios

El usuario debe ser personal administrativo de la institución. Dado que la confiabilidad y seguridad del sistema son cruciales para su funcionamiento adecuado, la administración del mismo es de vital importancia. Además, este usuario está a cargo de la gestión de datos, por lo que debe poseer una amplia experiencia en el dominio de sistemas.
	
3. Restricciones

En cuanto a las restricciones en la creación de nuestro sistema, hemos identificado lo siguiente:
La política del entorno donde se ejecutará el software (Institución) restringe el acceso a los datos de calificaciones de los estudiantes, una funcionalidad que teníamos planeado incluir.

Dado que el software va dirigido a una institución especializada en educación secundaria, nos enfrentamos a limitaciones relacionadas con la infraestructura informática, pues al no contar con una adecuada puede ser un obstáculo, especialmente en términos de requisitos de hardware, lo que podría afectar el funcionamiento del sistema en computadoras más antiguas.

Por tratarse de una aplicación de escritorio, la disponibilidad del sistema estará restringida a las computadoras donde esté instalado. Esto implica que los usuarios no podrán acceder al sistema desde dispositivos móviles u otros equipos que no cuenten con la aplicación instalada.

4. Suposiciones o dependencias

Este sistema depende de cierta infraestructura tecnológica, como un acceso a internet y disposición de equipos de cómputo, en donde los datos serán precisos al ser ingresados por parte del usuario, al igual que la seguridad de la información. Es meramente dependiente del sistema operativo de Microsoft Windows dado que es el requerimiento principal que se nos solicita por su lenguaje de programación.

5. Requisitos futuros

Para anticipar futuros requisitos en este sistema de gestión académica, es esencial tener en cuenta tanto las tendencias tecnológicas emergentes como las necesidades específicas del ámbito educativo. Esto incluye la integración de capacidades avanzadas como la inteligencia artificial para optimizar procesos y ofrecer una experiencia más personalizada para los usuarios. Además, es importante considerar la posibilidad de permitir la personalización de la interfaz del sistema, otro aspecto crucial es garantizar la accesibilidad del sistema desde una variedad de recursos tecnológicos, como dispositivos móviles y tablets, para que los usuarios puedan acceder a la plataforma de manera conveniente y eficiente en cualquier momento y lugar. (Wrobel, 2023)

## Requisitos específicos

1. Interfaces externas

Las interfaces externas engloban las conexiones y herramientas que facilitan la interacción entre el sistema y personas que no forman parte directa de la institución educativa o del sistema en sí. Es crucial destacar que estas interfaces no son compatibles con otros sistemas operativos que no sean Microsoft Windows. Por lo tanto, asegurar el acceso a portales de estudiantes, docentes y padres es fundamental para garantizar la información académica relevante, es importante considerar la implementación de aplicaciones móviles que permitan a los usuarios acceder a estos recursos desde cualquier lugar.

2. Funciones

**Inicio de sesión**: El sistema deberá incluir un administrador al que se le asignará un usuario y una contraseña para acceder a todas las funciones disponibles. Además, se garantizará la capacidad del sistema para almacenar de manera segura los datos de inicio de sesión. Esto implica que una vez que se registren el nombre de usuario y la contraseña, se guardarán de forma segura. Por lo tanto, en sesiones posteriores, solo será necesario ingresar la contraseña para acceder.

**Estudiantes**: El sistema deberá acceder al apartado de estudiantes, donde mostrará un panel de búsqueda que permitirá acceder a toda la información del estudiante, incluyendo los datos de su tutor responsable. Además, se ofrecerá la opción de editar este registro en caso de que sea necesario actualizar algún dato, como la dirección, el teléfono o corregir alguna falta ortográfica.

**Matrícula**: El sistema deberá acceder al apartado de matrículas, donde se guardarán de manera segura y eficiente los datos del nuevo estudiante a inscribir, estos se introducirán tanto de forma textual como a través de selecciones múltiples y se almacenarán en la base de datos del sistema. Además, los formularios de matrícula se completarán en una serie de pasos organizados por categorías dentro de este proceso.Posteriormente, estos datos podrán ser visualizados desde la sección de "estudiantes" mencionada anteriormente. Por último, se incluirán dos botones con opciones para guardar la matrícula e imprimir un comprobante de la misma.

**Reingreso**: El sistema deberá dirigirse a la sección de reingreso, donde se presentará un breve formulario con algunos campos prellenados para que el usuario seleccione elementos como la modalidad, turno, grado y sección. Esto ocurrirá cuando un estudiante avance a un siguiente grado y necesite actualizar su registro. Además, se ofrecerá la opción de guardar la información actualizada y de imprimir un comprobante de matrícula de reingreso.

**Traslado**: El sistema deberá acceder al apartado de traslado, donde se mostrará un formulario breve con información preestablecida, como el código del estudiante y el nombre generado automáticamente. Se solicitará completar campos relacionados con los motivos del traslado. Además, se proporcionarán botones para guardar la información ingresada y para imprimir un comprobante.

**Información**: El sistema deberá proporcionar acceso a una sección de información que contendrá el objetivo del proyecto y un manual de usuario completo. Este manual ofrecerá información relevante sobre todos los aspectos necesarios del sistema, aclarando cualquier duda sobre su funcionamiento y asegurando una comprensión completa de sus características y utilidades.

### Entradas, procesos y salidas

**Funciones de entrada**: Incluyen el acceso al sistema mediante el inicio de sesión para utilizar sus funcionalidades y la inscripción de matrícula.

**Funciones de proceso**: Incluye la validación de los datos de inicio de sesión, la verificación de la información introducida durante el proceso de matrícula, la capacidad de buscar estudiantes por sus nombres y apellidos, así como la opción de corregir cualquier dato incorrecto o mal registrado.

**Funciones de salida**: Incluyen la emisión de reportes de hojas de matrícula y comprobantes con la posibilidad de imprimirlos.

### Requerimientos funcionales y no funcionales

Los requerimientos funcionales definen lo que debe hacer el sistema, mientras que los no funcionales definen como debe hacerlo y las características a cumplir con estándares de calidad y rendimiento.
#### No funcionales: 
- Intel i3 4130 o equivalentes
- 4GB de RAM
- Sistema operativo Windows 7
- 1GB de espacio
- Conexión Wi-Fi
- Monitor
- Mouse
- Teclado

#### Funcionales:
- Inicio de sesión
- Registro de estudiantes
- Registro de matrícula
- Agregar datos de estudiantes reingresados y trasladados 
- Impresiones

###	Requisitos de rendimiento

Se cuenta con un número de 10 terminales con su respectivo código, que serán procesadas una a la vez por el sistema, se tendrá la disponibilidad de tener un usuario administrador conectado simultáneamente (responsable administrador de la institución). Dependiendo de la capacidad del servidor se podrá saber el número de transacciones realizadas por segundo.

###	Restricciones de diseño
El diseño debe ser sencillo y fluido, aunque existen algunas restricciones como:
- Limitación de ciertos equipos de cómputo presentes en la institución
- Sistemas operativos no actualizados
- Drivers necesarios no instalados  
- Necesidad de garantizar la seguridad de los datos estudiantiles
- Capacidad de escalabilidad para manejar un gran número de usuarios
- Compatibilidad con múltiples dispositivos y plataformas

### Atributos del sistema
- Interfaz de usuario intuitiva: Deberá ser intuitiva y fácil de usar que va a permitir navegar por las diferentes funciones del sistema de manera eficiente.
- Gestión de estudiantes: Permite el registro y la actualización de información detallada sobre estudiantes, abarcando datos personales e información académica.
- Funciones de búsqueda y filtrado: Herramientas de búsqueda que permitan encontrar estudiantes y poder editar su información.
- Proceso de inscripción: Un sistema que permita inscribir o matricular de forma electrónica, proporcionando todos los datos necesarios, automatizando así el proceso que se lleva manuscrito.
- Comunicación y colaboración: Ofrece herramientas de comunicación integradas que posibilitan la interacción entre estudiantes y personal administrativo, promoviendo la colaboración y el intercambio de información relevante de manera eficaz.
- Seguridad y respaldo de datos: Se implementarán medidas de seguridad para salvaguardar la información almacenada en el sistema, junto a procedimientos de respaldo diseñados para prevenir la pérdida de datos.
