using System;
using System.Collections.Generic;
using System.Drawing;

public class Team
{
    public TeamSide teamSide;
    public string name;
    public ConsoleColor color;
    public List<Character> memberList = new List<Character>();
    public List<Character> aliveMemberList = new List<Character>();

    public Team(TeamSide _teamSide)
    {
        teamSide = _teamSide;

        switch (teamSide)
        {
            case TeamSide.BLUE:
                name = "Blue";
                color = ConsoleColor.Blue;
                break;
            case TeamSide.RED:
                name = "Red";
                color = ConsoleColor.Red;
                break;
        }
    }

    public void AddMember(Character member)
    {
        memberList.Add(member);
        aliveMemberList.Add(member);
    }

    public void RemoveMember(Character member)
    {
        aliveMemberList.Remove(member);
    }
}