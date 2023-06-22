# Auto Battle RPG
This is a console auto-battle RPG that features a grid-based battlefield and four different classes.

### Basic Mechanics:
* All the Characters will be randomly allocated in the world.
* It's only possible to have one Character per tile.
* The damage dealt by a Character is randomized between *zero* and the Character Class' **Damage**.
* The mana recovery will happen each turn being the amount of mana to be recovery also randomized between *zero* and the Character Class' **Mana per round**.
* The game will end when a team is wiped.

### Settings:
* ***Change Player name:*** Change the name displayed in the *Match* action messages.
* ***Change Battlefield settings:*** Determine the **Grid** layout based on the value of **Width** and **Height** informed.
* ***Change Game Mode:*** Set the number of **Characters** in a match. **(1vs1, 2vs2, 3vs3)**
* ***Change Autoplay mode:*** Makes the action list scroll automatically when playing a match.

### Classes overview:
* ***Warrior***  - An offensive melee featuring a **Stab** ability that cause **Bleeding** *Status Effect* against the opponents.
* ***Archer***  - A ranged class that attack the opponents that are one tile away. Performs a **Triple Shot** special ability that cause a lot of damage and applies **Bleeding** as *Status Effect*.
* ***Mage***  - A melee medium class featuring the **Ice Chamber** ability which **Stun** the opponents for multiple rounds and also deal damage.
* ***Cleric*** - A defensive meele class that can auto **Heal** guaranteeing a persistent *Healing Aura* as *Status Effect*.

### Class details:
* Warrior:
  - *Max Health*: 220
  - *Damage*: 20
  - *Mana per round*: 20
  - *Attack range*: 1 tile
  - *Skill*: Stab
* Archer:
  - *Max Health*: 160
  - *Damage*: 30
  - *Mana per round*: 35
  - *Attack range*: 2 tiles
  - *Skill*: Triple Shot
* Mage:
  - *Max Health*: 150
  - *Damage*: 20
  - *Mana per round*: 20
  - *Attack range*: 1 tile
  - *Skill*: Ice Chamber
* Cleric:
  - *Max Health*: 250
  - *Damage*: 15
  - *Mana per round*: 15
  - *Attack range*: 1 tile
  - *Skill*: Health

### Class customization:
* Its possible to Customize the ***Character Class*** by changing values inside the *Data>CharacterClasses* folder.
  - `baseHealth`: The starter and maximum health of the class.
  - `baseDamage`: The maximum achieved damage when hitting an opponent.
  - `manaRecovery`: The maximum mana recovery in one round.
  - `attackRange`: The tile distance that this class attacks.
#### Example:
```
public class Warrior : CharacterClass
{
    public Warrior() 
    {
        baseHealth = 220;
        baseDamage = 20;
        manaRecovery = 20;
        attackRange = 1;
    }
}
```

### Possible improvements:
* Implementation of **A*** pathfinder algorithm to improve Character navigation.
* Implement dynamic Character Selection menu containing all the Character Classes in the project.
