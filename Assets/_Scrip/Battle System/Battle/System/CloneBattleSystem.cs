using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CloneBattleSystem : MonoBehaviour
{
    public static Dictionary<Team, List<BaseEntiny>> unitOfTeam = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> unitSummonOfTeam = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> NPCofTeam = new Dictionary<Team, List<BaseEntiny>>();

    private static Dictionary<Team, List<BaseEntiny>> UClass_Infantry = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> UClass_Archer = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> UClass_Cavalry = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> UClass_Elephant = new Dictionary<Team, List<BaseEntiny>>();

    private static Dictionary<Team, List<BaseEntiny>> UFaction_VietNam = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> UFaction_MongNguyen = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> UFaction_ChamPa = new Dictionary<Team, List<BaseEntiny>>();

    public static List<Node> startNode = new List<Node>();

    void Start()
    {
        unitOfTeam.Add(Team.Team1, new List<BaseEntiny>());
        unitOfTeam.Add(Team.Team2, new List<BaseEntiny>());

        unitSummonOfTeam.Add(Team.Team1, new List<BaseEntiny>());
        unitSummonOfTeam.Add(Team.Team2, new List<BaseEntiny>());

        NPCofTeam.Add(Team.Team1, new List<BaseEntiny>());
        NPCofTeam.Add(Team.Team2, new List<BaseEntiny>());

        UClass_Archer.Add(Team.Team1, new List<BaseEntiny>());
        UClass_Infantry.Add(Team.Team1, new List<BaseEntiny>());
        UClass_Cavalry.Add(Team.Team1, new List<BaseEntiny>());
        UClass_Elephant.Add(Team.Team1, new List<BaseEntiny>());

        UFaction_ChamPa.Add(Team.Team1, new List<BaseEntiny>());
        UFaction_MongNguyen.Add(Team.Team1, new List<BaseEntiny>());
        UFaction_VietNam.Add(Team.Team1, new List<BaseEntiny>());

        UClass_Archer.Add(Team.Team2, new List<BaseEntiny>());
        UClass_Infantry.Add(Team.Team2, new List<BaseEntiny>());
        UClass_Cavalry.Add(Team.Team2, new List<BaseEntiny>());
        UClass_Elephant.Add(Team.Team2, new List<BaseEntiny>());

        UFaction_ChamPa.Add(Team.Team2, new List<BaseEntiny>());
        UFaction_MongNguyen.Add(Team.Team2, new List<BaseEntiny>());
        UFaction_VietNam.Add(Team.Team2, new List<BaseEntiny>());
    }

    public static void ClearSynergyEnemy()
    {
        BattleSystem.UFaction_Water[Team.Team2].Clear();
        BattleSystem.UFaction_RockMountain[Team.Team2].Clear();
        BattleSystem.UFaction_Beast[Team.Team2].Clear();
        BattleSystem.UClass_Hunter[Team.Team2].Clear();
        BattleSystem.UClass_Cavalry[Team.Team2].Clear();
        BattleSystem.UClass_Warrior[Team.Team2].Clear();
    }


    public static void Save_UnitPos()
    {
        unitOfTeam[Team.Team1] = BattleSystem.GetAllUnitOf(Team.Team1);

        startNode.Clear();
        foreach (BaseEntiny unit in unitOfTeam[Team.Team1])
        {
            startNode.Add(unit.GetCurrentNode());
        }
    }

    public static void Load_UnitPos()
    {
        int i = 0;
        foreach (var unit in unitOfTeam[Team.Team1])
        {
            if (unit.IsLive)
            {
                unit.transform.position = startNode[i].worldPosition;
            } 
            i++;
        }
    }
}
