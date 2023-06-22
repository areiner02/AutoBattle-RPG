using AutoBattle;
using System;
using System.Collections.Generic;

public static class Grid
{
    public static int rows;
    public static int columns;
    public static List<Tile> tileList;

    public static void Setup(int _rows, int _columns)
    {
        rows = _rows;
        columns = _columns;

        tileList = new List<Tile>();

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                Tile tile = new Tile(x, y, false, (columns * x + y));
                tileList.Add(tile);

                Console.WriteLine($"Creating Tile {tile.index}");
            }
        }
        Console.WriteLine("\nThe Battlefield has been created.\n");
    }

    public static Tile GetTile(int x, int y)
    {
        return tileList.Find(tile => tile.x == x && tile.y == y);
    }

    public static void AllocateCharacters()
    {
        List<Character> characterList = CharacterManager.GetInstance().GetCharacterList();
        for (int i = 0; i < characterList.Count; i++)
        {
            int spawnIndex;

            do spawnIndex = RandomHelper.GetRandomInt(0, tileList.Count);
            while (tileList[spawnIndex].occupied);

            Tile spawnTile = tileList[spawnIndex];
            spawnTile.OccupyTile(characterList[i]);

            characterList[i].currentBox = tileList[spawnIndex];
        }
    }

    public static void DrawGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                Tile currentTile = tileList[(columns * x + y)];

                if (currentTile.occupied)
                {
                    Console.ForegroundColor = currentTile.tileColor;
                    Console.Write($"[{currentTile.occupyingCharacter.identifier}]\t");
                }
                else
                {
                    Console.Write($"[ ]\t");
                }
                Console.ResetColor();
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
    }
}