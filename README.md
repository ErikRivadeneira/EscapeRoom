# Escape Room Prototype

Escape Room is a 3D puzzle prototype focused on **interaction systems**, **modular puzzle design**, and **player-driven progression**.

The project explores how a consistent interaction model can support multiple puzzle types while maintaining **clarity**, **predictability**, and **extensibility**.

## Project Status
This prototype is complete and maintained as a **portfolio project** demonstrating interaction system design and modular gameplay structure.

## Overview
The player interacts with the environment through a unified **interaction system** combined with **inventory-based progression**.

Objects in the environment can be examined, collected, or used depending on context. Progression is driven by applying items and interactions correctly to solve puzzles.

The system is **deterministic**, ensuring consistent outcomes for the same inputs. This supports player understanding and reduces ambiguity.

## Core Design Goals
* Build a **modular interaction system** supporting multiple object types  
* Ensure **consistency** across all player interactions  
* Enable puzzle design through **reusable systems**  
* Maintain **clear feedback** for player actions  
* Keep systems **extensible and scalable**  

## Systems Overview

### Player Systems
The player is structured around core systems responsible for movement, interaction, and inventory management.

### Interaction System
Handles detection and execution of interactions using a shared interface.

* All interactive objects implement a common **interaction contract**  
* Ensures consistent behavior across different object types  
* Decouples interaction logic from object-specific implementations  

### Inventory System
Manages collected items and enables their use in puzzle-solving.

* Stores and tracks item state  
* Integrates with interaction logic for progression  
* Supports item-based puzzle validation  

### Puzzle Systems
Multiple puzzle types are implemented using shared interaction rules.

* **Combination puzzles** require correct input sequences  
* **Object-based puzzles** require correct item usage  
* **Pattern-based puzzles** rely on environmental logic  

Each puzzle type reuses the same interaction framework to maintain **consistency and scalability**.

### Environment Interaction
Objects in the environment either:

* Provide items  
* React to player input  
* Validate progression conditions  

All behaviors are defined through shared interaction logic to ensure **predictable and reusable behavior**.

## Architecture

The project follows a **system-driven architecture** centered around interaction abstraction and modular components.

* **Interface-based design** enables extensible interaction behaviors across all objects  
* **Separation of systems** between movement, interaction, and inventory reduces coupling  
* **Puzzle logic** is built on top of shared systems rather than isolated implementations  
* **Centralized interaction flow** ensures consistent validation and execution of player actions  

This structure allows new puzzles and interactable objects to be added without modifying core systems.

## Implementation Notes

* Interaction logic is abstracted through **interfaces** for flexibility and reuse  
* Player functionality is divided into **distinct systems** (movement, interaction, inventory)  
* Puzzle behavior is **modular and reusable** across different scenarios  
* **ScriptableObjects** are used for input configuration and system flexibility  

## Ownership and Credits

Developed as part of a **collaborative academic project**.

* **Erik Rivadeneira** — gameplay systems, programming, UI implementation, localization, and puzzle design  
* Level Design — Cristopher Holguín  
* Music — Phat Phrog Studios  
* Original concept — Alex Ávila, César López, Cristopher Holguín  
* Art assets — sourced from Unity Asset Store and TurboSquid  

## Constraints
The project was developed within a **limited timeframe** as part of a graduate-level assignment.

This resulted in:

* A **focused set of systems**  
* Reuse of interaction logic across puzzles  
* Emphasis on **structure over content volume**  

## Key Takeaways

* **Modular interaction systems** enable scalable puzzle design  
* **Interfaces** support consistent and extensible object behavior  
* Combining simple systems creates **varied gameplay scenarios**  
* **Deterministic systems** improve learnability and player trust  
