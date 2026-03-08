

<h1>Prueba Técnica Juan CHoví</h1>
(Es posible que al entrar al proyecto cargue una SampleScene vacia, en ese caso diríjase a la carpeta Assets/Scenes y hada doble clic en la escena Scene)
<h2>Controles</h2>
<ul>
<li>       W/D: avanzar retroceder            </li>
<li>        A/D:  rotar              </li>
<li>        Espacio/click izquierdo: atacar            </li>
</ul>
<h2>Caracteristicas</h2>

Movimiento del enemigo mediante NavMesh.                                                                                                                                                       <br><br>
Control de estados mediante bools, funciones y corrutinas                                                                                                                                    <br><br>
Sistema de creación de rutinas en la que se puede modificar si el enemigo seguir directamente al otro punto o si se detiene el tiempo que se le estipule haciendo un idle.                                      <br><br>
Sistema de animaciones mediante Animator.                                                                                                         <br><br>
Sistema de partículas al cargar el ataque y al ser aturdido.                                                                                      <br><br>
Feedback visual mediante UI al recibir golpe.                                                                                                     <br><br>
Cono de visión del enemigo creado en Blender e integrado                                                                                          <br><br>
Fbx de personajes y animaciones integradas desde Mixamo                                                                                           <br><br>
Distancia de la patada modificable por interfaz                                                                                                   <br><br>
Tiempo de aturdimiento modificable por interfaz                                                                                                   <br><br>
Uso del new input system                                                                                                                          <br><br>

<h2>Descripcion</h2>
(Assets/Root/Code)
DetectionSistem: se encarga de ocultar o mostrar las áreas de visión del enemigo y de detectar al jugador                                          <br><br>
EnemyMotion: gestiona todo el apartado de estados tanto su rotación entre ellos como comportamiento de estos mismos                                <br><br>
CharacterControl: controles de tanque para el jugador con new input system reutilizados de anteriores proyectos con el añadido de la funcion de ataque y de el Feedback visual          <br><br>
