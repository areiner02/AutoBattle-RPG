using System;
using System.Collections.Generic;

public static class PrematchMenu
{
    public static void PrintPrematchInformations()
    {
        List<Character> characterList = CharacterManager.GetInstance().GetCharacterList();

        MessageHelper.DrawTitle("War Information", true);

        foreach (Character character in characterList)
        {
            Console.ForegroundColor = character.team.color;
            Console.WriteLine($"({character.team.name}) {character.name} selected {character.characterClassType}");
            Console.ResetColor();
        }

        MessageHelper.DrawTitle("Battlefield");
        Grid.DrawGrid();

        MessageHelper.DisplayMessage("\nPress ENTER to continue...");

        Console.Clear();
    }
}