using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Card_Collection : MonoBehaviour
{
    #region Properties

    private const string key_cardTempChildName = "CardName";
    private const string key_cardTempChildAvatar = "Avatar";
    private const string key_cardTempChildLabelRank = "LabelRank";
   

    #region Hero List
    [Header("All Card")]
    [SerializeField] GameObject cardTemp;
    [SerializeField] Transform content;  
    [SerializeField] GameObject infomation;

    [Header("View Mode")]
    [SerializeField] Toggle setView_Unlocked;
    [SerializeField] Toggle setView_locked;
    [SerializeField] Toggle setView_All_Cost;
    [SerializeField] Toggle setView_3Cost;

    private readonly List<GameObject> listCard_1Cost = new List<GameObject>();
    private readonly List<GameObject> listCard_2Cost = new List<GameObject>();
    private readonly List<GameObject> listCard_3Cost = new List<GameObject>();
    private readonly List<GameObject> listCard_Unit = new List<GameObject>();
    private readonly List<GameObject> listCard_Item = new List<GameObject>();
    private readonly List<GameObject> listCard_unlock = new List<GameObject>();
    private readonly List<GameObject> listCard_locked = new List<GameObject>();

    private Transform transformStar;
    private Transform transformCost;

    [Header("Notify Recruit")]
    [SerializeField] private GameObject notifyRecruit;
    private Vector3 original_Pos;
    private bool notifyRecruiIsActive = false;
    private float disappearTime = 1f;
    private Color notifyColor;
    private float fadeSpeed = 0.8f;
    private float moveUpSpeed = 20f;
    private TextMeshProUGUI notifyRecruitTMP;

    #endregion

    #region Unit Infomation

    [Header("Card Infomation")]
    [SerializeField] Text Hero_name;
    [SerializeField] Text discription;
    [SerializeField] Image avatar;
    [SerializeField] Sprite Label_rank1;
    [SerializeField] Sprite Label_rank2;
    [SerializeField] Sprite Label_rank3;
    [SerializeField] Sprite Label_rank4;
    [SerializeField] Sprite Label_rank5;

    [SerializeField] Text talent_name;
    [SerializeField] Text talent_discription;

    [SerializeField] Text skill_name;
    [SerializeField] Text skill_discription;

    [SerializeField] Text faction;
    [SerializeField] Text type;

    [SerializeField] Text HP;
    [SerializeField] Text HP_perLv;
    [SerializeField] Text SP_max;
    [SerializeField] Text SP_regen;
    [SerializeField] Text Int;
    [SerializeField] Text Int_perLv;

    [SerializeField] Text Str;
    [SerializeField] Text Str_perLv;
    [SerializeField] Text Atk_Speed;
    [SerializeField] Text Range;

    [SerializeField] GameObject Cost1;
    [SerializeField] GameObject Cost2;
    [SerializeField] GameObject Cost3;

    public static CardUnitID card_UnitID;

    private int Cost;
    #endregion

    #endregion

    #region Initialize
    void Awake()
    {


        LoadAll_Card();
        setView_All_Cost.isOn = true;
        //SetView_AllCost();

        original_Pos = notifyRecruit.transform.position;
        notifyRecruit.SetActive(false);
    }

    #endregion

    #region Methods

    private void Update()
    {
        if (!notifyRecruiIsActive)
        {
            return;
        }
        else
        {
            FadeNotifyRecruit();
        }
    }
    
    private void FadeNotifyRecruit()
    {
        disappearTime -= Time.deltaTime;
        if(disappearTime <= 0)
        {
            notifyColor.a -= fadeSpeed * Time.deltaTime;
            notifyRecruit.transform.position += new Vector3(0, moveUpSpeed, 0) * Time.deltaTime;
            notifyRecruitTMP.color = notifyColor;
            if(notifyColor.a <= 0)
            {
                notifyRecruiIsActive = false;
                notifyRecruit.SetActive(notifyRecruiIsActive);
                notifyColor.a = 1;
                disappearTime = 2f;
                notifyRecruitTMP.color = notifyColor;
                notifyRecruit.transform.position = original_Pos;
            }
        }
    }

    public void Create_NotifyRecruit()
    {
        notifyRecruitTMP = notifyRecruit.GetComponent<TextMeshProUGUI>();
        notifyRecruiIsActive = true;
        notifyRecruit.SetActive(notifyRecruiIsActive);
        notifyColor = notifyRecruitTMP.color;
    }

    private void LoadAll_Card()
    {
        var allcard = CardsData.ALLCard();

        foreach(Card card in allcard)
        {

            GameObject card_prefab = Instantiate(cardTemp, content); 
            card_prefab.transform.Find(key_cardTempChildName).GetComponent<TextMeshProUGUI>().text = card.CardName;
            card_prefab.transform.Find(key_cardTempChildAvatar).GetComponent<Image>().sprite = card.CardAvatar;

            SetUp_Sort(card_prefab, card);
            Label_by_Rank(card.Cost, card_prefab);
            card_prefab.GetComponent<Button>().onClick.AddListener(() => SetUI( card));
            
        }
        cardTemp.SetActive(false);
    }

    void LoadHeroCost(int cost, Transform parrent)
    {
        transformCost = parrent.GetChild(2);
        transformStar = transformCost.GetChild(0);
        for (int i = 0; i < cost; i++)
        {
            Instantiate(transformStar, transformCost);
        }
        Destroy(transformStar.gameObject);
    }

    private void SetUI(Card card)
    {
        var Hero_ID = card.card_UnitID;

        Hero_name.text = card.CardName;
        
        discription.text = card.description;

        avatar.sprite = card.CardAvatar;
        skill_name.text = card.SkillName;
        skill_discription.text = card.SkillDescription;

        faction.text = SetTextFaction(card.unitFaction);
        type.text = SetTextClass(card.unitClass);

        HP.text = card.HP.ToString();

        SP_max.text = card.SPMax.ToString();
        SP_regen.text = card.SPRegen.ToString();
        Int.text = card.Int.ToString();

        Atk_Speed.text = card.AtkSpeed.ToString();
        Str.text = card.Str.ToString();

        Range.text = card.Range.ToString();


        Cost = card.Cost;
        
        infomation.SetActive(true);
        notifyRecruiIsActive = false;
        notifyRecruit.SetActive(notifyRecruiIsActive);
    }

    private string SetTextFaction(UnitFaction unitFaction)
    {
        switch (unitFaction)
        {
            case UnitFaction.Water:
                return CardString.Water;
            case UnitFaction.RockMountain:
                return CardString.RockMountain;
            case UnitFaction.Beast:
                return CardString.Beast;
            case UnitFaction.GodDragon:
                return CardString.GodDragon;
            default:
                return CardString.Beast;
        }
    }

    private string SetTextClass(UnitClass unitclass)
    {
        switch (unitclass)
        {
            case UnitClass.Warrior:
                return CardString.Warrior;
            case UnitClass.Hunter:
                return CardString.Hunter;
            case UnitClass.Cavalry:
                return CardString.Cavalry;
            default:
                return CardString.Cavalry;
        }
    }

    private void Label_by_Rank(int cost, GameObject card_prefab)
    {
        switch (cost)
        {
            case 1:
                card_prefab.transform.Find(key_cardTempChildLabelRank).GetComponent<Image>().sprite = Label_rank1;
                break;
            case 2:
                card_prefab.transform.Find(key_cardTempChildLabelRank).GetComponent<Image>().sprite = Label_rank2;
                break;
            case 3:
                card_prefab.transform.Find(key_cardTempChildLabelRank).GetComponent<Image>().sprite = Label_rank3;
                break;
            case 4:
                card_prefab.transform.Find(key_cardTempChildLabelRank).GetComponent<Image>().sprite = Label_rank4;
                break;
            case 5:
                card_prefab.transform.Find(key_cardTempChildLabelRank).GetComponent<Image>().sprite = Label_rank5;
                break;
        }
    }

    public void SetView_AllCost()
    {
        if (setView_All_Cost.isOn)
        {
            //setView_Unlocked.isOn = false;
            //setView_locked.isOn = false;

            for (int i = 0; i < content.childCount; i++)
            {
                content.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void SetView_Unlocked()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            content.GetChild(i).gameObject.SetActive(false);
        }
        foreach (var item in listCard_unlock)
        {
            item.SetActive(true);
        }
    }

    public void SetView_Locked()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            content.GetChild(i).gameObject.SetActive(false);
        }
        foreach (var item in listCard_locked)
        {
            item.SetActive(true);
        }

    }

    public void SetView_3Cost()
    {
        if (setView_3Cost.isOn)
        {
            setView_All_Cost.isOn = false;
            setView_locked.isOn = false;
            setView_Unlocked.isOn = false;
            foreach (GameObject hero_avatar in listCard_1Cost)
            {
                hero_avatar.SetActive(false);
            }
            foreach (GameObject hero_avatar in listCard_2Cost)
            {
                hero_avatar.SetActive(false);
            }
            foreach (GameObject hero_avatar in listCard_3Cost)
            {
                hero_avatar.SetActive(true);
            }
        }
    }

    private void SetUp_Sort(GameObject card_prefab, Card card)
    {
        SetUp_SortByRank(card_prefab, card);
        SetUp_SortByType(card_prefab, card);
        SetUp_SortByUnlock(card_prefab, card);
    }

    private void SetUp_SortByType(GameObject card_prefab, Card card)
    {
        switch (card.cardType)
        {
            case CardType.Unit:
                listCard_Unit.Add(card_prefab);
                break;
            case CardType.Item:
                listCard_Item.Add(card_prefab);
                break;
        }
    }

    private void SetUp_SortByUnlock(GameObject card_prefab, Card card)
    {
        if (card.unlocked)
        {
            listCard_unlock.Add(card_prefab);
        }
        else listCard_locked.Add(card_prefab);
    }

    private void SetUp_SortByRank(GameObject card_prefab, Card card)
    {
        switch (card.Cost)
        {
            case 1:
                listCard_1Cost.Add(card_prefab);
                break;
            case 2:
                listCard_2Cost.Add(card_prefab);
                break;
            case 3:
                listCard_3Cost.Add(card_prefab);
                break;
        }
    }

    public void Close()
    {
        infomation.SetActive(false);
    }

    public void Back_Main_menu()
    {
        SceneManager.LoadScene(SelectScene.MainMenu.ToString());
    }

    #endregion
}
