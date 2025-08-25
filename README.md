# Superintelligence Prototype
This is an experimental Unity prototype about managing the rise of an artificial superintelligence. It is designed to be a fast, turn-based strategy game:
each turn, the player makes a choice and watches how that choice affects the AI's behavior and the player's score. The player must try to manage the rise of 
the AI by balancing its power and alignment while responding to its unpredictable actions. The goal is to use the game to convey the challenges, tradeoffs,
risks, and possibilities inherent in artificial intelligence development.

**Available for playtesting at:** https://jzl3.itch.io/superintelligence-prototype

## Gameplay
- The game spans up to 50 turns. Designed to be played in about ~5 minutes.
- The game tracks the player's score as well as the AI's power and alignment.
- Each turn the player may:
  - **Add Compute** – increase power with a small chance to lower alignment.
  - **Enhance Alignment** – improve alignment with a small chance to lower power.
  - **Attempt Shutdown** – try to disable the AI entirely.
  - **Do Nothing** – pass the turn.
- After each player action, the AI has a chance to take an action. These actions affect the player's score and can be either positive or negative, minor or
  significant.
- At the end of each turn, there is also a chance that a special event will occur. The player is presented with multiple possible responses to each special
  event, and the way they choose to respond can affect their score as well as the AI's power and alignment.
- Players can use the points they earn to purchase items from the Shop. These items can further influence the AI's behavior.
- After 50 turns, the endgame is triggered. If the AI is sufficiently powerful, the player can choose to attempt one final powerup that has the potential to
  bring about a utopian singularity. However, if the AI is not sufficiently well aligned, attempting this can lead to a doomsday event instead.

## Additional Features
- SoundFX and background music created by me using Logic Pro.
- Background art created by ChatGPT.

## Controls
- **Mouse/Keyboard** - click buttons to choose an action each turn (and to choose a response to special events that occur), click shop button to open the shop
  and purchase items.

## Tech Stack
- Built with Unity.
- Language breakdown: ShaderLab ~46%, C# ~31.5%, HTML ~10.2%, HLSL ~9.5%, CSS ~2.8%.
- Logic Pro for SoundFX and background music.
- ChatGPT for background art.

## Project Structure
```text
.
├─ Assets/                      # Game content (scenes, scripts, art, audio)
├─ BasicTurnFramework/          # Core turn-loop scaffolding
├─ Packages/                    # Unity package/manifest files
├─ ProjectSettings/             # Unity project configuration
├─ TestWebBuild*/               # WebGL playtest builds (e.g., TestWebBuild, TestWebBuild3)
├─ *.wav                        # Sound effects (shutdown, alignment, doomsday, etc.)
└─ SuperintelligenceBackgroundMusic.logicx  # Music source project
```

## Screenshots
<img width="895" height="599" alt="Screenshot 2025-08-24 at 4 47 13 PM" src="https://github.com/user-attachments/assets/e565257e-bd33-4b95-965e-577d6445fa3c" />
<img width="951" height="606" alt="Screenshot 2025-08-24 at 4 49 15 PM" src="https://github.com/user-attachments/assets/38f08660-a20f-4d01-94f6-7d69dec3907d" />
<img width="948" height="585" alt="Screenshot 2025-08-24 at 4 50 20 PM" src="https://github.com/user-attachments/assets/97b25fa8-9562-49a4-bc6f-3d9a0cc2bf31" />

## Ideas for Future Improvements
This is a small, rough prototype, and there are a number of ways it could be fleshed out more. Adding more actions for the player to take to affect the behavior of 
the AI, more nuanced logic for determining the AI's behavior, and more in-depth descriptions of how the AI is interacting with the broader world are all improvements
that could significantly enhance the game. 

It might also be fun to allow the player the ability to customize their AI's appearance. Adding support for multiplayer 
would also be great because it would simulate the challenges that AI companies face as they try to balance ethical considerations with the need to keep up with their
competition.

## License
- No license file is currently present. Treat this as all rights reserved unless a license is added. If you plan to fork/distribute, please open an issue to discuss.


