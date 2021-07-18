using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RemoveUnit
{
    private static Dictionary<Team, List<BaseEntiny>> UFaction_VietNam;
    private static Dictionary<Team, List<BaseEntiny>> UFaction_MongNguyen;
    private static Dictionary<Team, List<BaseEntiny>> UFaction_ChamPa;

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
                unitOfTeam = BattleSystem.instance.unitOfTeam;
                unitOfTeam[e.UnitTeam()].Remove(e);
                break;

            case Unit_Type.NPC:
                NPCofTeam = BattleSystem.instance.NPCofTeam;
                NPCofTeam[e.UnitTeam()].Remove(e);
                break;

            case Unit_Type.Summon:
                unitSummonOfTeam = BattleSystem.instance.unitSummonOfTeam;
                unitSummonOfTeam[e.UnitTeam()].Remove(e);
                break;  
        }
    }

    public static void Update_UFaction(BaseEntiny e)
    {
        switch (e.unitFaction)
        {
            case UnitFaction.VietNam:
                UFaction_VietNam_Remove(e);
                break;

            case UnitFaction.MongNguyen:
                UFaction_MongNguyen_Remove(e);
                break;

            case UnitFaction.Khmer:
                break;
            case UnitFaction.Champa:
                UFaction_ChamPa_Remove(e);
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

    private static void UFaction_VietNam_Remove(BaseEntiny e )
    {
        UFaction_VietNam = BattleSystem.instance.UFaction_VietNam;

        if (UFaction_VietNam[e.UnitTeam()].Contains(e))
        {
            UFaction_VietNam[e.UnitTeam()].Remove(e);
            F_VietNam.Set_Vietnam_by(UFaction_VietNam[e.UnitTeam()]);
            BattleUIManager.instance.VietNam_UI();
        }
    }

    private static void UFaction_MongNguyen_Remove(BaseEntiny e)
    {
        UFaction_MongNguyen = BattleSystem.instance.UFaction_MongNguyen;

        if (UFaction_MongNguyen[e.UnitTeam()].Contains(e))
        {
            UFaction_MongNguyen[e.UnitTeam()].Remove(e);
            F_MongNguyen.Set_MongNguyen_by(UFaction_MongNguyen[e.UnitTeam()]);
            BattleUIManager.instance.MongNguyen_UI();
        }
    }

    private static void UFaction_ChamPa_Remove(BaseEntiny e)
    {
        UFaction_ChamPa = BattleSystem.instance.UFaction_ChamPa;
        if (UFaction_ChamPa[e.UnitTeam()].Contains(e))
        {
            UFaction_ChamPa[e.UnitTeam()].Remove(e);
            F_ChamPa.Set_ChamPa_by(UFaction_ChamPa[e.UnitTeam()]);
            BattleUIManager.instance.ChamPa_UI();
        }
    }


    public static void Update_UClass(BaseEntiny e)
    {
        switch (e.unitClass)
        {
            case UnitClass.Archer:
                UClass_Archer_Remove(e);
                break;

            case UnitClass.Cavalry:
                UClass_Cavalry_Remove(e);
                break;

            case UnitClass.Infantry:
                UClass_Infantry_Remove(e);
                break;

            case UnitClass.Mandarin:
                break;
            case UnitClass.Marine:
                break;
            case UnitClass.Partisans:
                break;
            case UnitClass.RoyalGuard:
                break;
            case UnitClass.WarElephant:
                break;
            default:
                break;
        }
    }

    private static void UClass_Archer_Remove(BaseEntiny e)
    {
        UClass_Archer = BattleSystem.instance.UClass_Archer;

        if (UClass_Archer[e.UnitTeam()].Contains(e))
        {
            UClass_Archer[e.UnitTeam()].Remove(e);
            C_Archer.Set_Archer_by(UClass_Archer[e.UnitTeam()]);
            BattleUIManager.instance.Archer_UI();
        }
    }

    private static void UClass_Cavalry_Remove(BaseEntiny e)
    {
        UClass_Cavalry = BattleSystem.instance.UClass_Cavalry;

        if (UClass_Cavalry[e.UnitTeam()].Contains(e))
        {
            UClass_Cavalry[e.UnitTeam()].Remove(e);
            C_Cavalry.Set_Cavalry_by(UClass_Cavalry[e.UnitTeam()]);
            BattleUIManager.instance.Cavalry_UI();
        } 
    }

    private static void UClass_Infantry_Remove(BaseEntiny e)
    {
        UClass_Infantry = BattleSystem.instance.UClass_Infantry;

        if (UClass_Infantry[e.UnitTeam()].Contains(e))
        {
            UClass_Infantry[e.UnitTeam()].Remove(e);
            C_Infantry.Set_Infantry_by(UClass_Infantry[e.UnitTeam()]);
            BattleUIManager.instance.Infantry_UI();
        }
    }

}
