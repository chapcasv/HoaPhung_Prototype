using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : BaseEntiny
{
    Player_Database data;

    private int HP_base;
    private float Atk_speed_base;
    private int HP_buff_1 ;
    private int HP_buff_2 ;
    private int Str_buff_1;
    private int Str_buff_2;
    private float Atk_speed_buff_1;
    private float Atk_speed_buff_2;

    private List<BaseEntiny> myteamMate;
    public void GetTalent(string id, BaseEntiny unit_want_get_talent)
    {
        switch (id)
        {
            case "H001":
                H001_BangDuc(unit_want_get_talent);
                break;
            case "H003":
                H003_CamNinh(unit_want_get_talent);
                break;
            case "H004":
                H004_CaoThuan(unit_want_get_talent);
                break;
            case "H006":
                H006_ChuThai(unit_want_get_talent);
                break;
            case "H007":
                H007_GiaQuy(unit_want_get_talent);
                break;
            case "H008":
                H008_HaHauDon(unit_want_get_talent);
                break;
            case "H010":
                H010_DiemHanh(unit_want_get_talent);
                break;
            case "H021":
                H021_HoaHung(unit_want_get_talent);
                break;
            case "H032":
                H032_LuuBi(unit_want_get_talent);
                break;
            case "H042":
                H042_QuanVu(unit_want_get_talent);
                break;
            case "H043":
                H043_TruongPhi(unit_want_get_talent);
                break;
            case "H073":
                H073_MaSieu(unit_want_get_talent);
                break;
            case "H090":
                break;
            default:
                break;

        }
    }

    private void H073_MaSieu(BaseEntiny unit_want_get_talent)
    {
        throw new NotImplementedException();
    }

    private void H010_DiemHanh(BaseEntiny unit_want_get_talent)
    {
        myteamMate = BattleSystem.instance.Get_Units_TeamMate(unit_want_get_talent.UnitTeam());

        Atk_speed_base = unit_want_get_talent.Atk_speed;
        Atk_speed_buff_1 = 0;
        Atk_speed_buff_2 = 0;
        Str_buff_1 = 0;
        Str_buff_2 = 0;
        foreach (BaseEntiny Unit in myteamMate)
        {
            if (Unit.Unit_ID == "H001")
            {
                unit_want_get_talent.movespeed += 1f;
                Atk_speed_buff_1 = 0.1f;
                Str_buff_1 = 40;
                Debug.Log("Have bang duc");
            }
            else if (Unit.Unit_ID == "H073")
            {
                Atk_speed_buff_2 = 0.15f;
                Str_buff_2 = 60;
                Debug.Log("Have ma sieu");
            }
        }

        unit_want_get_talent.Atk_speed += Atk_speed_buff_1;
        unit_want_get_talent.Atk_speed += Atk_speed_buff_2;
        unit_want_get_talent.Str += Str_buff_1;
        unit_want_get_talent.Str += Str_buff_2;

    }

    private void H001_BangDuc(BaseEntiny unit_want_get_talent)
    {
        
        myteamMate = BattleSystem.instance.Get_Units_TeamMate(unit_want_get_talent.UnitTeam());
        HP_base  = unit_want_get_talent.HP_max;
        HP_buff_1 = 0;
        HP_buff_2 = 0;
        Str_buff_1 = 0;
        Str_buff_2 = 0;

        foreach (BaseEntiny Unit in myteamMate)
        {
            if(Unit.Unit_ID == "H010")
            {
                unit_want_get_talent.movespeed += 1f;
                HP_buff_1 = (HP_base * 20) / 100;
                Str_buff_1 = 30;
            }
            else if (Unit.Unit_ID == "H073")
            {
                HP_buff_2 = (HP_base * 20) / 100;
                Str_buff_2 = 60;
            }
        }
        unit_want_get_talent.Str += Str_buff_1;
        //Debug.Log("Str buff 1 " + Str_buff_1);
        unit_want_get_talent.Str += Str_buff_2;
        //Debug.Log("Str buff 2 " + Str_buff_2);
        unit_want_get_talent.HP_max += HP_buff_1;
        //Debug.Log("HP buff 1 " + HP_buff_1);
        unit_want_get_talent.HP_max += HP_buff_2;
        //Debug.Log("HP buff 2 " + HP_buff_2);
        unit_want_get_talent.HP_current = unit_want_get_talent.HP_max;
        unit_want_get_talent.bar.SetMaxHP(unit_want_get_talent.HP_max);


    }
    private void H003_CamNinh(BaseEntiny unit_use_Skill)
    {
        
    }

    private void H004_CaoThuan(BaseEntiny unit_want_get_talent)
    {
        throw new NotImplementedException();
    }

    private void H006_ChuThai(BaseEntiny unit_want_get_talent)
    {
       
    }

    private void H007_GiaQuy(BaseEntiny unit_want_get_talent)
    {
        
    }

    private void H008_HaHauDon(BaseEntiny unit_want_get_talent)
    {
        
    }

    private void H021_HoaHung(BaseEntiny unit_want_get_talent)
    {
       
    }

    private void H032_LuuBi(BaseEntiny unit_want_get_talent)
    {
        unit_want_get_talent.stack = 1;
        unit_want_get_talent.bar.SetStack(1);
        Debug.Log(unit_want_get_talent.UnitTeam());
        BaseEntiny trandao = Instantiate(BattleSystem.instance.allEntitiesPrefab[1]);
        unit_want_get_talent.summon_by_Unit.Add(trandao);
        //BattleSystem.instance.entities_summon_Byteam[unit_want_get_talent.UnitTeam()].Add(trandao);
    }
    private void H042_QuanVu(BaseEntiny unit_want_get_talent)
    {
        Debug.Log("quan vu talent");
    }

    private void H043_TruongPhi(BaseEntiny unit_want_get_talent)
    {
        Debug.Log("truong phi talent");
    }


    private bool Have_Hero_InTeam(string ID, Team teamcheck)
    {
        foreach(BaseEntiny hero in BattleSystem.instance.unitOfTeam[teamcheck])
        {
            if (hero.Unit_ID == ID)
            {
                return true;
            }
            else return false;
        }
        return false;
    }
    
}
