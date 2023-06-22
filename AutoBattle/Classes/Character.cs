using System;
using System.Collections.Generic;

public class Character
{
    public string name;
    public CharacterClassType characterClassType;
    public CharacterClass characterClass;
    public int playerIndex;
    public char identifier;

    public int health;
    public int mana;
    public int damage;
    public bool isStunned;
    public bool isDead;
    
    public Tile currentBox;
    public Character target = null;
    public List<Tile> movementList = new List<Tile>();

    public Team team;
    public List<Character> allyList = new List<Character>();
    public List<Character> enemyList = new List<Character>();
    
    List<StatusEffect.effectDelegate> statusEffectList = new List<StatusEffect.effectDelegate>();
    List<StatusEffect.effectDelegate> unsubscribeBuffer = new List<StatusEffect.effectDelegate>();

    public Character(int index, string name, CharacterClassType characterClassType)
    {
        this.playerIndex = index;
        this.name = name;
        this.characterClassType = characterClassType;
        switch (characterClassType)
        {
            case CharacterClassType.Warrior:
                characterClass = new Warrior();
                break;
            case CharacterClassType.Archer:
                characterClass = new Archer();
                break;
            case CharacterClassType.Mage:
                characterClass = new Mage();
                break;
            case CharacterClassType.Cleric:
                characterClass = new Cleric();
                break;
        }
    }

    public void Setup()
    {
        health = characterClass.baseHealth;
        damage = characterClass.baseDamage;
        mana = 0;
        statusEffectList = new List<StatusEffect.effectDelegate>();
        isStunned = false;
        isDead = false;

        FindTarget();
    }

    public void ChooseTurnAction()
    {
        CheckStatusEffect();

        if (isDead || isStunned) return;

        if (target == null || target.isDead) FindTarget();

        if (CheckCloseTarget())
        {
            Attack();
        }
        else
        {
            MoveTowardTarget();
            MatchManager.GetInstance().displayGrid = true;
        }

        int randomMana = RandomHelper.GetRandomInt(characterClass.manaRecovery - (int)Math.Floor((decimal)characterClass.manaRecovery / 2), characterClass.manaRecovery);
        mana += randomMana;
    }

    private void FindTarget()
    {
        float nearestEnemyDistance = float.MaxValue;
        foreach (Character enemy in enemyList)
        {
            float distance = Math.Abs(currentBox.x - enemy.currentBox.x) + Math.Abs(currentBox.y - enemy.currentBox.y);
            if (distance < nearestEnemyDistance)
            {
                nearestEnemyDistance = distance;
                target = enemy;
            }
        }
    }

    bool CheckCloseTarget()
    {
        List<Tile> adjascentTiles = new List<Tile>();
        for(int i = 1; i <= characterClass.attackRange; i++)
        {
            int up = currentBox.index - (i * Grid.columns);
            int down = currentBox.index + (i * Grid.columns);
            int right = currentBox.index + i;
            int left = currentBox.index - i;

            if (up > 0 && up < Grid.tileList.Count && currentBox.index > Grid.columns) adjascentTiles.Add(Grid.tileList[up]);
            if (down > 0 && down < Grid.tileList.Count && currentBox.index < Grid.tileList.Count - Grid.columns) adjascentTiles.Add(Grid.tileList[down]);
            if (right > 0 && right < Grid.tileList.Count && (currentBox.index + 1) % Grid.columns != 0) adjascentTiles.Add(Grid.tileList[right]);
            if (left > 0 && left < Grid.tileList.Count && currentBox.index % Grid.columns != 0) adjascentTiles.Add(Grid.tileList[left]);
        }

        foreach(Tile tile in adjascentTiles)
        {
            if (tile.occupyingCharacter == target) return true;
        }

        return false;
    }

    private void MoveTowardTarget()
    {
        Tile targetTile = null;
        string direction = "";

        if (currentBox.x > target.currentBox.x)
        {
            targetTile = Grid.tileList[currentBox.index - Grid.columns];
            direction = "up";
        }
        if (currentBox.x < target.currentBox.x)
        {
            targetTile = Grid.tileList[currentBox.index + Grid.columns];
            direction = "down";
        }
        if (currentBox.y < target.currentBox.y)
        {
            targetTile = Grid.tileList[currentBox.index + 1];
            direction = "right";
        }
        if (currentBox.y > target.currentBox.y)
        {
            targetTile = Grid.tileList[currentBox.index - 1];
            direction = "left";
        }

        if (targetTile.occupied) return;

        Grid.tileList[currentBox.index].EmptyTile();
        Grid.tileList[targetTile.index].OccupyTile(this);
        currentBox = targetTile;

        Console.ForegroundColor = team.color;
        Console.WriteLine($"({identifier}) {name} moved {direction}.");
        Console.ResetColor();
    }

    public void Attack()
    {
        if (mana >= 100)
        {
            characterClass.skillImplementation(this, target);
            mana = 0;
        }
        else
        {
            int randomDamage = RandomHelper.GetRandomInt(0, damage);
            Console.ForegroundColor = team.color;
            Console.WriteLine($"({identifier}) {name} attacked {target.name} dealing {randomDamage} damage");
            Console.ResetColor();

            target.TakeDamage(randomDamage);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !isDead) Die();
    }

    public void Heal(int amount)
    {
        health += Math.Clamp(amount, 0, characterClass.baseHealth);
    }

    public void Stun(bool isStunned)
    {
        this.isStunned = isStunned;
    }

    public void SubscribeStatusEffect(StatusEffect.effectDelegate effectImplementation)
    {
        UnsubscribeStatusEffect(effectImplementation);

        statusEffectList.Add(effectImplementation);
    }

    public void UnsubscribeStatusEffect(StatusEffect.effectDelegate effectImplementation)
    {
        if (statusEffectList.Contains(effectImplementation)) unsubscribeBuffer.Add(effectImplementation);
    }

    private void CheckStatusEffect()
    {
        if(statusEffectList.Count > 0)
        {
            foreach(StatusEffect.effectDelegate statusEffect in statusEffectList)
            {
                statusEffect(this);
            }
        }

        foreach (StatusEffect.effectDelegate statusEffect in unsubscribeBuffer) statusEffectList.Remove(statusEffect);
    }

    public void Die()
    {
        Console.ForegroundColor = team.color;
        Console.WriteLine($"({identifier}) {name} died.");
        Console.ResetColor();

        Grid.tileList[currentBox.index].EmptyTile();

        isDead = true;

        MatchManager.GetInstance().displayGrid = true;
        MatchManager.GetInstance().CharacterDied(this);
    }
}
