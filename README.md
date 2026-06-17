<h1>🎮 Enemy AI Technical Test</h1>

<p><strong>Enemy AI Technical Test</strong> is a technical challenge developed in <strong>Unity</strong> focused on enemy artificial intelligence, state machine architecture, and player-enemy interaction systems.</p>

<p><strong>Developed as a technical assessment project.</strong><br>
The objective was to demonstrate proficiency in gameplay programming, AI behavior, navigation systems, animation integration, and code architecture.</p>

<hr>

<h2>📖 Description</h2>

<p><strong>Important:</strong> If the project opens with an empty SampleScene, navigate to <code>Assets/Scenes</code> and open the scene named <code>Scene</code>.</p>

<p>In <strong>Enemy AI Technical Test</strong>:</p>

<ul>
  <li>Control a third-person character and interact with an AI-controlled enemy.</li>
  <li>Face an enemy capable of patrolling, detecting, chasing, attacking, and reacting to player actions.</li>
  <li>Experience a complete enemy behavior system driven by a state machine.</li>
  <li>Observe visual feedback through animations, particles, UI effects, and detection systems.</li>
</ul>

<p>The project focuses on creating a flexible and scalable enemy AI architecture.</p>

<hr>

<h2>🎮 Controls</h2>

<ul>
  <li><strong>W / A / S / D</strong> – Character movement</li>
  <li><strong>Mouse</strong> – Camera rotation</li>
  <li><strong>Space</strong> – Jump</li>
  <li><strong>Left Mouse Button</strong> – Attack</li>
</ul>

<hr>

<h2>✨ Features</h2>

<ul>
  <li>Enemy navigation using Unity NavMesh</li>
  <li>Finite State Machine (FSM) architecture</li>
  <li>Customizable patrol routines with idle stops</li>
  <li>Animator-driven character and enemy animations</li>
  <li>Particle effects for attacks and stun states</li>
  <li>Visual damage feedback through UI</li>
  <li>Enemy vision cone modeled in Blender</li>
  <li>Mixamo character animations integration</li>
  <li>Configurable attack distance through Inspector</li>
  <li>Configurable stun duration through Inspector</li>
  <li>Third-person controller integration</li>
</ul>

<hr>

<h2>🎮 Gameplay / Screenshots</h2>

<p><em>Add screenshots or GIFs here showcasing patrol behavior, player combat, enemy detection, and stun mechanics.</em></p>

<hr>

<h2>🛠️ Technologies Used</h2>

<ul>
  <li><strong>Engine:</strong> Unity</li>
  <li><strong>Language:</strong> C#</li>
  <li><strong>Navigation:</strong> Unity NavMesh</li>
  <li><strong>Animation:</strong> Unity Animator + Mixamo</li>
  <li><strong>3D Modeling:</strong> Blender</li>
  <li><strong>Version Control:</strong> GitHub</li>
</ul>

<hr>

<h2>🧠 Architecture / How It Works</h2>

<h3>DetectionSystem.cs</h3>

<ul>
  <li>Handles enemy vision and player detection.</li>
  <li>Shows or hides the enemy vision area.</li>
  <li>Triggers state transitions when the player enters the detection zone.</li>
</ul>

<h3>CharacterControl.cs</h3>

<ul>
  <li>Controls player attack functionality.</li>
  <li>Processes interactions with the enemy.</li>
  <li>Provides visual feedback when the player receives damage.</li>
</ul>

<h3>EnemyStateMachine.cs</h3>

<ul>
  <li>Core system of the enemy AI architecture.</li>
  <li>Manages state transitions and overall enemy behavior.</li>
  <li>Acts as the central controller connecting all enemy-related systems.</li>
</ul>

<h3>EnemyAnimatorController.cs</h3>

<ul>
  <li>Handles animation requests from the state machine.</li>
  <li>Synchronizes gameplay logic with animation states.</li>
</ul>

<h3>EnemyTriggerAndCollision.cs</h3>

<ul>
  <li>Processes enemy collisions and trigger interactions.</li>
  <li>Detects combat and environmental events.</li>
</ul>

<h3>EnemyAttackState.cs</h3>

<ul>
  <li>Manages attack behavior.</li>
  <li>Controls attack execution and related transitions.</li>
</ul>

<h3>EnemyChaseState.cs</h3>

<ul>
  <li>Handles player pursuit behavior.</li>
  <li>Uses NavMesh navigation to dynamically follow the target.</li>
</ul>

<h3>EnemyDeadState.cs</h3>

<ul>
  <li>Controls enemy death behavior.</li>
  <li>Disables active systems and triggers death animations.</li>
</ul>

<h3>EnemyStunnedState.cs</h3>

<ul>
  <li>Manages vulnerability and stun behavior.</li>
  <li>Applies temporary incapacitation effects.</li>
</ul>

<h3>EnemyWalkState.cs</h3>

<ul>
  <li>Controls patrol routines.</li>
  <li>Moves between assigned waypoints.</li>
  <li>Supports configurable idle times between patrol points.</li>
</ul>

<hr>

<h2>⚙️ Main Interaction Flow</h2>

<pre><code>
Player
   ↓
DetectionSystem
   ↓
EnemyStateMachine
   ↓
Walk → Chase → Attack
         ↓
      Stunned
         ↓
        Dead
</code></pre>

<ul>
  <li>The enemy patrols assigned points until the player is detected.</li>
  <li>Detection triggers a transition from patrol to chase.</li>
  <li>When close enough, the enemy attacks the player.</li>
  <li>Player attacks can stun the enemy and interrupt its behavior.</li>
  <li>State transitions are managed entirely through the FSM architecture.</li>
</ul>

<hr>

<h2>🐞 Known Issues</h2>

<p>No known bugs at the time of writing.</p>

<h2>Bugs Conocidos</h2>

Ninguno hasta la fecha
