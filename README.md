# Traditional Tails – README

## Overview
"Traditional Tails" is a delightful stacking game that combines the charm of rabbits with diverse traditional outfits from around the world. Players embark on a global adventure, collecting and stacking adorable bunnies in unique cultural costumes. As you progress through various landscapes, the goal is to skillfully stack rabbits without toppling them. Immerse yourself in the endearing world of "Traditional Tails," where bunny fashion meets balance for players of all ages.

## AudioManager
- **Purpose**: Manages game audio.
- **Implementation**: Attached to a GameObject, persists across scenes.
- **Functions**:
  - `Awake()`: Initializes AudioManager and ensures persistence.
  - `PlayMusic()`: Plays background music if not playing.
  - `StopMusic()`: Halts background music.

## BGScrolling
- **Purpose**: Controls scrolling background.
- **Implementation**: Attached to a GameObject with a scrolling sprite.
- **Variables**:
  - `scrollSpeed`: Speed of background scrolling.
  - `tileSizeY`: Height of the background tile.
  - `startPosition`: Initial position of the GameObject.
- **Functions**:
  - `Start()`: Initializes start position.
  - `Update()`: Scrolls background vertically.

## BunnyController
- **Purpose**: Manages player's bunny character.
- **Implementation**: Attached to player's bunny GameObject.
- **Variables**:
  - `moveSpeed`: Horizontal movement speed.
  - `limits`: Movement limits.
  - `State`: Enum representing bunny's state.
  - `rigidbody2D`: Rigidbody component.
  - `bunnySprites`: Array of bunny sprites.
- **Functions**:
  - `Start()`: Initializes the bunny.
  - `Update()`: Handles movement and input.
  - `OnCollisionEnter2D()`: Manages collisions.
  - `StackBunny()`: Stacks bunny on successful collision.
  - `UpdateSprite()`: Randomly updates bunny sprite.

## ButtonController
- **Purpose**: Handles button interactions.
- **Functions**:
  - `LoadNextScene()`: Loads next scene.
  - `QuitGame()`: Quits the game.
  - `RetryGame()`: Restarts the game.

## GameManager
- **Purpose**: Manages game state, scoring, and bunny spawning.
- **Variables**:
  - `scoreText`: Text displaying the score.
  - `bunnyPrefab`: Bunny GameObject prefab.
  - `spawnPoint`: Spawn point for bunnies.
  - `spawnInterval`: Time between spawns.
  - `HasStackedOnGround`: Tracks if a bunny is stacked on the ground.
  - `offset`: Offset for spawning new bunnies.
  - `updatedScore`: ScoreManager for score updates.
- **Functions**:
  - `Start()`: Initializes the game.
  - `SpawnBunny()`: Spawns a new bunny.
  - `BunnyStacked()`: Updates the score on stacking.
  - `GameOver()`: Handles game over logic.

## GameOverManager
- **Purpose**: Manages game over screen and displays scores.
- **Variables**:
  - `gameOverText`: Text displaying "Game Over."
  - `scoreText`: Text displaying the player's score.
  - `highScore`: Text displaying the high score.
- **Functions**:
  - `Start()`: Displays game over information.

## Pivot
- **Purpose**: Handles the stacking pivot rotation.
- **Variables**:
  - `rotationSpeed`: Speed of rotation.
- **Functions**:
  - `Update()`: Rotates the pivot.

## SaveData
- **Purpose**: Saves and loads game scores.
- **Variables**:
  - `filePath`: Path to the save file.
- **Functions**:
  - `Save()`: Saves score data to a JSON file.
  - `Load()`: Loads score data from a JSON file.

## ScoreManager
- **Purpose**: Manages the player's score.
- **Variables**:
  - `scoreText`: Text displaying the player's score.
  - `scoreData`: Struct containing score information.
- **Functions**:
  - `Start()`: Initializes the score manager.
  - `IncreaseScore()`: Increases the player's score.
  - `UpdateScoreText()`: Updates the score text.
  - `OnDestroy()`: Saves the score data when the script is destroyed.

## Scores (Struct)
- **Purpose**: Struct containing score information.
- **Variables**:
  - `score`: Current score.
  - `highScore`: Highest achieved score.
