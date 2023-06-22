using System;

public static class CharacterSelectionMenu
{
    public static CharacterClass PromptCharacterSelection()
    {
        while(true)
        {
            MessageHelper.DrawTitle("Class Selection", true);
            MessageHelper.AppendMessage(new string[] { "Select your class:", "[1] Warrior", "[2] Archer", "[3] Mage", "[4] Cleric" });
            ConsoleKeyInfo input = MessageHelper.DisplayMessage();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    return CharacterClass.Warrior;
                case ConsoleKey.D2:
                    return CharacterClass.Archer;
                case ConsoleKey.D3:
                    return CharacterClass.Mage;
                case ConsoleKey.D4:
                    return CharacterClass.Cleric;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
