# Base de Videojuego de Ritmo
Conjunto de funcionalidades básicas de un juego de ritmo, similar a Guitar Hero, que será perfeccionado y empleado para el desarrollo de un proyecto de mayor envergadura.
- Aparte de las mecánicas base, se han diseñado dos herramientas diferentes para generar niveles a partir de "grabación de pulsaciones" y archivos MIDI, empleando la librería DryWetMidi.
- El proyecto contiene dos escenas: el nivel en sí donde se emplean las mecánicas de ritmo y una pantalla de final de nivel desde la que podremos observar unos resultados básicos y cerrar el juego.
- Este repositorio también contiene una build generada del proyecto para poder probar el resultado.

# Funcionamiento de las herramientas para crear niveles. 
Los niveles están configurados como un fichero txt con estructura csv, en el que aparecen el segundo en el que este 
# Desde grabador de niveles: 
- Escoger la canción del nivel en el Audio Source
- Crear un txt en la carpeta notesheets y comentar la primera fila “//”
- Activar el componente script Note Level Recorder del Game Object Director Spawners y, en path, asignar la ubicación del txt que hemos creado.
- Iniciar el nivel y pulsar las notas como nos gustaría que se jugara el nivel, con cuidado de que el archivo que se esté leyendo no sea nuestro txt en blanco.
- Cuando queramos probarlo, desactivamos Note Level Recorder y, en  Director Note Spawner asignamos en el campo Notes File el txt que creamos al principio.
# Desde archivo MIDI:
- Escoger la canción en formato mp3 del nivel en el Audio Source
- Escoger el archivo MIDI con solo la voz principal de la pieza.
- Creamos un archivo txt donde irán los tiempos y raíles de las notas del nivel.
- Activar el componente script MIDI Recorder del Gameobject del canvas principal. Rellenaremos, desde el editor, path con la ruta hacia nuestro archivo MIDI y, en path txt, la ruta del fichero txt.
- Iniciar la escena del proyecto y, cuando haya cargado las notas del MIDI, paramos la ejecución.
- Cuando queramos probarlo, desactivamos MIDI Recorder y, en Director Note Spawner asignamos en el campo Notes File el txt que creamos al principio.

En ambos casos, al probar el nivel generado, debemos asegurarnos de que los txt escritos no tengan una última línea en blanco ya que, si no, el juego no podrá leerlos bien.

# Otros Datos
La canción que suena durante el nivel de prueba es Clavelitos, en una versión producida por el artista Enrique Lacave expresamente para este proyecto.
El proyecto mayor será publicado en la siguiente página de itch-io: https://isabel-arrans.itch.io/
