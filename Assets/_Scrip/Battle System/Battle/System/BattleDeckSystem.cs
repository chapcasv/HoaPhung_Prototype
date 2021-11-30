using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDeckSystem : MonoBehaviour
{   
    public static readonly int startCardHandAmount = 4;
    private static List<Card> deckBeforeIni;

    public static Card DrawCard()
    {
        Card card = deckBeforeIni[0];
        deckBeforeIni.Remove(card);
        return card;
    }

    /// <summary>
    /// Pop 4 Card form Deck to Hand
    /// </summary>
    /// <returns>ListCard(3)</returns>
    public static List<Card> startCardHand()
    {
        List<Card> startCard = new List<Card>(3);
        deckBeforeIni = InitializePlayerDeck();

        for (int i = 0; i < startCardHandAmount; i++)
        {
            var cardPush = deckBeforeIni[0];
            startCard.Add(cardPush);
            deckBeforeIni.Remove(cardPush);
        }
        return startCard;
    }

    private static List<Card> InitializePlayerDeck()
    {
        List<Card> deckBeforeShuffle = Load_PlayerDeck_toBattle();
        List<Card> deckAfterShuffle = DeckShuffle(deckBeforeShuffle);
        return deckAfterShuffle;
    }

    private static List<Card> Load_PlayerDeck_toBattle()
    {   
        Decks deckDefault = DecksData.GetDefaultDeck();
        List<Card> deckBeforeShuffle = new List<Card>();

        foreach (var card in deckDefault.Cards)
        {
            deckBeforeShuffle.Add(card);
        }
        return deckBeforeShuffle;
    }

    private static List<Card> DeckShuffle(List<Card> deckBeforeShuffle)
    {
        List<Card> deckAfterShuffle = new List<Card>();

        int loopCount = deckBeforeShuffle.Count;
        for (int i = 0; i < loopCount; i++)
        {
            int randomIndexCard = Random.Range(0, deckBeforeShuffle.Count);
            deckAfterShuffle.Add(deckBeforeShuffle[randomIndexCard]);
            deckBeforeShuffle.RemoveAt(randomIndexCard);
        }
        return deckAfterShuffle;
    }

    public static Card Replace(Card cardWantReplace)
    {
        deckBeforeIni.Add(cardWantReplace);
        int indexRandom = Random.Range(0, deckBeforeIni.Count);
        Card newCard = deckBeforeIni[indexRandom];
        deckBeforeIni.RemoveAt(indexRandom);
        return newCard;
    }
}
