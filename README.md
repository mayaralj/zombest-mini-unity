# Zombest Mini, Built in Unity

Small 3D top-down zombie shooter built over a weekend to learn Unity and C#.
Rebuilds the core loop of my Roblox game Zombest [(Github).](https://github.com/mayaralj/Zombest)

Unity 6 LTS, C#.

## Demo
todoo

## Controls
- **WASD:** move
- **Mouse:** aim
- **Hold left click:** shoot
- **R:** restart after game over

## What it does
- WASD movement with mouse aim
- Camera that follows the player
- Bullets fired from a hand-written object pool
- Enemies spawn around the player, chase, and die to bullets
- Two enemy types (Zombie and Fast Zombie) with stats stored in ScriptableObject assets
- Health, score, game over and restart
- Grid floor and invisible boundary walls

## How it's built
| Script | Role |
| --- | --- |
| `PlayerController` | Movement, mouse aim, firing, contact damage |
| `Bullet`, `BulletPool` | Pooled projectiles |
| `Enemy`, `EnemyData` | Chase behaviour, with stats in a ScriptableObject |
| `EnemySpawner` | Timed spawning with an enemy cap |
| `GameManager` | Score, health UI, game over, restart |
| `CameraFollow` | Camera tracks the player |
| `IDamageable` | Interface so bullets can damage anything that implements it |


## What I practiced
- MonoBehaviour lifecycle: `Awake`, `Start`, `Update` vs `FixedUpdate`, `LateUpdate`
- Prefabs and object pooling
- 3D physics: Rigidbody constraints, triggers, layers and the collision matrix (very similar to Roblox collision groups)
- Mouse aim by raycasting onto a ground plane
- Data-driven design with ScriptableObjects
- Interfaces (`IDamageable`) and a static (`GameManager.Instance`)

## What surprised me coming from Roblox
- **C# feels a lot like Java.** Most of what I had to learn was minor syntax and Unity-specific APIs.
- **OOP makes organising a game much easier** than in Luau, which has no native class support (there are workarounds).
- **Creating, destroying and pooling objects** maps almost one-to-one onto how Roblox does it.
- **C# plus Unity felt powerful even at this small scale.** I could use any data structure I needed, such as `Queue<T>` for the pool. In Luau the table is the only built-in structure, so I had to build queues and others by hand.
- **MonoBehaviour scripts keep code organised** and make the order things run in clear.
- **ScriptableObjects let designers tune data**, such as enemy stats, directly in the editor with no code.


## Run it
Open the project in Unity 6 LTS and play `Assets/Scenes/SampleScene`.
