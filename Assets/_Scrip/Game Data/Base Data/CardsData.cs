using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardsData : MonoBehaviour
{
    
    public List<Card> allCards;
    public List<Card> allCardUnit;
    public List<Card> allCardItem;
    public static List<Card> playerAllCard;

    public AllEffect allEffect_Atk;


    private static CardsData instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static void LoadAllPlayerCard()
    {
        var playerData = Save_System.LoadPlayer();

        foreach (var playerCard in playerData.playerCard)
        {
            Card card = ConvertCard.PlayerCardToCard(playerCard);
            playerAllCard.Add(card);
        }
    }

    public static EffectATK Get_Effect_Atk_By_ID(CardUnitID id)
    {
        return instance.allEffect_Atk.all_effectAtk.FirstOrDefault(i => i.ID == id);
    }

    public static EffectSkill Get_Effect_Skill_By_ID(CardUnitID id)
    {
        return instance.allEffect_Atk.all_effectSkill.FirstOrDefault(i => i.ID == id);
    }

    public static List<Card> ALLCard() { return instance.allCards;}

    public static List<Card> ALLCardItem() { return instance.allCardItem; }

    public static List<Card> ALLCardUnit() { return instance.allCardUnit; }


    public static Sprite Get_AvatarCard(Card card)
    {
        switch (card.cardType)
        {
            case CardType.Unit:
                return Get_AvatarByID(card.card_UnitID);
            case CardType.Item:
                return Get_AvatarByID(card.card_ItemID);
            default:
                throw new System.Exception("Cant get Graphic with card dont have type");
        }
    }
    private static Sprite Get_AvatarByID(CardUnitID id)
    {
        var card = instance.allCardUnit.FirstOrDefault(i => i.card_UnitID== id);
        return card.CardAvatar;
    }
    private static Sprite Get_AvatarByID(CardItemID id)
    {   
        var card = instance.allCardItem.FirstOrDefault(i => i.card_ItemID == id);
        return card.CardAvatar;
    }


   


}
