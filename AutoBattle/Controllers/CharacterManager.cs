using System;
using System.Collections.Generic;

public class CharacterManager
{
    Character playerCharacter;
    List<Character> npcCharacters;

    List<Character> matchCharacterList;

    int identifierCount = 0;
    int identifierIndex = 0;
    char[] identifierArray = new char[3] { '+', '*', '=' };

    #region SINGLETON
    private CharacterManager() { }

    private static CharacterManager Instance;

    public static CharacterManager GetInstance()
    {
        if (Instance == null) Instance = new CharacterManager();
        return Instance;
    }
    #endregion

    public void Init()
    {
        playerCharacter = null;
        npcCharacters = new List<Character>();
        matchCharacterList = new List<Character>();

        playerCharacter = InstantiateCharacter(CharacterSelectionMenu.PromptCharacterSelection(), Settings.playerName);
        for (int i = 1; i < Settings.characterAmount; i++)
        {
            npcCharacters.Add(InstantiateCharacter((CharacterClassType)RandomHelper.GetRandomInt(1, 5), $"CPU {matchCharacterList.Count}"));
        }
    }

    public void Setup()
    {
        foreach(Character character in matchCharacterList)
        {
            character.Setup();
        }
    }

    private Character InstantiateCharacter(CharacterClassType characterClass, string name)
    {
        Character character = new Character(matchCharacterList.Count, name, characterClass);

        matchCharacterList.Add(character);

        return character;
    }

    public List<Character> GetCharacterList()
    {
        return matchCharacterList;
    }

    public void ShuffleCharacterList()
    {
        matchCharacterList = RandomHelper.ShuffleList(matchCharacterList);
        for(int i = 0; i < matchCharacterList.Count; i++)
        {
            matchCharacterList[i].identifier = identifierArray[identifierIndex];

            identifierCount++;
            if(identifierCount == 2)
            {
                identifierIndex++;
                identifierCount = 0;
            }
        }
    }
}