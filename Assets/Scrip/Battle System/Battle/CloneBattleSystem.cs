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

    public static void Clone_For(Team team)
    {
        unitOfTeam[team] = BattleSystem.instance.unitOfTeam[team].ToList();
        Save_UnitPos();
        unitSummonOfTeam[team] = BattleSystem.instance.unitSummonOfTeam[team].ToList();
        NPCofTeam[team] = BattleSystem.instance.NPCofTeam[team].ToList();

        UClass_Archer[team] = BattleSystem.instance.UClass_Archer[team].ToList();
        UClass_Cavalry[team] = BattleSystem.instance.UClass_Cavalry[team].ToList();
        UClass_Elephant[team] = BattleSystem.instance.UClass_Elephant[team].ToList();
        UClass_Infantry[team] = BattleSystem.instance.UClass_Infantry[team].ToList();

        UFaction_ChamPa[team] = BattleSystem.instance.UFaction_ChamPa[team].ToList();
        UFaction_MongNguyen[team] = BattleSystem.instance.UFaction_MongNguyen[team].ToList();
        UFaction_VietNam[team] = BattleSystem.instance.UFaction_VietNam[team].ToList();

    }

    public static void Clear_For(Team team)
    {
        
        foreach (BaseEntiny unit in BattleSystem.instance.unitOfTeam[team])
        {     
            Destroy(unit.gameObject);
        }

        BattleSystem.instance.unitOfTeam[team].Clear();

        foreach (BaseEntiny unit in BattleSystem.instance.unitSummonOfTeam[team])
        {
            Destroy(unit.gameObject);
        }
        BattleSystem.instance.unitSummonOfTeam[team].Clear();

        foreach (BaseEntiny unit in BattleSystem.instance.NPCofTeam[team])
        {
            Destroy(unit.gameObject);
        }
        BattleSystem.instance.NPCofTeam[team].Clear();

        Load_UnitPos();
    }

    public static void ClearSynergyEnemy()
    {
        BattleSystem.instance.UFaction_VietNam[Team.Team2].Clear();
        BattleSystem.instance.UFaction_MongNguyen[Team.Team2].Clear();
        BattleSystem.instance.UFaction_ChamPa[Team.Team2].Clear();
        BattleSystem.instance.UClass_Archer[Team.Team2].Clear();
        BattleSystem.instance.UClass_Cavalry[Team.Team2].Clear();
        BattleSystem.instance.UClass_Infantry[Team.Team2].Clear();
    }


    private static void Save_UnitPos()
    {
        startNode.Clear();
        foreach (BaseEntiny unit in unitOfTeam[Team.Team1])
        {
            startNode.Add(unit.curentNode);
        }
    }

    private static void Load_UnitPos()
    {
        int i = 0;
        foreach (var unit in unitOfTeam[Team.Team1])
        {
            unit.curentNode = startNode[i];
            i++;
        }
    }
}
