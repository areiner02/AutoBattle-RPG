using System;

public static class Settings
{
    public static string playerName = "Player";
    public static int gridRows = 5;
    public static int gridColumns = 5;
    public static int characterAmount = 2;
    public static bool autoPlay;

    private static bool invalidInput;

    public static void PromptSettings()
    {
        Console.Clear();

        MessageHelper.DrawTitle("Settings");
        MessageHelper.AppendMessage(new string[] { $"[1] Change Player Name [{playerName}]", $"[2] Change Battlefield settings [Width = {gridColumns}, Height = {gridRows}]", $"[3] Change Game Mode [{characterAmount / 2}vs{characterAmount / 2}]", $"[4] Change Autoplay mode [{autoPlay}]", "[5] Back to Main Menu" });
        ConsoleKeyInfo input = MessageHelper.DisplayMessage();
        switch (input.Key)
        {
            case ConsoleKey.D1:
                NameSettings();
                break;
            case ConsoleKey.D2:
                GridSettings();
                break;
            case ConsoleKey.D3:
                GameModeSettings();
                break;
            case ConsoleKey.D4:
                AutoplaySettings();
                break;
            case ConsoleKey.D5:
                MainMenu.PromptMainMenu();
                break;
            default:
                Console.Clear();
                PromptSettings();
                break;
        }
    }

    public static void NameSettings()
    {
        Console.Clear();

        MessageHelper.DrawTitle("Name Settings");
        Console.WriteLine("Write your name:");
        playerName = Console.ReadLine();

        PromptSettings();
    }

    public static void GridSettings()
    {
        Console.Clear();

        MessageHelper.DrawTitle("Battlefield Settings");

        if (invalidInput)
        {
            Console.WriteLine("Write a valid positive integral number.");
            invalidInput = false;
        }

        Console.WriteLine("Set Battlefield's WIDTH (Max. 25):");
        string widthInput = Console.ReadLine();
        try
        {
            gridColumns = int.Parse(widthInput) > 25 ? 25 : int.Parse(widthInput);
        }
        catch
        {
            invalidInput = true;
            GridSettings();
            return;
        }

        Console.WriteLine("Set Battlefield's HEIGHT (Max. 25):");
        string heightInput = Console.ReadLine();
        try
        {
            gridRows = int.Parse(heightInput) > 25 ? 25 : int.Parse(heightInput);
        }
        catch
        {
            invalidInput = true;
            GridSettings();
            return;
        }

        PromptSettings();
    }

    private static void GameModeSettings()
    {
        Console.Clear();

        MessageHelper.DrawTitle("Game Mode");
        MessageHelper.AppendMessage(new string[] { $"[1] 1vs1", $"[2] 2vs2", $"[3] 3vs3" });
        ConsoleKeyInfo input = MessageHelper.DisplayMessage();
        switch (input.Key)
        {
            case ConsoleKey.D1:
                characterAmount = 2;
                break;
            case ConsoleKey.D2:
                characterAmount = 4;
                break;
            case ConsoleKey.D3:
                characterAmount = 6;
                break;
            default:
                GameModeSettings();
                break;
        }

        PromptSettings();
    }

    public static void AutoplaySettings()
    {
        Console.Clear();

        MessageHelper.DrawTitle("Autoplay Mode");
        Console.WriteLine("Autoplay Mode makes the battle continuous.");

        if (invalidInput)
        {
            Console.WriteLine("Write \"Y\" to enable or \"n\" to disable it.");
            invalidInput = false;
        }

        ConsoleKeyInfo input = MessageHelper.DisplayMessage("Enable Autoplay? \"Y/n\"");
        switch (input.Key)
        {
            case ConsoleKey.Y:
                autoPlay = true;
                break;
            case ConsoleKey.N:
                autoPlay = false;
                break;
            default:
                invalidInput = true;
                AutoplaySettings();
                return;
        }

        PromptSettings();
    }
}