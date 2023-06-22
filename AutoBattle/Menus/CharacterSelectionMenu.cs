using System;

public static class CharacterSelectionMenu
{
    public static CharacterClassType PromptCharacterSelection()
    {
        while(true)
        {
            MessageHelper.DrawTitle("Class Selection", true);
            MessageHelper.AppendMessage(new string[] { "Select your class:", "[1] Warrior", "[2] Archer", "[3] Mage", "[4] Cleric" });
            ConsoleKeyInfo input = MessageHelper.DisplayMessage();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    return CharacterClassType.Warrior;
                case ConsoleKey.D2:
                    return CharacterClassType.Archer;
                case ConsoleKey.D3:
                    return CharacterClassType.Mage;
                case ConsoleKey.D4:
                    return CharacterClassType.Cleric;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
