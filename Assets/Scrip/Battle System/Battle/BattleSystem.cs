using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleSystem : Manager<BattleSystem>
{
    [Header("TextPopUp Prefab")]
    [SerializeField] Transform textPopUp_Prefab;

    [Header("initialize Battle Data")]
    public List<BaseEntiny> allEntitiesPrefab;
    public static bool InBattleMode = false;
    public static bool Lose = false;

    [Header("Button Quit")]
    [SerializeField] GameObject buttonQuit;

    private SoundManager sound;
    private BaseEntiny newEntity;

  
    public Dictionary<Team, List<BaseEntiny>> unitOfTeam = new Dictionary<Team, List<BaseEntiny>>();
    public Dictionary<Team, List<BaseEntiny>> unitSummonOfTeam = new Dictionary<Team, List<BaseEntiny>>();
    public Dictionary<Team, List<BaseEntiny>> NPCofTeam = new Dictionary<Team, List<BaseEntiny>>();

    public Dictionary<Team, List<BaseEntiny>> UClass_Infantry = new Dictionary<Team, List<BaseEntiny>>();
    public Dictionary<Team, List<BaseEntiny>> UClass_Archer = new Dictionary<Team, List<BaseEntiny>>();
    public Dictionary<Team, List<BaseEntiny>> UClass_Cavalry = new Dictionary<Team, List<BaseEntiny>>();
    public Dictionary<Team, List<BaseEntiny>> UClass_Elephant = new Dictionary<Team, List<BaseEntiny>>();

    public Dictionary<Team, List<BaseEntiny>> UFaction_VietNam = new Dictionary<Team, List<BaseEntiny>>();
    public Dictionary<Team, List<BaseEntiny>> UFaction_MongNguyen = new Dictionary<Team, List<BaseEntiny>>();
    public Dictionary<Team, List<BaseEntiny>> UFaction_ChamPa = new Dictionary<Team, List<BaseEntiny>>();


    public List<Battle> listBattle = new List<Battle>();
    public static Battle currentBattle = new Battle();

    void Start()
    {
        Set_CurrentBattle();
        SetUp_Battle_BaseData();
        Add_Enemy_In_Battle();
        UpdateBattleUI();


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
            Debug.Log("Dont have Unit");
            return;
        }

        if(unitOfTeam[Team.Team1].Count <= 0 && NPCofTeam[Team.Team1].Count <= 0 && unitSummonOfTeam[Team.Team1].Count <= 0)
        {
            PlayerLose();
        }
        if (unitOfTeam[Team.Team2].Count <= 0 && NPCofTeam[Team.Team2].Count <= 0 && unitSummonOfTeam[Team.Team2].Count <= 0)
        {
            PlayerWin();
        }
    }

    private void PlayerWin()
    {
        BattleUIManager.instance.Show_Dialog(true);
        //Get loot
        Updata_CurrentBattle();
    }

    private void PlayerLose()
    {
        BattleUIManager.instance.Show_Dialog(false);
        Stop_Battle();
    }

    private void SetUp_Battle_BaseData()
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


    // Add Unit ( for Team 1) when select Unit form UI
    public void AddUnit_For(Team team, UnitOfPlayer unit, UnitGraph unitGraph, Unit_Type type)
    {

        newEntity = Instantiate(allEntitiesPrefab[0]);
        unitOfTeam[team].Add(newEntity);

        newEntity.SetUP(team,
        GridManager.instance.GetFreeNode(team),
        unit, unitGraph, type);

        Add_BaseEntiny_toList_UnitClass(newEntity);
        Add_BaseEntiny_toList_UnitFaction(newEntity);
        if(team == Team.Team1)
        BattleUIManager.instance.UpdateUnitAmount(unitOfTeam[team].Count);
    }

    //Function use after end Battle
    //Create Unit with oldPos, oldstat, senergy
    private void ReloadUnit_For(Team team, BaseEntiny unit)
    {

        newEntity = Instantiate(allEntitiesPrefab[0]);
        unitOfTeam[team].Add(newEntity);
        newEntity.SetUP(team, unit.curentNode, unit, unit.unitType);
    }

    public void Add_Enemy_In_Battle()
    {
        CloneBattleSystem.ClearSynergyEnemy();

        foreach (Unit enemy in currentBattle.enemy)
        {
            newEntity = Instantiate(allEntitiesPrefab[0]);

            unitOfTeam[Team.Team2].Add(newEntity);
            newEntity.SetUP(
            Team.Team2,
            GridManager.instance.Convert_Position_toNode(enemy.Position),
            enemy, Unit_Type.Hero);

            Add_BaseEntiny_toList_UnitClass(newEntity);
            Add_BaseEntiny_toList_UnitFaction(newEntity);

        }  
    }

    #region Synergy
    private void Add_BaseEntiny_toList_UnitClass(BaseEntiny unit)
    {
        switch (unit.unitClass)
        {
            case UnitClass.Infantry:
                UClass_Infantry[unit.UnitTeam()].Add(unit);
                Set_Infantry_for(unit.UnitTeam());
                break;

            case UnitClass.Archer:
                UClass_Archer[unit.UnitTeam()].Add(unit);
                Set_ArcherFor(unit.UnitTeam());
                break;

            case UnitClass.Cavalry:
                UClass_Cavalry[unit.UnitTeam()].Add(unit);
                Set_Cavalry_for(unit.UnitTeam());
                break;

            case UnitClass.WarElephant:
                UClass_Elephant[unit.UnitTeam()].Add(unit);
                break;
            case UnitClass.RoyalGuard:
                break;
            case UnitClass.Mandarin:
                break;
            case UnitClass.Marine:
                break;
            case UnitClass.Partisans:
                break;
            default:
                break;
        }
    }

    private void Add_BaseEntiny_toList_UnitFaction(BaseEntiny unit)
    {
        switch (unit.unitFaction)
        {
            case UnitFaction.VietNam:
                UFaction_VietNam[unit.UnitTeam()].Add(unit);
                Set_VietnamFor(unit.UnitTeam());
                break;

            case UnitFaction.MongNguyen:
                UFaction_MongNguyen[unit.UnitTeam()].Add(unit);
                Set_MongNguyenFor(unit.UnitTeam());
                break;

            case UnitFaction.Khmer:
                break;
            case UnitFaction.Champa:
                UFaction_ChamPa[unit.UnitTeam()].Add(unit);
                Set_ChamPaFor(unit.UnitTeam());
                break;

            case UnitFaction.VietRoyal:
                break;
            case UnitFaction.Thai:
                break;
            case UnitFaction.Tay:
                break;
            default:
                break;
        }
    }

    private void Set_ChamPaFor(Team team)
    {
        Synergy.instance.Set_ChamPa_by(UFaction_ChamPa[team]);
        if (team == Team.Team1)
        {
            BattleUIManager.instance.ChamPa_UI();
        }
    }

    private void Set_VietnamFor(Team team)
    {
        Synergy.instance.Set_Vietnam_by(UFaction_VietNam[team]);
        if(team == Team.Team1)
        {
            BattleUIManager.instance.VietNam_UI();
        }
    }

    private void Set_MongNguyenFor(Team team)
    {
        Synergy.instance.Set_MongNguyen_by(UFaction_MongNguyen[team]);
        if(team == Team.Team1)
        {
            BattleUIManager.instance.MongNguyen_UI();
        }
    }
    

    private void Set_ArcherFor(Team team)
    {
        Synergy.instance.Set_Archer_by(UClass_Archer[team]);

        if (team == Team.Team1)
        {
            BattleUIManager.instance.Archer_UI();
        }
    }

    private void Set_Cavalry_for(Team team)
    {
        Synergy.instance.Set_Cavalry_by(UClass_Cavalry[team]);
        if (team == Team.Team1)
        {
            BattleUIManager.instance.Cavalry_UI();
        }
    }

    private void Set_Infantry_for(Team team)
    {
        Synergy.instance.Set_Infantry_by(UClass_Infantry[team]);
        if (team == Team.Team1)
        {
            BattleUIManager.instance.Infantry_UI();
        }
    }

    #endregion


    private void Stop_Battle()
    {
        InBattleMode = false;
        Lose = true;
        buttonQuit.SetActive(true);
    }

    private void Set_CurrentBattle()
    {
        listBattle = ListRaid.currentStage.battles;
        currentBattle = listBattle[0];
    }

   private void Updata_CurrentBattle()
    {
        InBattleMode = false;

        listBattle.Remove(currentBattle);
        if(listBattle.Count > 0)
        {
            currentBattle = listBattle[0];
            StartCoroutine(WaitThenReload());
            Invoke("UpdateBattleUI",3);   
        }
        else
        {
            //exit stage
        }

    }

    private IEnumerator WaitThenReload()
    {
        yield return new WaitForSeconds(2);
        Add_Enemy_In_Battle();
        Reload_PlayerTeam(Team.Team1);
    }

    private void UpdateBattleUI()
    {
        BattleUIManager.instance.UpdateUnitAmount(unitOfTeam[Team.Team1].Count);
        BattleUIManager.instance.Active_UnitShop();
    }

    private void Reload_PlayerTeam(Team team)
    {
        //We Cloned Battle System in Function Startbattle()
        CloneBattleSystem.Clear_For(team);

        foreach (BaseEntiny unit in CloneBattleSystem.unitOfTeam[team])
        {
            ReloadUnit_For(team, unit);
        }
        CloneBattleSystem.unitOfTeam[team].Clear();

        BattleUIManager.instance.UpdateUnitAmount(unitOfTeam[Team.Team1].Count);
    }
  
    public List<BaseEntiny> Get_Units_Against(Team againstTeam)
    {
        List<BaseEntiny> all_Enemy = new List<BaseEntiny>();
        if (againstTeam == Team.Team1)
        {
            all_Enemy.AddRange(unitOfTeam[Team.Team2]);
            all_Enemy.AddRange(NPCofTeam[Team.Team2]);
            all_Enemy.AddRange(unitSummonOfTeam[Team.Team2]);
            return all_Enemy;
        }
        else
        {
            all_Enemy.AddRange(unitOfTeam[Team.Team1]);
            all_Enemy.AddRange(NPCofTeam[Team.Team1]);
            all_Enemy.AddRange(unitSummonOfTeam[Team.Team1]);
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

    public void UnitDeath(BaseEntiny e)
    {
        RemoveUnit.Updata_UType(e);
        Destroy(e.gameObject);
    }

    public void Remove(BaseEntiny e)
    {
        RemoveUnit.Updata_UType(e);
        RemoveUnit.Update_UClass(e);
        RemoveUnit.Update_UFaction(e);
        Destroy(e.gameObject);
        BattleUIManager.instance.UpdateUnitAmount(unitOfTeam[Team.Team1].Count);
    }

    public void Back_toRaid()
    {
        Lose = false;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        sound.PlaySound("theme");
        SceneManager.LoadScene(ListScene.SelectScene.Raid.ToString());
    }

    public void Fight_Againt()
    {
        SceneManager.LoadScene(ListScene.SelectScene.Battle.ToString());
    }

    public void Startbattle()
    {
        if (!InBattleMode && CheckUnitAmout() && !Lose)
        {
            BattleUIManager.instance.UnActive_UnitShop();
            CloneBattleSystem.Clone_For(Team.Team1);
            InBattleMode = true;
            StartCoroutine(BattleUIManager.instance.TimeBattle(currentBattle.maxTimeBattle));
        }  
    }

    private bool UnitAmoutIsOk()
    {
        if(unitOfTeam[Team.Team1].Count <= currentBattle.maxAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CheckUnitAmout()
    {
        if (!UnitAmoutIsOk())
        {
            CreatePopUpWarring();
            return false;
        }
        else
        {
            return true;
        }
    }

    private void CreatePopUpWarring()
    {
        BattleUIManager.instance.CreateWarringPopUp();  
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
