using System;
using System.Collections.Generic;

public class MatchManager
{
    int round;
    bool matchEnded;
    public bool displayGrid;

    #region SINGLETON
    private MatchManager() { }

    private static MatchManager Instance;

    public static MatchManager GetInstance()
    {
        if (Instance == null) Instance = new MatchManager();
        return Instance;
    }
    #endregion

    public void StartMatch()
    {
        round = 0;
        matchEnded = false;
        displayGrid = true;

        CharacterManager.GetInstance().Setup();
        CharacterManager.GetInstance().ShuffleCharacterList();

        StartTurn();
    }

    private void StartTurn()
    {
        while (!matchEnded)
        {
            List<Character> characterList = CharacterManager.GetInstance().GetCharacterList();

            round++;

            Console.WriteLine($"ROUND {round}:");

            foreach (Character character in characterList)
            {
                character.ChooseTurnAction();
            }

            if (matchEnded) return;

            if (displayGrid)
            {
                Grid.DrawGrid();
                displayGrid = false;
            }

            if (Settings.autoPlay)
            {
                Console.Write(Environment.NewLine);
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                MessageHelper.DrawInstruction("Press any key to continue...");
            }
        }
    }

    public void EndMatch(Team winnerTeam)
    {
        matchEnded = true;

        Console.Write(Environment.NewLine);
        MessageHelper.DrawTitle($"{winnerTeam.name} Team Wins!");
        foreach (Character character in winnerTeam.memberList)
        {
            Console.WriteLine($"* {character.name}");
        }
        MessageHelper.DrawInstruction("Press any key to continue...");
    }

    public void CharacterDied(Character deadCharacter)
    {
        TeamManager.GetInstance().MemberDied(deadCharacter);
    }
}