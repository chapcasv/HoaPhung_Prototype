using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardHandUI : MonoBehaviour
{
    [Header("Start Card Hand")]
    [SerializeField] GameObject startCardHandOBJ;
    private static List<Card> CardInHand;
    private const string key_Avatar = "Avatar";
    private const string key_CardName = "CardName";
    private const string key_Rank = "Rank";

    [Header("Child")]
    [SerializeField] Transform HandSlot1;
    private bool slot1CanReplace = true;
    [SerializeField] Transform HandSlot2;
    private bool slot2CanReplace = true;
    [SerializeField] Transform HandSlot3;
    private bool slot3CanReplace = true;
    [SerializeField] Transform HandSlot4;
    private bool slot4CanReplace = true;

    [Header("Card Hand")]
    [SerializeField] Transform handTransform;
    [SerializeField] Transform cardBattlePrefab;
    private const int maxCard = 7;
    private bool handTransform_IsActive = true;

    public void Load()
    {
        CardInHand = BattleDeckSystem.startCardHand();
        for (int i = 0; i < BattleDeckSystem.startCardHandAmount; i++)
        {
            var slot = startCardHandOBJ.transform.GetChild(i);
            slot.GetChild(0).Find(key_Avatar).GetComponent<Image>().sprite = CardsData.Get_AvatarCard(CardInHand[i]);
            slot.GetChild(0).Find(key_CardName).GetComponent<TextMeshProUGUI>().text = CardInHand[i].CardName;
        }
    }

    public void ChangeToDrawPhase()
    {
        startCardHandOBJ.SetActive(false);
        InstantiateCard();
        DrawPhase();
    }

    public void DrawPhase()
    {
        CardInHand.Add(BattleDeckSystem.DrawCard());
        ReloadCardInHand();
    }

    private void InstantiateCard()
    {
        for (int i = 0; i < maxCard; i++)
        {
            var card = Instantiate(cardBattlePrefab, handTransform);
            card.gameObject.SetActive(false);
        }

        LoadCards();
        VerticalLayout();
    }

    private void LoadCards()
    {   
        for (int i = 0; i < CardInHand.Count; i++)
        {
            Transform cardbattle = handTransform.GetChild(i);
            cardbattle.gameObject.SetActive(true);
            DisplayCardHand(CardInHand[i], cardbattle);
        }
    }

    private void LoadCardsAfterRemove(Transform slot)
    {
        slot.gameObject.SetActive(false);

    }

    private void DisplayCardHand(Card card, Transform cardBattle)
    {
        cardBattle.GetComponent<DragCardHand>().card = card;
        cardBattle.Find(key_Avatar).GetComponent<Image>().sprite = card.CardAvatar;
        cardBattle.Find(key_CardName).GetComponent<TextMeshProUGUI>().text = card.CardName;
        cardBattle.Find(key_Rank).GetComponent<Image>().sprite = card.RankLabel;
    }

    private void VerticalLayout()
    {
        float posx = GetPosX_topleft(GetSizeXHand(handTransform));
        float sizeX = GetSizeXCard(handTransform.GetChild(0));

        for (int i = 0; i < handTransform.childCount; i++)
        {
            float x = posx + (sizeX/2) + (sizeX * i);
            float y = handTransform.GetChild(i).localPosition.y;
            float z = handTransform.GetChild(i).localPosition.z;
            handTransform.GetChild(i).localPosition = new Vector3(x, y, z);
        }
    }

    private float GetSizeXHand(Transform handTransform)
    {
        RectTransform rect = (RectTransform)handTransform;
        return rect.sizeDelta.x;
    }

    private float GetSizeXCard(Transform card)
    {
        RectTransform rect = (RectTransform)card;
        return rect.sizeDelta.x;
    }

    private float GetPosX_topleft(float sizex) 
    {
        float PosX = (sizex/2) * -1;
        return PosX;
    }


    private void ReloadCardInHand()
    {
        LoadCards();
    }

    public void Set_Active_CardHand()
    {
        if (handTransform_IsActive)
        {
            handTransform_IsActive = false;
            handTransform.gameObject.SetActive(handTransform_IsActive);
        }
        else
        {
            handTransform_IsActive = true;
            handTransform.gameObject.SetActive(handTransform_IsActive);
        }
    }
    public void UnActive_UnitShop()
    {
        if (BattleSystem.Lose) return; //Frezze UI if player lose

        handTransform_IsActive = false;
        handTransform.gameObject.SetActive(handTransform_IsActive);
    }

    public void Active_UnitShop()
    {
        if (BattleSystem.Lose) return; //Frezze UI if player lose

        handTransform_IsActive = true;
        handTransform.gameObject.SetActive(handTransform_IsActive);
    }

    public void ReplaceSlot1()
    {
        if (slot1CanReplace)
        {
            Card card = BattleDeckSystem.Replace(CardInHand[0]);
            CardInHand[0] = card;
            HandSlot1.Find(key_Avatar).GetComponent<Image>().sprite = card.CardAvatar;
            HandSlot1.Find(key_CardName).GetComponent<TextMeshProUGUI>().text = card.CardName;
            slot1CanReplace = !slot1CanReplace;
        }
    }

    public void ReplaceSlot2()
    {
        if (slot2CanReplace)
        {
            Card card = BattleDeckSystem.Replace(CardInHand[1]);
            CardInHand[1] = card;
            HandSlot2.Find(key_Avatar).GetComponent<Image>().sprite = card.CardAvatar;
            HandSlot2.Find(key_CardName).GetComponent<TextMeshProUGUI>().text = card.CardName;
            slot2CanReplace = !slot2CanReplace;
        } 
    }

    public void ReplaceSlot3()
    {
        if (slot3CanReplace)
        {
            Card card = BattleDeckSystem.Replace(CardInHand[2]);
            CardInHand[2] = card;
            HandSlot3.Find(key_Avatar).GetComponent<Image>().sprite = card.CardAvatar;
            HandSlot3.Find(key_CardName).GetComponent<TextMeshProUGUI>().text = card.CardName;
            slot3CanReplace = !slot3CanReplace;
        }
    }

    public void ReplaceSlot4()
    {
        if (slot4CanReplace)
        {
            Card card = BattleDeckSystem.Replace(CardInHand[3]);
            CardInHand[3] = card;
            HandSlot4.Find(key_Avatar).GetComponent<Image>().sprite = card.CardAvatar;
            HandSlot4.Find(key_CardName).GetComponent<TextMeshProUGUI>().text = card.CardName;
            slot4CanReplace = !slot4CanReplace;
        }  
    }

    public void RemoveCard(Card card,Transform slot)
    {
        CardInHand.Remove(card);
        LoadCardsAfterRemove(slot);
    }

}
