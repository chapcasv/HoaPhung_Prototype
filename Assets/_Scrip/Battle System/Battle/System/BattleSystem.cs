using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BattleSystem : Manager<BattleSystem>
{
    #region Properties
    [Header("Team 1 Pool")]
    [SerializeField] Transform Team1Pool;

    [Header("Team 2 Pool")]
    [SerializeField] Transform Team2Pool;

    [Header("TextPopUp Prefab")]
    [SerializeField] Transform textPopUp_Prefab;

    [Header("initialize Battle Data")]
    public List<BaseEntiny> allEntitiesPrefab;
    public static bool InBattleMode = false;
    public static bool InStartPhase = true;
    public static bool InDrawPhase = false;
    public static bool Lose = false;

    private SoundManager sound;
    private BaseEntiny newEntity;
    public static readonly int maxUnit = 3;

  
    private static Dictionary<Team, List<BaseEntiny>> unitOfTeam = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> unitSummonOfTeam = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> nPCofTeam = new Dictionary<Team, List<BaseEntiny>>();

    private static Dictionary<Team, List<BaseEntiny>> uClass_Warrior = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> uClass_Hunter = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> uClass_Cavalry = new Dictionary<Team, List<BaseEntiny>>();

    private static Dictionary<Team, List<BaseEntiny>> uFaction_Water = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> uFaction_RockMountain = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> uFaction_Beast = new Dictionary<Team, List<BaseEntiny>>();
    private static Dictionary<Team, List<BaseEntiny>> uFaction_GodDragon = new Dictionary<Team, List<BaseEntiny>>();


    private List<Wave> listWave = new List<Wave>();
    private static int enemyLife;
    public static int EnemyLife { get => enemyLife; }

    public static Wave currentWave;
    public static List<BaseEntiny> GetAllUnitOf(Team team) => unitOfTeam[team];
    public static Dictionary<Team, List<BaseEntiny>> GetAllUnitInBoard => unitOfTeam;
    public static Dictionary<Team, List<BaseEntiny>> UnitSummonOfTeam { get => unitSummonOfTeam; }
    public static Dictionary<Team, List<BaseEntiny>> UFaction_Water { get => uFaction_Water; }
    public static Dictionary<Team, List<BaseEntiny>> UFaction_RockMountain { get => uFaction_RockMountain; }
    public static Dictionary<Team, List<BaseEntiny>> UFaction_Beast { get => uFaction_Beast; }
    public static Dictionary<Team, List<BaseEntiny>> NPCofTeam { get => nPCofTeam; }
    public static Dictionary<Team, List<BaseEntiny>> UClass_Warrior { get => uClass_Warrior; }
    public static Dictionary<Team, List<BaseEntiny>> UClass_Hunter { get => uClass_Hunter; }
    public static Dictionary<Team, List<BaseEntiny>> UClass_Cavalry { get => uClass_Cavalry; }
    public static Dictionary<Team, List<BaseEntiny>> UFaction_GodDragon { get => uFaction_GodDragon; }

    public Action OnRoundStart;
    #endregion

    void Start()
    {
        Set_LifeRaid();
        Set_StartWave();
        SetUp_Battle_BaseData();
        Add_Enemy_In_Battle();
    }

    private void Update()
    {
        CheckTeamWin();
    }

    private void CheckTeamWin()
    {
        if (InBattleMode == false) return;

        if(unitOfTeam[Team.Team1] == null && unitOfTeam[Team.Team2] == null)
        {
            return;
        }

        if(unitOfTeam[Team.Team1].Count <= 0 && NPCofTeam[Team.Team1].Count <= 0 && UnitSummonOfTeam[Team.Team1].Count <= 0)
        {
            InBattleMode = false;
            EnemyAtkLifePlayer();
            CheckProcess();
        }
        if (unitOfTeam[Team.Team2].Count <= 0 && NPCofTeam[Team.Team2].Count <= 0 && UnitSummonOfTeam[Team.Team2].Count <= 0)
        {
            InBattleMode = false;
            TakeRewardClearWave();
            PlayerAtkLifeRaid();
            CheckProcess();
        }
    }

    private bool LastWave()
    {
        if (listWave.Count == 0) return true;
        else return false;
    }

    private void CheckProcess()
    {
        if (LastWave())
        {
            PlayerWin();
        }
        else
        {
            Updata_CurrentWave();
        }
    }

    private void PlayerAtkLifeRaid()
    {
        int atkLife = 0;
        foreach (var unit in unitOfTeam[Team.Team1])
        {
            atkLife += unit.AtkDameToLife;
        }
        enemyLife -= atkLife;
        BattleUI.instance.UpdateEnemyLifeCurrent(EnemyLife);
        CheckLifeEnemy(EnemyLife);
    }

    private void CheckLifeEnemy(int lifeRaid)
    {
        if (lifeRaid <= 0) PlayerWin();
    }

    private void EnemyAtkLifePlayer()
    {
        int atkLife = 0;
        foreach (var unit in unitOfTeam[Team.Team2])
        {
            atkLife += unit.AtkDameToLife;
        }
        BattlePlayerLife.Sub(atkLife);
        CheckLifePlayer(BattlePlayerLife.CurrentLife);
    }

    private void CheckLifePlayer(int life) { if (life <= 0) PlayerLose();}

    private void TakeRewardClearWave() { BattleCoin.Add(currentWave.GoldBonus); }

    private void PlayerWin()
    {
        BattleUI.instance.Show_Dialog(true);
        Stop_Battle();
    }

    private void PlayerLose()
    {
        BattleUI.instance.Show_Dialog(false);
        Stop_Battle();
    }

    private void Set_LifeRaid()
    {
        enemyLife = RaidManager.currentRaid.EnemyLife;
    }

    private void SetUp_Battle_BaseData()
    {
        unitOfTeam.Add(Team.Team1, new List<BaseEntiny>());
        unitOfTeam.Add(Team.Team2, new List<BaseEntiny>());

        UnitSummonOfTeam.Add(Team.Team1, new List<BaseEntiny>());
        UnitSummonOfTeam.Add(Team.Team2, new List<BaseEntiny>());

        NPCofTeam.Add(Team.Team1, new List<BaseEntiny>());
        NPCofTeam.Add(Team.Team2, new List<BaseEntiny>());

        UClass_Hunter.Add(Team.Team1, new List<BaseEntiny>());
        UClass_Warrior.Add(Team.Team1, new List<BaseEntiny>());
        UClass_Cavalry.Add(Team.Team1, new List<BaseEntiny>());

        UFaction_Beast.Add(Team.Team1, new List<BaseEntiny>());
        UFaction_RockMountain.Add(Team.Team1, new List<BaseEntiny>());
        UFaction_Water.Add(Team.Team1, new List<BaseEntiny>());
        UFaction_GodDragon.Add(Team.Team1, new List<BaseEntiny>());

        UClass_Hunter.Add(Team.Team2, new List<BaseEntiny>());
        UClass_Warrior.Add(Team.Team2, new List<BaseEntiny>());
        UClass_Cavalry.Add(Team.Team2, new List<BaseEntiny>());

        UFaction_Beast.Add(Team.Team2, new List<BaseEntiny>());
        UFaction_RockMountain.Add(Team.Team2, new List<BaseEntiny>());
        UFaction_Water.Add(Team.Team2, new List<BaseEntiny>());
        UFaction_GodDragon.Add(Team.Team2, new List<BaseEntiny>());

    }


    //Add Unit( for Team 1) when Unit spawn form cardHand to board
    public void AddUnit(Node spawnNode, Card unit, Unit_Type type)
    {   
        newEntity = Instantiate(allEntitiesPrefab[0],Team1Pool);
        unitOfTeam[Team.Team1].Add(newEntity);
        newEntity.SetUP(Team.Team1, spawnNode, unit, type);

        Add_BaseEntiny_toList_UnitClass(newEntity);
        Add_BaseEntiny_toList_UnitFaction(newEntity);

        BattleCoin.Sub(unit.Cost);
        BattleUI.instance.UpdateUICurrent();      
    }

   

    private void Add_Enemy_In_Battle()
    {
        CloneBattleSystem.ClearSynergyEnemy();

        foreach (Enemy enemy in currentWave.enemys)
        {
            newEntity = Instantiate(allEntitiesPrefab[0],Team2Pool);

            unitOfTeam[Team.Team2].Add(newEntity);
            newEntity.SetUP(
            Team.Team2,
            GridManager.instance.Convert_Position_toNode(enemy.Pos),
            enemy.enemy, Unit_Type.Hero);

            Add_BaseEntiny_toList_UnitClass(newEntity);
            Add_BaseEntiny_toList_UnitFaction(newEntity);
        }  
    }

    #region Synergy
    private void Add_BaseEntiny_toList_UnitClass(BaseEntiny unit)
    {
        switch (unit.unitClass)
        {
            case UnitClass.Warrior:
                UClass_Warrior[unit.UnitTeam()].Add(unit);
                Set_WarrioFor(unit.UnitTeam());
                break;

            case UnitClass.Hunter:
                UClass_Hunter[unit.UnitTeam()].Add(unit);
                Set_HunterFor(unit.UnitTeam());
                break;

            case UnitClass.Cavalry:
                UClass_Cavalry[unit.UnitTeam()].Add(unit);
                Set_CavalryFor(unit.UnitTeam());
                break;

            default:
                throw new Exception("Base Entiny dont have class");
        }
    }

    private void Add_BaseEntiny_toList_UnitFaction(BaseEntiny unit)
    {
        switch (unit.unitFaction)
        {
            case UnitFaction.Water:
                UFaction_Water[unit.UnitTeam()].Add(unit);
                Set_WaterFor(unit.UnitTeam());
                break;
            case UnitFaction.RockMountain:
                UFaction_RockMountain[unit.UnitTeam()].Add(unit);
                Set_RockMountainFor(unit.UnitTeam());
                break;
            case UnitFaction.Beast:
                UFaction_Beast[unit.UnitTeam()].Add(unit);
                Set_BeastFor(unit.UnitTeam());
                break;
            case UnitFaction.GodDragon:
                UFaction_GodDragon[unit.UnitTeam()].Add(unit);
                Set_GodDragonFor(unit.UnitTeam());
                break;
            default:
                break;
        }
    }

    private void Set_BeastFor(Team team)
    {
        Synergy.instance.Set_Beast_by(UFaction_Beast[team]);
        if (team == Team.Team1)
        {
            BattleUI.instance.Set_synergyUIBeast();   
        }
    }

    private void Set_WaterFor(Team team)
    {
        Synergy.instance.Set_Water_by(UFaction_Water[team]);
        if(team == Team.Team1)
        {
            BattleUI.instance.Set_synergyUIWater();
        }
    }

    private void Set_RockMountainFor(Team team)
    {
        Synergy.instance.Set_RockMountain_by(UFaction_RockMountain[team]);
        if(team == Team.Team1)
        {
            BattleUI.instance.Set_synergyUIBeast();
        }
    }

    private void Set_GodDragonFor(Team team)
    {
        Synergy.instance.Set_GodDragon_by(UFaction_GodDragon[team]);
        if(team == Team.Team1) { BattleUI.instance.Set_synergyUIGodDragon(); }
    }
    
    private void Set_HunterFor(Team team)
    {
        Synergy.instance.Set_Archer_by(UClass_Hunter[team]);
        if (team == Team.Team1)
        {
            BattleUI.instance.Set_synergyUIHunter();

        }
    }

    private void Set_CavalryFor(Team team)
    {
        Synergy.instance.Set_Cavalry_by(UClass_Cavalry[team]);
        if (team == Team.Team1)
        {
            BattleUI.instance.Set_synergyUICavalry();
        }
    }

    private void Set_WarrioFor(Team team)
    {
        Synergy.instance.Set_Infantry_by(UClass_Warrior[team]);
        if (team == Team.Team1)
        {
            BattleUI.instance.Set_synergyUIWarrior();
        }
    }

    #endregion


    private void Stop_Battle()
    {
        InBattleMode = false;
        InDrawPhase = false;
        Lose = true;
    }

    private void Set_StartWave()
    {
        foreach (var wave in RaidManager.currentRaid.ListWave)
        {
            listWave.Add(wave);
        }
        currentWave = listWave[0];
        listWave.Remove(currentWave);
    }


    private void Updata_CurrentWave()
    {
        if(listWave.Count > 0)
        {
            currentWave = listWave[0];
            listWave.Remove(currentWave);
            StartCoroutine(WaitThenReload()); 
        }
    }

    private IEnumerator WaitThenReload()
    {
        yield return new WaitForSeconds(2);
        Add_Enemy_In_Battle();
        Reload_PosTeam1();
    }

    private void Reload_PosTeam1()
    {
        CloneBattleSystem.Load_UnitPos();
        BattleUI.instance.UpdateUICurrent();
        BattleUI.instance.DrawPhase();
    }
  
    public static List<BaseEntiny> Get_Units_Against(Team againstTeam)
    {
        List<BaseEntiny> all_Enemy = new List<BaseEntiny>();
        if (againstTeam == Team.Team1)
        {
            all_Enemy.AddRange(unitOfTeam[Team.Team2]);
            all_Enemy.AddRange(NPCofTeam[Team.Team2]);
            all_Enemy.AddRange(UnitSummonOfTeam[Team.Team2]);
            return all_Enemy;
        }
        else
        {
            all_Enemy.AddRange(unitOfTeam[Team.Team1]);
            all_Enemy.AddRange(NPCofTeam[Team.Team1]);
            all_Enemy.AddRange(UnitSummonOfTeam[Team.Team1]);
            return all_Enemy;
        }    
    }

    public List<BaseEntiny> Get_Units_TeamMate(Team myteam)
    {
        List<BaseEntiny> all_TeamMate = new List<BaseEntiny>();
        if(myteam == Team.Team1)
        {
            all_TeamMate.AddRange(unitOfTeam[Team.Team1]);
            return all_TeamMate;
        }
        else
        {
            all_TeamMate.AddRange(unitOfTeam[Team.Team2]);
            return all_TeamMate;
        }
    }

    public static void UnitDeath(BaseEntiny e)
    {
        RemoveUnit.Updata_UType(e);
        e.gameObject.SetActive(false);
    }

    public void Remove(BaseEntiny e)
    {
        RemoveUnit.Updata_UType(e);
        RemoveUnit.Update_UClass(e);
        RemoveUnit.Update_UFaction(e);
        Destroy(e.gameObject);
        BattleUI.instance.UpdateMemberCurrent(unitOfTeam[Team.Team1].Count);
    }

    public void Back_toRaid()
    {
        Lose = false;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        sound.PlaySound("theme");
        SceneManager.LoadScene(SelectScene.Raid.ToString());
    }


    public static bool HaveSlot()
    {
        if (unitOfTeam[Team.Team1].Count < maxUnit) return true;
        else return false;
    }

    public static int CurrentUnitAmount()
    {
        return unitOfTeam[Team.Team1].Count;
    }

}
public enum Team
{
    Team1,
    Team2
}

public enum Unit_Type
{
    Hero,
    NPC,
    Summon
}
