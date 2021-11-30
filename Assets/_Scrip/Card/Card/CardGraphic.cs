using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Graphic", menuName = "Game Data/Card Graph")]

public class CardGraphic : ScriptableObject
{
    public CardType CardType;
    public MeshFilter CardFilter;
    public Material CardMat;
    public Sprite CardAvatar;
    public CardUnitID card_UnitID;
    public CardItemID card_ItemID;

}
