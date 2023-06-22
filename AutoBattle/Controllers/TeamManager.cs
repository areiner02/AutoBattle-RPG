using System.Collections.Generic;

public class TeamManager
{
    Team blueTeam = new Team(TeamSide.BLUE);
    Team redTeam = new Team(TeamSide.RED);
    List<Team> teamList;

    #region SINGLETON
    private TeamManager() { }

    private static TeamManager Instance;

    public static TeamManager GetInstance()
    {
        if (Instance == null) Instance = new TeamManager();
        return Instance;
    }
    #endregion

    public void Init()
    {
        blueTeam = new Team(TeamSide.BLUE);
        redTeam = new Team(TeamSide.RED);
        teamList = new List<Team> { blueTeam, redTeam };
    }

    public void Setup()
    {
        List<Character> characterList = CharacterManager.GetInstance().GetCharacterList();

        for (int i = 0; i < characterList.Count; i++)
        {
            if (i % 2 == 0)
            {
                blueTeam.AddMember(characterList[i]);
            }
            else
            {
                redTeam.AddMember(characterList[i]);
            }
        }
    }

    public void UpdateTeamRelationship()
    {
        foreach (Character character in blueTeam.aliveMemberList)
        {
            character.team = blueTeam;
            character.allyList = blueTeam.aliveMemberList;
            character.enemyList = redTeam.aliveMemberList;
        }

        foreach (Character character in redTeam.aliveMemberList)
        {
            character.team = redTeam;
            character.allyList = redTeam.aliveMemberList;
            character.enemyList = blueTeam.aliveMemberList;
        }
    }

    public void MemberDied(Character member)
    {
        foreach (Team team in teamList)
        {
            foreach (Character character in team.aliveMemberList)
            {
                if (character == member)
                {
                    team.aliveMemberList.Remove(member);
                    break;
                }
            }
        }

        UpdateTeamRelationship();
        CheckTeamStatus();
    }

    public void CheckTeamStatus()
    {
        foreach (Team team in teamList)
        {
            if (team.aliveMemberList.Count == 0)
            {
                MatchManager.GetInstance().EndMatch(teamList.Find(t => t != team));
            }
        }
    }
}