using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RemoveUnit
{
    private static Dictionary<Team, List<BaseEntiny>> UFaction_Water;
    private static Dictionary<Team, List<BaseEntiny>> UFaction_RockMountain;
    private static Dictionary<Team, List<BaseEntiny>> UFaction_Beast;

    private static Dictionary<Team, List<BaseEntiny>> UClass_Archer;
    private static Dictionary<Team, List<BaseEntiny>> UClass_Cavalry;
    private static Dictionary<Team, List<BaseEntiny>> UClass_Infantry;

    private static Dictionary<Team, List<BaseEntiny>> unitOfTeam;
    private static Dictionary<Team, List<BaseEntiny>> unitSummonOfTeam;
    private static Dictionary<Team, List<BaseEntiny>> NPCofTeam;

    public static void Updata_UType(BaseEntiny e)
    {
        switch (e.unitType)
        {
            case Unit_Type.Hero:
                unitOfTeam = BattleSystem.GetAllUnitInBoard;
                unitOfTeam[e.UnitTeam()].Remove(e);
                break;

            case Unit_Type.NPC:
                NPCofTeam = BattleSystem.NPCofTeam;
                NPCofTeam[e.UnitTeam()].Remove(e);
                break;

            case Unit_Type.Summon:
                unitSummonOfTeam = BattleSystem.UnitSummonOfTeam;
                unitSummonOfTeam[e.UnitTeam()].Remove(e);
                break;  
        }
    }

    public static void Update_UFaction(BaseEntiny e)
    {
        switch (e.unitFaction)
        {
            case UnitFaction.Water:
                UFaction_Water_Remove(e);
                break;
            case UnitFaction.RockMountain:
                UFaction_RockMountain_Remove(e);
                break;
            case UnitFaction.Beast:
                UFaction_Beast_Remove(e);
                break;
            default:
                break;
        }
    }

    private static void UFaction_Water_Remove(BaseEntiny e )
    {
        UFaction_Water = BattleSystem.UFaction_Water;

        if (UFaction_Water[e.UnitTeam()].Contains(e))
        {
            UFaction_Water[e.UnitTeam()].Remove(e);
            F_Water.Set_Water_by(UFaction_Water[e.UnitTeam()]);
            //SynergyUI.instance.VietNam_UI();
        }
    }

    private static void UFaction_RockMountain_Remove(BaseEntiny e)
    {
        UFaction_RockMountain = BattleSystem.UFaction_RockMountain;

        if (UFaction_RockMountain[e.UnitTeam()].Contains(e))
        {
            UFaction_RockMountain[e.UnitTeam()].Remove(e);
            F_RockMountain.Set_RockMountain_by(UFaction_RockMountain[e.UnitTeam()]);
            //SynergyUI.instance.MongNguyen_UI();
        }
    }

    private static void UFaction_Beast_Remove(BaseEntiny e)
    {
        UFaction_Beast = BattleSystem.UFaction_Beast;
        if (UFaction_Beast[e.UnitTeam()].Contains(e))
        {
            UFaction_Beast[e.UnitTeam()].Remove(e);
            F_Beast.Set_Beast_by(UFaction_Beast[e.UnitTeam()]);
            //SynergyUI.instance.ChamPa_UI();
        }
    }


    public static void Update_UClass(BaseEntiny e)
    {
        switch (e.unitClass)
        {
            case UnitClass.Hunter:
                UClass_Archer_Remove(e);
                break;

            case UnitClass.Cavalry:
                UClass_Cavalry_Remove(e);
                break;

            case UnitClass.Warrior:
                UClass_Infantry_Remove(e);
                break;
            default:
                break;
        }
    }

    private static void UClass_Archer_Remove(BaseEntiny e)
    {
        UClass_Archer = BattleSystem.UClass_Hunter;

        if (UClass_Archer[e.UnitTeam()].Contains(e))
        {
            UClass_Archer[e.UnitTeam()].Remove(e);
            C_Hunter.Set_Hunter_by(UClass_Archer[e.UnitTeam()]);
            //SynergyUI.instance.Archer_UI();
        }
    }

    private static void UClass_Cavalry_Remove(BaseEntiny e)
    {
        UClass_Cavalry = BattleSystem.UClass_Cavalry;

        if (UClass_Cavalry[e.UnitTeam()].Contains(e))
        {
            UClass_Cavalry[e.UnitTeam()].Remove(e);
            C_Cavalry.Set_Cavalry_by(UClass_Cavalry[e.UnitTeam()]);
            //SynergyUI.instance.Cavalry_UI();
        } 
    }

    private static void UClass_Infantry_Remove(BaseEntiny e)
    {
        UClass_Infantry = BattleSystem.UClass_Warrior;

        if (UClass_Infantry[e.UnitTeam()].Contains(e))
        {
            UClass_Infantry[e.UnitTeam()].Remove(e);
            C_Warrior.Set_Warrior_by(UClass_Infantry[e.UnitTeam()]);
            //SynergyUI.instance.Infantry_UI();
        }
    }

}
