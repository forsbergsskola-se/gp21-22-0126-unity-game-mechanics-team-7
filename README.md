# The Adventures Of Mr. Penguin
Keyboard & Mouse Required
<br>
[PC BUILD](https://drive.google.com/file/d/10WUJPvzceBzQoP0LHAFvGj01eYE6MkGU/view?usp=sharing)
<br>
[MAC BUILD](https://drive.google.com/file/d/1RD-lJZQpFvKksyEIBin0ZrrsPf0RgQpl/view?usp=sharing)

## Game Engineers
- Benjamin Ting
- Jasmine Öhlin
- Oliver Källerfors

## Sound & Music
- Troy Davis
- Robert Larsson

## Mechanics & AI
### Benjamin Ting
- Mechanic: Flight
  - Implementation 1: Propelled Flight. W increases thrust, A & D rotates player. 
  - Implmentation 2: Hover Flight. Hold SPACE to hover, A & D to strafe.
- AI 1: Flying & Bombing Enemy (Chicken)
  - Follows player when in sight range and starts releasing bombs when in attack range.
     - Mechanics Used: Walk Controller(from class), Kill Target(Ben), Bombing(Ben)
- AI 2: Jumping Enemy (Cat)
   - Detects when the player is directly above it and jumps vertically upwards.
     - Mechanics Used: Immedate Jump(from class), Kill Target(Ben)
### Jasmine Öhlin
- Mechanic: Swimming
  - Implementation 1: Regular swimming. W swims up, A swims left, D swims right, S swims down. They can be combinated. Showcased in Level 2.
  - Implementation 2: Geysers automatically adds a push to swimming player, if within range, during it's eruption. Showcased in Level 2.
- AI 1: Baby Penguin
  - Follows player after being "picked up" (swammed over). Needs help getting passed the shark and will die if collision with shark occurs. Will be affected by geyser push.
     - Mechanics Used: Swimming(Jasmine), Geyser(Jasmine), Death(Ben).
- AI 2: Shark
   - Patrols area between two points, only swims horizontal. Kills player and baby penguin on collision.
     - Mechanics Used: Swimming(Jasmine), Kill Target(Ben)
### Oliver Källerfors
- Mechanic: Teleportation
  - Implementation 1: Portal Gun: When portal gun acquired, Left/Right click to shoot a portal to target location which allows you to move from one portal to another.
  - Implmentation 2: Teleport Behind Target: Press E to Teleport behind enemy infront of you and turn so you look at the enemy.
  - Implementation 3: Charged Orb Teleport: Press Shift to summon a teleportation orb and hold down the button to make the orb move in your direction, then when you let go of Shift you teleport to that location.
- AI 1: Ghost Penguin
  - Slowly Follows the player and kills on touch
     - Mechanics Used: Follow Target(Oliver), Kill Target(Ben)
- AI 2: Lion
  - Follows player when in range and tries to pounce behind them and kill the player.
     - Mechanics Used: Teleport Behind Target(Oliver), Follow target(Oliver), Kill Target(Ben)
