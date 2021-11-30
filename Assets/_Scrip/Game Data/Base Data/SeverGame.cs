using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Initialize Data game form code to binformat
/// This class need remove when game build
/// </summary>
public class SeverGame : MonoBehaviour
{
    public void Create_game_data()
    {
        Game_Database game_data = new Game_Database();
        game_data.card = Create_allCard();
        Save_System.Save_Game_Data(game_data);
    }

    #region Card Database
    private List<Card> Create_allCard()
    {
        List<Card> allCard = new List<Card>();

        AddCardUnit_toAllCard(allCard);
        AddCardItem_toAllCard(allCard);

        return allCard;
    }

    private void AddCardUnit_toAllCard(List<Card> allCard)
    {
      
    }

    private void AddCardItem_toAllCard(List<Card> allCard)
    {
        for (int i = 0; i < 9; i++)
        {
            allCard.Add(BrokenSword());
        }
        
    }



    

    #region Item Data
    private Card BrokenSword()
    {
        Card item = new Card();
        item.cardType = CardType.Item;
        item.card_ItemID = CardItemID.BrokenSworld;
        item.CardName = CardString.BrokenSworld;
        item.description = CardString.BrokenSworld_Description;
        


        return item;
    }
    #endregion

    #endregion


    
   
}


