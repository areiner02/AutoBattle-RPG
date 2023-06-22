using System;
using System.Collections.Generic;

public class Character
{
    public string name;
    public CharacterClass characterClass;
    public int playerIndex;

    public float health;
    public int damage;
    public float damageMultiplier;
    public bool isDead;

    public Tile currentBox;
    public Character target = null;
    public List<Tile> movementList = new List<Tile>();

    public Team team;
    public List<Character> allyList = new List<Character>();
    public List<Character> enemyList = new List<Character>();

    public Character(int index, string name, CharacterClass characterClass)
    {
        this.playerIndex = index;
        this.name = name;
        this.characterClass = characterClass;
    }

    public void Setup()
    {
        health = 100;
        damage = 20;

        FindTarget();
    }

    public void ChooseTurnAction()
    {
        if (isDead) return;

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
        if (currentBox.index > Grid.columns && currentBox.x == target.currentBox.x && currentBox.y == target.currentBox.y - 1) return true;
        if (currentBox.index < Grid.tileList.Count - Grid.columns && currentBox.x == target.currentBox.x && currentBox.y == target.currentBox.y + 1) return true;
        if (currentBox.index > 0 && currentBox.x == target.currentBox.x - 1 && currentBox.y == target.currentBox.y) return true;
        if (currentBox.index < Grid.tileList.Count - 1 && currentBox.x == target.currentBox.x + 1 && currentBox.y == target.currentBox.y) return true;

        return false;
    }

    private void MoveTowardTarget()
    {
        string direction = "";

        if (currentBox.x > target.currentBox.x) direction = "up";
        if (currentBox.x < target.currentBox.x) direction = "down";
        if (currentBox.y > target.currentBox.y) direction = "left";
        if (currentBox.y < target.currentBox.y) direction = "right";

        Grid.tileList[currentBox.index].EmptyTile();

        switch (direction)
        {
            case "up":
                currentBox = Grid.tileList[currentBox.index - Grid.columns];
                break;
            case "down":
                currentBox = Grid.tileList[currentBox.index + Grid.columns];
                break;
            case "left":
                currentBox = Grid.tileList[currentBox.index - 1];
                break;
            case "right":
                currentBox = Grid.tileList[currentBox.index + 1];
                break;
        }

        Grid.tileList[currentBox.index].OccupyTile(this);

        Console.ForegroundColor = team.color;
        Console.WriteLine($"({team.name}) {name} moved {direction}.");
        Console.ResetColor();
    }

    public void Attack()
    {
        int randomDamage = RandomHelper.GetRandomInt(0, damage);
        Console.ForegroundColor = team.color;
        Console.WriteLine($"({team.name}) {name} attacked {target.name} dealing {randomDamage} damage");
        Console.ResetColor();

        target.TakeDamage(randomDamage);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    public void Die()
    {
        Console.ForegroundColor = team.color;
        Console.WriteLine($"({team.name}) {name} died.");
        Console.ResetColor();

        Grid.tileList[currentBox.index].EmptyTile();

        isDead = true;

        MatchManager.GetInstance().displayGrid = true;
        MatchManager.GetInstance().CharacterDied(this);
    }
}