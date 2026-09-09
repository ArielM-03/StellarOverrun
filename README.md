# Stellar Overrun

Stellar Overrun is a 2D top-down survival shooter developed in Unity 6 and C#. Players select between two playable characters and survive increasingly difficult waves of enemies while gaining experience, leveling up, and selecting upgrades throughout each run.

The game was developed from January to May 2026 as the final project for a university Game Development course. The project focused on building a complete gameplay loop while applying object-oriented programming, Unity's component-based architecture, event-driven input, physics-based movement, and gameplay system design.

## Gameplay

Players move through an enclosed arena while their equipped weapon automatically targets nearby enemies. Defeating enemies awards experience, with progression increasing enemy difficulty and periodically presenting the player with upgrades.

Two playable characters provide different combat styles:

- **Alice** uses a faster automatic weapon that targets and fires toward the nearest enemy.
- **Nova** uses a slower shotgun-style weapon that fires a three-projectile spread.

The game includes three enemy archetypes with different behaviors and attributes:

- **Drone** — A faster standard enemy that pursues the player.
- **Tank** — A slower enemy with increased health.
- **Queen** — A stronger support enemy capable of temporarily increasing the movement speed of nearby enemies.

## Features

- Two playable characters with distinct weapon mechanics
- Automatic nearest-enemy targeting and projectile-based combat
- Three enemy archetypes with different movement, health, and support characteristics
- Experience and level progression system
- Periodic upgrade selection for fire rate, movement speed, and player health
- Increasing enemy difficulty as the player progresses
- Enemy spawning and wave management
- Player health, damage, and game-over systems
- Main menu, character selection, gameplay, and restart flow
- Runtime HUD for health, experience, level progression, and upgrades

## Technical Implementation

Stellar Overrun was built using:

- **C#**
- **Unity 6**
- **Universal Render Pipeline (URP)**
- **Unity Input System**
- **Rigidbody2D physics**
- **Unity Canvas UI**
- **TextMeshPro**
- **Git and GitHub**

Player input is handled through Unity's Input System using callback-based action mapping, while movement is performed through `Rigidbody2D` during the physics update cycle.

Combat systems automatically locate nearby enemies and calculate projectile trajectories based on the selected character's weapon. Nova's shotgun weapon uses vector rotation to generate its three-projectile spread, while Alice's weapon automatically fires toward the nearest available target.

Enemy behavior is separated across individual components. Standard enemies pursue the player, while the Queen enemy introduces an area-of-effect support mechanic that temporarily increases the movement speed of nearby enemies.

Progression is managed through experience, leveling, enemy difficulty scaling, and periodic upgrade selection. Game-state systems coordinate gameplay flow, pausing, time scaling, player death, and transitions between scenes.

## Project Structure

The Unity project separates major gameplay responsibilities into dedicated directories and components:

- `Combat` — weapon, projectile, health, and damage behavior
- `Enemies` — enemy movement and specialized enemy behavior
- `Player` — player movement and character behavior
- `Systems` — game state, spawning, experience, progression, and upgrades
- `UI` — menus, HUD elements, character selection, and game-over interfaces
- `Prefabs` — reusable player, enemy, projectile, and gameplay objects
- `Scenes` — main menu, character selection, and gameplay scenes

This structure was used to keep individual gameplay responsibilities separated as the project expanded throughout development.

## Development

Stellar Overrun was developed as a semester-long Game Development final project from January to May 2026.

The project provided hands-on experience designing and integrating multiple interacting gameplay systems in Unity, including player input, physics-based movement, combat, enemy behavior, progression, UI, scene management, and game-state control.

Source control and version management were handled using Git and GitHub throughout development.
