using System;

public class Tile
{
    public int x;
    public int y;
    public int index;
    public bool occupied;
    public Character occupyingCharacter;
    public ConsoleColor tileColor;

    public Tile(int x, int y, bool occupied, int index)
    {
        this.x = x;
        this.y = y;
        this.occupied = occupied;
        this.index = index;
    }

    public void OccupyTile(Character occupyingCharacter)
    {
        this.occupyingCharacter = occupyingCharacter;
        occupied = true;

        switch (occupyingCharacter.team.teamSide)
        {
            case TeamSide.BLUE:
                tileColor = ConsoleColor.Blue;
                break;
            case TeamSide.RED:
                tileColor = ConsoleColor.Red;
                break;
        }
    }

    public void EmptyTile()
    {
        occupied = false;
        occupyingCharacter = null;
    }
}