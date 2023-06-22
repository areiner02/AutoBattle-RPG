using System;

public static class MainMenu
{
    public static void PromptMainMenu()
    {
        Console.Clear();

        MessageHelper.DrawTitle("Main Menu");
        MessageHelper.AppendMessage(new string[] { "[1] Start Game", "[2] Settings", "[3] Exit" });
        ConsoleKeyInfo input = MessageHelper.DisplayMessage();
        switch (input.Key)
        {
            case ConsoleKey.D1:
                break;
            case ConsoleKey.D2:
                Settings.PromptSettings();
                break;
            case ConsoleKey.D3:
                Console.Clear();
                Console.WriteLine("Thanks for playing! :)");
                Environment.Exit(1);
                break;
            default:
                Console.Clear();
                PromptMainMenu();
                break;
        }
    }
}