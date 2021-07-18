using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Unit_Collection : MonoBehaviour
{
    #region Properties

    #region Hero List
    [Header("All Hero")]
    public GameObject original_button;
    public Transform content;  
    public GameObject infoHero;

    public Toggle setView_1Cost;
    public Toggle setView_2Cost;
    public Toggle setView_3Cost;
    public Toggle setView_All_Cost;

    public static Unit_Collection instance;


    private List<GameObject> listHero_1Cost;
    private List<GameObject> listHero_2Cost;
    private List<GameObject> listHero_3Cost;
    private Transform transformStar;
    private Transform transformCost;
    private UnitGraph unitGraph;

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

    [Header("Unit Infomation")]
    public Text Hero_name;
    public Text discription;
    public Image avatar;
    public Sprite BG1Cost;
    public Sprite BG2Cost;
    public Sprite BG3Cost;

    public Text talent_name;
    public Text talent_discription;

    public Text skill_name;
    public Text skill_discription;

    public Text faction;
    public Text type;

    public Text HP;
    public Text HP_perLv;
    public Text SP_max;
    public Text SP_regen;
    public Text Int;
    public Text Int_perLv;

    public Text Str;
    public Text Str_perLv;
    public Text Atk_Speed;
    public Text Range;

    public GameObject Cost1;
    public GameObject Cost2;
    public GameObject Cost3;

    public static string Hero_ID;

    private int Cost;
    #endregion

    #endregion

    #region Initialize
    void Awake()
    {
        instance = this;
        listHero_1Cost = new List<GameObject>();
        listHero_2Cost = new List<GameObject>();
        listHero_3Cost = new List<GameObject>();

        LoadAll_Hero_toHeroList();
        setView_All_Cost.isOn = true;
        SetView_AllCost();

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

    void LoadAll_Hero_toHeroList()
    {

        Game_Database gamedata = Save_System.LoadGame();

        foreach(Unit hero in gamedata.units)
        {
            
            unitGraph = DataGraph.Get_Graph_ByID(hero.ID);
            GameObject hero_preb = Instantiate(original_button, content); 
            hero_preb.transform.Find("Hero name").GetComponent<Text>().text = hero.Unit_name;
            hero_preb.transform.Find("Avatar").GetComponent<Image>().sprite = unitGraph.UnitAvatar;
            
            LoadHeroCost(hero.Cost, hero_preb.transform);
            SortByCost(hero_preb, hero.Cost);
            Set_Background_byCost(hero.Cost, hero_preb);
            hero_preb.GetComponent<Button>().onClick.AddListener(() => SetUI( hero));
            
        }
        Destroy(original_button);
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

    private void SetUI(Unit hero)
    {
        Hero_ID = hero.ID;

        Hero_name.text = hero.Unit_name;
        
        discription.text = hero.description;
        UnitGraph heroGraph = DataGraph.Get_Graph_ByID(Hero_ID);

        avatar.sprite = heroGraph.UnitAvatar;

        talent_name.text = hero.talent_name;
        talent_discription.text = hero.talent_description;

        skill_name.text = hero.skill_name;
        skill_discription.text = hero.skill_description;

        faction.text = SetTextFaction(hero.unitFaction);
        type.text = SetTextClass(hero.unitClass);

        HP.text = hero.HP.ToString();
        HP_perLv.text = hero.HP_perLv.ToString();

        SP_max.text = hero.SP_max.ToString();
        SP_regen.text = hero.SP_regen.ToString();
        Int.text = hero.Int.ToString();
        Int_perLv.text = hero.Int_perLv.ToString();

        Atk_Speed.text = hero.Atk_Speed.ToString();
        Str.text = hero.Str.ToString();
        Str_perLv.text = hero.Str_perLv.ToString();
        Range.text = hero.Range.ToString();


        Cost = hero.Cost;
        
        switch (Cost)
        {
            case 1:
                Cost1.SetActive(true);
                Cost2.SetActive(false);
                Cost3.SetActive(false);
                break;

            case 2:
                Cost1.SetActive(false);
                Cost2.SetActive(true);
                Cost3.SetActive(false);
                break;
            case 3:
                Cost1.SetActive(false);
                Cost2.SetActive(false); 
                Cost3.SetActive(true);        
                break;
        }
        infoHero.SetActive(true);
        notifyRecruiIsActive = false;
        notifyRecruit.SetActive(notifyRecruiIsActive);
    }

    private string SetTextFaction(UnitFaction unitFaction)
    {
        switch (unitFaction)
        {
            case UnitFaction.VietNam:
                return UnitString.VietNam;
            case UnitFaction.MongNguyen:
                return UnitString.MongNguyen;
            case UnitFaction.Khmer:
                return UnitString.Champa;
            case UnitFaction.Champa:
                return UnitString.Champa;
            case UnitFaction.VietRoyal:
                return UnitString.Champa;
            case UnitFaction.Thai:
                return UnitString.Champa;
            default:
                return UnitString.Champa;
        }
    }

    private string SetTextClass(UnitClass unitclass)
    {
        switch (unitclass)
        {
            case UnitClass.Infantry:
                return UnitString.Infantry;
            case UnitClass.Archer:
                return UnitString.Archer;
            case UnitClass.Cavalry:
                return UnitString.Cavalry;
            case UnitClass.WarElephant:
                return UnitString.Cavalry;
            case UnitClass.RoyalGuard:
                return UnitString.Cavalry;
            case UnitClass.Mandarin:
                return UnitString.Cavalry;
            case UnitClass.Marine:
                return UnitString.Cavalry;
            case UnitClass.Partisans:
                return UnitString.Cavalry;
            default:
                return UnitString.Cavalry;
        }
    }

    private void Set_Background_byCost(int cost, GameObject button)
    {
        switch (cost)
        {
            case 1:
                button.GetComponent<Image>().sprite = BG1Cost;
                break;
            case 2:
                button.GetComponent<Image>().sprite = BG2Cost;
                break;
            case 3:
                button.GetComponent<Image>().sprite = BG3Cost;
                break;
        }
    }

    public void SetView_AllCost()
    {
        if (setView_All_Cost.isOn)
        {
            setView_1Cost.isOn = false;
            setView_2Cost.isOn = false;
            setView_3Cost.isOn = false;
            foreach (GameObject hero_avatar in listHero_1Cost)
            {
                hero_avatar.SetActive(true);
            }
            foreach (GameObject hero_avatar in listHero_2Cost)
            {
                hero_avatar.SetActive(true);
            }
            foreach (GameObject hero_avatar in listHero_3Cost)
            {
                hero_avatar.SetActive(true);
            }
        }
    }

    public void SetView_1Cost()
    {
        if (setView_1Cost.isOn)
        {
            setView_All_Cost.isOn = false;
            setView_2Cost.isOn = false;
            setView_3Cost.isOn = false;
            foreach(GameObject hero_avatar in listHero_1Cost)
            {
                hero_avatar.SetActive(true);
            }
            foreach (GameObject hero_avatar in listHero_2Cost)
            {
                hero_avatar.SetActive(false);
            }
            foreach (GameObject hero_avatar in listHero_3Cost)
            {
                hero_avatar.SetActive(false);
            }
        }  
    }

    public void SetView_2Cost()
    {
        if (setView_2Cost.isOn)
        {
            setView_All_Cost.isOn = false;
            setView_1Cost.isOn = false;
            setView_3Cost.isOn = false;
            foreach (GameObject hero_avatar in listHero_1Cost)
            {
                hero_avatar.SetActive(false);
            }
            foreach (GameObject hero_avatar in listHero_2Cost)
            {
                hero_avatar.SetActive(true);
            }
            foreach (GameObject hero_avatar in listHero_3Cost)
            {
                hero_avatar.SetActive(false);
            }
        }
    }

    public void SetView_3Cost()
    {
        if (setView_3Cost.isOn)
        {
            setView_All_Cost.isOn = false;
            setView_2Cost.isOn = false;
            setView_1Cost.isOn = false;
            foreach (GameObject hero_avatar in listHero_1Cost)
            {
                hero_avatar.SetActive(false);
            }
            foreach (GameObject hero_avatar in listHero_2Cost)
            {
                hero_avatar.SetActive(false);
            }
            foreach (GameObject hero_avatar in listHero_3Cost)
            {
                hero_avatar.SetActive(true);
            }
        }
    }

    void SortByCost(GameObject hero_preb, int cost)
    {
        switch (cost)
        {
            case 1:
                listHero_1Cost.Add(hero_preb);
                break;
            case 2:
                listHero_2Cost.Add(hero_preb);
                break;
            case 3:
                listHero_3Cost.Add(hero_preb);
                break;
        }
    }

    public void Close()
    {
        infoHero.SetActive(false);
    }

    public void Back_Main_menu()
    {
        SceneManager.LoadScene(ListScene.SelectScene.MainMenu.ToString());
    }

    #endregion
}
