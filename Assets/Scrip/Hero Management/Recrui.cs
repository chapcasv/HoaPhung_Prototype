using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recrui : MonoBehaviour
{
    
    public GameObject InfoUI;

    private UnitOfPlayer hero;
    private Game_Database game_data;
    private Unit hero_want_recrui;

    public void Recrui_hero()
    {
        hero_want_recrui = Get_hero_ByID();
        if (Have_money_to_buy(hero_want_recrui) && !Hero_is_ours(hero_want_recrui.ID))
        {
            Decrease_Money(hero_want_recrui);
            Take_hero(hero_want_recrui);
            InfoUI.SetActive(false);
            Unit_Collection.instance.Create_NotifyRecruit();

        }
        else
        {
            Debug.Log("chieu mo ko thanh cong");
        }
    }

    #region Check
    private Unit Get_hero_ByID()
    {
        Unit hero = new Unit();
        game_data = Save_System.LoadGame();
        foreach (Unit unit in game_data.units)
        {
            if (unit.ID == Unit_Collection.Hero_ID)
            {
                hero = unit;
            }
        }
        return hero;
    }

    private bool Hero_is_ours(string hero_ID)
    {
        bool hero_is_our = true;
        Player_Database data = Save_System.LoadPlayer();
        if (data.hero_list == null) return !hero_is_our;
        foreach (UnitOfPlayer hero in data.hero_list)
        {
            if(hero.HeroID == hero_ID)
            {
                return hero_is_our;
            }
        }
        return !hero_is_our;
    }

    private int Get_hero_cost(string hero_ID)
    {
        game_data = Save_System.LoadGame();
         
        foreach (Unit hero  in game_data.units)
        {
            if (hero.ID == hero_ID)
            {
                switch (hero.Cost)
                {
                    case 1:
                        return 100;
                    case 2:
                        return 200;
                    case 3:
                        return 1000;
                }
                
            }
        }
        return 0;
    }

    private bool Have_money_to_buy(Unit hero_want_rec)
    {
        if(Save_System.Get_player_money() >= Get_hero_cost(hero_want_rec.ID))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
    #region Buy
    private void Decrease_Money(Unit hero_want_recrui)
    {
        int player_money = Save_System.Get_player_money();
        int hero_cost = Get_hero_cost(hero_want_recrui.ID);
        

        player_money -= hero_cost;
      
        Player_Database data =  Save_System.LoadPlayer();
        data.money = player_money;
        Save_System.SaveData(data);
    }

    private void Take_hero(Unit hero_want_recrui)
    {
        UnitOfPlayer new_hero = new UnitOfPlayer();

        new_hero.HeroID = hero_want_recrui.ID;
        new_hero.Hero_name = hero_want_recrui.Unit_name;
        new_hero.unitClass = hero_want_recrui.unitClass;
        new_hero.unitFaction = hero_want_recrui.unitFaction;
        new_hero.description = hero_want_recrui.description;

        new_hero.HP = hero_want_recrui.HP;
        new_hero.HP_perLv = hero_want_recrui.HP_perLv;

        new_hero.SP_max = hero_want_recrui.SP_max;
        new_hero.SP_regen = hero_want_recrui.SP_regen;
        new_hero.SP_current = hero_want_recrui.SP_current;

        new_hero.Int = hero_want_recrui.Int;
        new_hero.Int_perLv = hero_want_recrui.Int_perLv;

        new_hero.Atk_Speed = hero_want_recrui.Atk_Speed;

        new_hero.Str = hero_want_recrui.Str;
        new_hero.Str_perLv = hero_want_recrui.Str_perLv;

        new_hero.skill_name = hero_want_recrui.skill_name;
        new_hero.skill_description = hero_want_recrui.skill_description;

        new_hero.talent_description = hero_want_recrui.talent_description;
        new_hero.talent_name = hero_want_recrui.talent_name;

        new_hero.Have_SP_bar = hero_want_recrui.Have_SP_bar;
        new_hero.Have_stack_bar = hero_want_recrui.Have_Stack_bar;

        new_hero.slot1 = Convert_Data.Convert_Item_to_Item_database(DataGraph.Get_Item_Default());
        new_hero.slot2 = Convert_Data.Convert_Item_to_Item_database(DataGraph.Get_Item_Default());
        new_hero.slot3 = Convert_Data.Convert_Item_to_Item_database(DataGraph.Get_Item_Default());
        new_hero.slot4 = Convert_Data.Convert_Item_to_Item_database(DataGraph.Get_Item_Default());


        new_hero.Cost = hero_want_recrui.Cost;
        new_hero.level = 1;
        new_hero.exp_current = 0;
        new_hero.exp_max = Exp.MaxExp(new_hero.level);
        new_hero.Range = hero_want_recrui.Range;
        new_hero.Speed_projectile = hero_want_recrui.Speed_Projectile;
       

        Player_Database data = Save_System.LoadPlayer();

        if(data.hero_list == null)
        {
            data.hero_list = new List<UnitOfPlayer>() { new_hero };
            Save_System.SaveData(data);
        }
        else
        {
            data.hero_list.Add(new_hero);
            Save_System.SaveData(data);
        }
        

    }
    #endregion
}
