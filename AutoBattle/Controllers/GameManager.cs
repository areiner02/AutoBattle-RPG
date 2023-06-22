public class GameManager
{
    CharacterManager characterManager = CharacterManager.GetInstance();
    TeamManager teamManager = TeamManager.GetInstance();
    MatchManager matchManager = MatchManager.GetInstance(); 

    #region SINGLETON
    private GameManager() { }

    private static GameManager Instance;

    public static GameManager GetInstance()
    {
        if (Instance == null) Instance = new GameManager();
        return Instance;
    }
    #endregion

    public void Start()
    {
        while(true)
        {
            MainMenu.PromptMainMenu();

            characterManager.Init();

            Grid.Setup(Settings.gridRows, Settings.gridColumns);
            Grid.DrawGrid();

            teamManager.Init();
            teamManager.Setup();
            teamManager.UpdateTeamRelationship();

            Grid.AllocateCharacters();
            PrematchMenu.PrintPrematchInformations();
            matchManager.StartMatch();
        }
    }
}