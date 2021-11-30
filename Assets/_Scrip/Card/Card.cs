using UnityEngine;

public enum CardType
{
    DontHaveType,
    Unit,
    Item
}

[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{

    public CardProperties[] cardPpt;

    public CardType cardType;
    public CardUnitID card_UnitID;
    public CardItemID card_ItemID;
    public bool unlocked = true;
    public Rank rank;
    public int Cost;

    [Range(0, 10)]
    public int AtkDameToLife;
    [Range(0, 10)]
    public int GoldDrop;

    [Header("Unit")]
    public UnitClass unitClass;
    public UnitFaction unitFaction;

    [Header("Item")]
    public ItemType itemType;
  
    [Header("Stat for Unit")]
    public int HP;
    public int Int;
    public int Str;
    public int PhysicReduction;
    public int MagicReduction;
    public float AtkSpeed;
    public int SPRegen = 5;
    public int SPMax;
    public int SPCurrent;
    public bool HaveSPBar = false;
    public bool HaveStackBar = false;
    public float SpeedProjectile = 0;
    [Range(1,4)]
    public int Range = 1;
      
    [Header("Stat for Item")]
    public int HpBonus;

    [Header("Graphic")]
    public Sprite RankLabel;
    public Sprite CardAvatar;
    public MeshFilter mesh;
    public Material mat;

    [Header("Text")]
    public string CardName;
    [TextArea]
    public string description;
    public string SkillName;
    [TextArea]
    public string SkillDescription;
}


