
public static class ConvertCard 
{
    public static PlayerCard CardToPlayerCard(Card card)
    {
        PlayerCard playerCard = new PlayerCard();

        if (card.card_ItemID != CardItemID.DontHaveItemID)
        {
            playerCard.card_ItemID = card.card_ItemID;
        }
        else if (card.card_UnitID != CardUnitID.DontHaveUnitID)
        {
            playerCard.card_UnitID = card.card_UnitID;
        }
        return playerCard;
    }

    public static Card PlayerCardToCard(PlayerCard playerCard)
    {
        Card cardBeforeConvert = null;
       
        if(playerCard.card_UnitID != CardUnitID.DontHaveUnitID)
        {
            var allCardUnit = CardsData.ALLCardUnit();
            foreach (var card in allCardUnit)
            {
                if(card.card_UnitID == playerCard.card_UnitID)
                {
                    cardBeforeConvert = card;
                    break;
                }
            }
        }else if(playerCard.card_ItemID != CardItemID.DontHaveItemID)
        {
            var allCardItem = CardsData.ALLCardItem();
            foreach (var card in allCardItem)
            {
                if (card.card_UnitID == playerCard.card_UnitID)
                {
                    cardBeforeConvert = card;
                    break;
                }
            }
        }

        return cardBeforeConvert;

    }
}
