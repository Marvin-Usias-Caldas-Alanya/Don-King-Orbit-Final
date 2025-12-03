# Donkey Kong Level 1 Remake

A Unity recreation of the first level from the classic arcade game Donkey Kong, featuring authentic platforming mechanics, ladder climbing, and rolling barrel obstacles.

> **Play the game here:** [Link to game](https://adeoja.itch.io/donkey-kong-remake)

<img width="600" height="375" alt="Screenshot 2025-10-21 144642" src="https://github.com/user-attachments/assets/20828c13-9231-402e-b64f-9688055e5d62" />


## 📚 About This Project
This project was created for my second Game Scripting course assignment which focused on recreating a classic arcade game. The assignment challenged students to reverse-engineer authentic game mechanics and replicate the original game's feel as closely as possible.

**Assignment Requirements:**
- Recreate an existing arcade game with defined win/lose conditions
- Match the original's movement speed, acceleration, and handling
- Replicate UI styling
- Implement 4-5 core Unity systems covered in class (e.g. Vectors, Rigidbodies, Prefabs/Instantiation, Camera Movement, SceneManagement, Animations and UI)

**My Implementation:**
I chose to recreate the iconic first level of Donkey Kong (1981). This project demonstrates the use of several key systems:
- **Vectors** - Movement calculations and direction handling  
-  **Rigidbodies** - Physics-based player and barrel movement  
- **Objects, Prefabs, and Instantiation** - Dynamic barrel spawning system  
- **Scene Management** - Main menu, gameplay, and game over flow  
- **UI** - Score display and lives tracking with retro formatting  

The focus was on capturing the precise feel of the original arcade mechanics, particularly the ladder climbing system and barrel physics that made Donkey Kong's gameplay so memorable.

---

## 🎮 Gameplay Features

### Core Mechanics
- **Classic Platforming** - Authentic 2D movement with jumping and precise controls
- **Ladder Climbing System** - Climb up and down ladders with dynamic platform collision
- **Barrel Obstacles** - Randomly spawned barrels that roll down platforms
- **Lives System** - Start with 3 lives, respawn on death until game over
- **Score Tracking** - Earn points by progressing through the level and reaching the goal
- **High Score Persistence** - Track your best performance across game sessions

### Controls

| Input | Action |
|-------|--------|
| **A/D** or **Arrow Keys** | Move left/right |
| **W/S** or **Up/Down** | Climb ladders |
| **Space** | Jump |

### Scoring System

- **100 points** - Passing score triggers throughout the level
- **1000 points** - Reaching the finish line (princess)
- **High Score** - Automatically saved and displayed on game over

---

## 🏗️ Technical Architecture

### Design Patterns
- **Singleton Pattern** - Global access for core managers (GameManager, UIManager)
- **Component-Based Design** - Modular scripts for easy maintenance
- **Physics-Based Movement** - Rigidbody2D for realistic player and barrel physics

### Key Systems

#### Player Controller
**Features include:**
- Raycast-based ground detection for accurate jumping
- Sprite flipping based on movement direction
- Physics-based jump mechanics with configurable force
- Dynamic platform collision during ladder climbing
- Respawn system with position reset on death

#### Ladder Climbing System
**Innovative collision handling:**
- Gravity disabled when climbing ladders
- Smart platform collision toggling (ignore collisions when descending)
- Smooth vertical movement with configurable climb speed
- Automatic gravity restoration when leaving ladders
- Static position holding when idle on ladder

#### Barrel Spawning System
**Dynamic obstacle generation:**
- Random spawn intervals for unpredictable gameplay
- Barrels follow platform slopes using transform.right vector
- Automatic barrel cleanup on player death
- List-based tracking of all active barrels
- Trigger-based destruction at map boundaries

#### Game Management
**Core systems:**
- Persistent GameManager across scenes using DontDestroyOnLoad
- Lives tracking with UI updates
- Score accumulation with formatted display (00000 format)
- Win/lose state detection
- Scene management for main menu, gameplay, and game over

---

## 📁 Project Structure

```
Scripts/
├── Player.cs                 # Player movement, jumping, and ladder climbing
├── Barrel.cs                 # Barrel physics and platform following
├── BarrelSpawner.cs          # Random barrel spawning and cleanup
├── GameManager.cs            # Score, lives, and scene management
├── UIManager.cs              # Score and lives display formatting
├── GameOverUI.cs             # End screen with win/lose states
└── MainMenu.cs               # Main menu scene navigation
```

---

## 🛠️ Technologies Used
- **Engine:** Unity 6000.0.56f1

---

## 🎯 Core Features Showcase

### Ladder Mechanics
The ladder climbing system dynamically toggles platform collisions, allowing players to descend through platforms while preventing unwanted falls when climbing up.

### Smart Barrel Physics
Barrels automatically follow platform angles using the platform's transform.right vector, creating smooth downhill rolling motion without hardcoded paths.

### Singleton Architecture
GameManager persists across all scenes, maintaining score and lives data from gameplay through to the game over screen.

---

## 📝 Code Highlights

- **Clean Architecture** - Well-organized, commented code with clear separation of concerns
- **Efficient Collision Detection** - Uses raycast for ground detection instead of expensive continuous collision checks
- **Dynamic Platform Interaction** - Smart collision ignoring system for seamless ladder descents
- **List Management** - Proper instantiation tracking and cleanup for spawned objects
- **Scene Persistence** - DontDestroyOnLoad pattern for data preservation across scenes

---

## 🔮 Future Enhancements

Potential features for expansion:

- [ ] Additional levels (25m, 50m, 75m, 100m stages)
- [ ] Hammer power-up for destroying barrels
- [ ] Donkey Kong animation and barrel throwing
- [ ] Animated sprites for Mario
- [ ] Sound effects and music
- [ ] Difficulty progression (faster barrels at higher levels)
