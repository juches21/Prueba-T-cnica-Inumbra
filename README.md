

<h1>Prueba Técnica Juan CHoví</h1>
(Es posible que al entrar al proyecto cargue una SampleScene vacia, en ese caso diríjase a la carpeta Assets/Scenes y hada doble clic en la escena Scene)
<h2>Controles</h2>
<ul>
<li>      W/A/S/D: Movimiento            </li>
<li>       Raton: Rotar camara             </li>
<li>        Espacio: Saltar            </li>
<li>        Click izquierdo: Atacar            </li>
  
</ul>
<h2>Caracteristicas</h2>

Movimiento del enemigo mediante NavMesh.                                                                                                                                                       <br><br>
Control de estados mediante maquina de estados                                                                                                                                    <br><br>
Sistema de creación de rutinas en la que se puede modificar si el enemigo seguir directamente al otro punto o si se detiene el tiempo que se le estipule haciendo un idle.                                      <br><br>
Sistema de animaciones mediante Animator.                                                                                                         <br><br>
Sistema de partículas al cargar el ataque y al ser aturdido.                                                                                      <br><br>
Feedback visual mediante UI al recibir golpe.                                                                                                     <br><br>
Cono de visión del enemigo creado en Blender e integrado                                                                                          <br><br>
Fbx de enemigo y animaciones integradas desde Mixamo                                                                                              <br><br>
Distancia de la patada modificable por interfaz                                                                                                   <br><br>
Tiempo de aturdimiento modificable por interfaz                                                                                                   <br><br>
Uso del asset 3rd Person Controller                                                                                                               <br><br>


<h2>Descripcion</h2>
(Assets/Root/Code)         <br><br><br>
DetectionSistem: se encarga de ocultar o mostrar las áreas de visión del enemigo y de detectar al jugador                                          <br><br>
CharacterControl:  funcion de ataque y de el Feedback visual para el juagdor          <br><br><br>
(Assets/Root/Code/Maquina estados)            <br><br><br>
EnemyStateMachine: gestiona todo el apartado de estados y seria la pieza angular puesto que se encarga de insertar los demas sripts en el game object                                <br><br>
EnemyAnimatorController: se encarga de ejecutar las animaciones a peticion del resto de codigos (aun en proceso)                                                                          <br><br>
EnemyTriggerAndCollision: se encarga de procesar las colisiones y los triggers del enemigo                                                                          <br><br>
EnemyAttackState: se encarga de ejecutar toda la logica del comportamiento de atacar                                                                          <br><br>
EnemyChaseState: se encarga de ejecutar toda la logica del comportamiento de la perseccuicion al jugador                                                                          <br><br>
EnemyDeadState: se encarga de ejecutar toda la logica de la muerte del enemigo                                                                       <br><br>
EnemyStunnedState: se encarga de ejecutar toda la logica del comportamiento de cuando el enemigo se queda vulnerable                                                                       <br><br>
EnemyWalkState: se encarga de ejecutar toda la logica del sistema de patrulla por los diferentes puntos asignados                                                                     <br><br>






<h2>Bugs Conocidos</h2>

Algunas animaciones no se ejecutan cuando es debido; se está trabajando en implementar una solución.
