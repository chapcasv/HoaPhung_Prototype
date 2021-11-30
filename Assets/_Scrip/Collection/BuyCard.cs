using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCard : MonoBehaviour
{
    
    public GameObject InfoUI;

    private PlayerCard hero;
    private Game_Database game_data;
    private Card hero_want_recrui;

    //public void Recrui_hero()
    //{
    //    hero_want_recrui = Get_hero_ByID();
    //    if (Have_money_to_buy(hero_want_recrui) && !Card_is_ours(hero_want_recrui.card_UnitID))
    //    {
    //        Decrease_Money(hero_want_recrui);
    //        //Take_hero(hero_want_recrui);
    //        InfoUI.SetActive(false);
    //        Card_Collection.instance.Create_NotifyRecruit();

    //    }
    //    else
    //    {
    //        Debug.Log("chieu mo ko thanh cong");
    //    }
    //}

    #region Check
    private Card Get_hero_ByID()
    {
        Card hero = new Card();
        game_data = Save_System.LoadGame();
        //foreach (Card unit in game_data.card)
        //{
        //    if (unit.card_UnitID == Card_Collection.Hero_ID)
        //    {
        //        hero = unit;
        //    }
        //}
        return hero;
    }

    //private bool Card_is_ours(CardUnitID hero_ID)
    //{
    //    bool card_is_our = true;
    //    Player_Database data = Save_System.LoadPlayer();
    //    if (data.playerCard == null) return !card_is_our;
    //    foreach (PlayerCard card in data.playerCard)
    //    {
    //        if(card.card.card_UnitID == hero_ID)
    //        {
    //            return card_is_our;
    //        }
    //    }
    //    return !card_is_our;
    //}

    private int Get_hero_cost(Card card_want_buy)
    {
        game_data = Save_System.LoadGame();
        
        foreach (Card hero in game_data.card)
        {
            if (hero == card_want_buy)
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

    private bool Have_money_to_buy(Card card_want_Buy)
    {
        if(Save_System.Load_playerMoney() >= Get_hero_cost(card_want_Buy))
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
    private void Decrease_Money(Card card_want_buy)
    {
        int player_money = Save_System.Load_playerMoney();
        int hero_cost = Get_hero_cost(card_want_buy);
        

        player_money -= hero_cost;
      
        Player_Database data =  Save_System.LoadPlayer();
        data.money = player_money;
        Save_System.SaveData(data);
    }

    //private void Take_hero(Card hero_want_recrui)
    //{
    //    Card newCard = new Card();

        
    //    newCard.card_UnitID = hero_want_recrui.card_UnitID;
    //    newCard.cardName = hero_want_recrui.cardName;
    //    newCard.unitClass = hero_want_recrui.unitClass;
    //    newCard.unitFaction = hero_want_recrui.unitFaction;
    //    newCard.description = hero_want_recrui.description;

    //    newCard.HP = hero_want_recrui.HP;

    //    newCard.SP_max = hero_want_recrui.SP_max;
    //    newCard.SP_regen = hero_want_recrui.SP_regen;
    //    newCard.SP_current = hero_want_recrui.SP_current;

    //    newCard.Int = hero_want_recrui.Int;

    //    newCard.Atk_Speed = hero_want_recrui.Atk_Speed;

    //    newCard.Str = hero_want_recrui.Str;

    //    newCard.skill_name = hero_want_recrui.skill_name;
    //    newCard.skill_description = hero_want_recrui.skill_description;

    //    newCard.talent_description = hero_want_recrui.talent_description;
    //    newCard.talent_name = hero_want_recrui.talent_name;

    //    newCard.Have_SP_bar = hero_want_recrui.Have_SP_bar;
    //    newCard.Have_Stack_bar = hero_want_recrui.Have_Stack_bar;


    //    newCard.Cost = hero_want_recrui.Cost;

    //    newCard.Range = hero_want_recrui.Range;
    //    newCard.Speed_Projectile = hero_want_recrui.Speed_Projectile;

    //    PlayerCard newPlayerCard = new PlayerCard();
    //    newPlayerCard.card = newCard;

    //    Player_Database data = Save_System.LoadPlayer();

        //if(data.playerCard == null)
        //{
        //    data.playerCard = new List<PlayerCard>() { new_hero };
        //    Save_System.SaveData(data);
        //}
        //else
        //{
        //    data.playerCard.Add(new_hero);
        //    Save_System.SaveData(data);
        //}
        

    //}
    #endregion
}
