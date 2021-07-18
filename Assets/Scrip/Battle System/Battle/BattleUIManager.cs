using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BattleUIManager : Manager<BattleUIManager>
{
    #region Properties

    [Header("Unit Shop")]
    [SerializeField] GameObject Unit_avatar;
    [SerializeField] Transform Unitcontent;
    [SerializeField] Sprite label1Cost;
    [SerializeField] Sprite label2Cost;
    [SerializeField] Sprite label3Cost;
    [SerializeField] GameObject UnitShop;

    [Header("Team Infomation")]
    [SerializeField] Text textUnitAmount;
    [SerializeField] Transform warringPopUpUi_transform;
    private bool activeWarringUI = false;
    private float moveUpSpeed = 0.7f;
    private float disappearTime = 2f;
    private float fadeSpeed = 2f;
    private Color warringTextColor;
    private Vector3 originalPos_warringUI;
    private TextMeshProUGUI warringTMP;

    [Header("Synergy UI")]
    [SerializeField] GameObject SynergyUI;

    [Header("Dialog Win/Lose")]
    [SerializeField] GameObject DialogWinUI;
    [SerializeField] TextMeshProUGUI result;
    [SerializeField] TextMeshProUGUI point;

    [Header("Time Cowndown")]
    [SerializeField] Slider slider_timeBattle;
    private const float transitionOutBattleMode = 2f;
    
    private readonly Color32 textHighLight = new Color32(0, 255, 255, 255);

    private UnitGraph unitGraph;
    private List<GameObject> one_star;
    private List<GameObject> two_star;
    private List<GameObject> three_star;
    private bool UnitShop_IsActive = true;

    private GameObject Default_SynergyUI;

    private GameObject InfantryUI;
    private GameObject ArcherUI;
    private GameObject CavalryUI;

    private GameObject VietNamUI;
    private GameObject MongNguyenUI;
    private GameObject ChamPaUI;

    private int maxBaseEntiny;
    
    private const string defaultSynergyUI = "Default_SynergyUI";
    private const string nameSynergy = "Name Synergy";
    private const string amount = "Amount";
    private const string resultWin = "Thắng";
    private const string pointWin = "Quân ta dũng mãnh đánh bại toàn bộ địch";
    private const string pointLose = "Hãy nâng cấp quân đội sau đó quay trở lại";
    private const string resultLose = "Thua";
    private const string warringPopUp_text = "Lượng tướng vượt quá Quân Lực cho phép";
    private const string BackgroundName = "Background Name";
    private const string BackgroundAmount = "Background Amount";

    public int MaxBaseEntiny { get => maxBaseEntiny; set => maxBaseEntiny = value; }


    #endregion

    #region Methods
    void Start()
    {
        Hiden_Dialog();
        warringPopUpUi_transform.gameObject.SetActive(false);
        one_star = new List<GameObject>();
        two_star = new List<GameObject>();
        three_star = new List<GameObject>();
        Load_List_UnitOfPlayer();
        Set_view_mode_full();
        Get_Default_Synergy();
        UpdateUnitAmount(0);
    }

    private void Update()
    {
        WarringPopUp_Fade();
    }

    private void Get_Default_Synergy()
    {
        Default_SynergyUI = SynergyUI.transform.Find(defaultSynergyUI).gameObject;
        Default_SynergyUI.SetActive(false);
    }

    public void UpdateUnitAmount(int Amount)
    {   
        //We dont need to update went fight
        if (!BattleSystem.InBattleMode)
        {
            MaxBaseEntiny = BattleSystem.currentBattle.maxAmount;
            textUnitAmount.text = Amount + "/" + MaxBaseEntiny;
            SetColorUnitAmout(Amount);
        }  
    }
    
    public void SetColorUnitAmout(int Amount)
    {
        if(Amount < MaxBaseEntiny)
        {
            textUnitAmount.color = textHighLight;
        }
        else if( Amount == MaxBaseEntiny)
        {
            textUnitAmount.color = Color.white;
        }
        else if( Amount > MaxBaseEntiny)
        {
            textUnitAmount.color = Color.red;
        }
    }

    public void CreateWarringPopUp()
    {
        if (!activeWarringUI)
        {
            warringTMP = warringPopUpUi_transform.GetComponent<TextMeshProUGUI>();
            originalPos_warringUI = warringPopUpUi_transform.position;
            warringTMP.SetText(warringPopUp_text);
            warringTextColor = warringTMP.color;
            warringPopUpUi_transform.gameObject.SetActive(true);
            activeWarringUI = true;
        }   
    }

    private void WarringPopUp_Fade()
    {
        if (!activeWarringUI)
        {
            return;
        }
        else
        {
            disappearTime -= Time.deltaTime;
            if(disappearTime <= 0)
            {
                warringPopUpUi_transform.position += new Vector3(0, moveUpSpeed) * Time.deltaTime;
                warringTextColor.a -= fadeSpeed * Time.deltaTime;
                warringTMP.color = warringTextColor;

                if(warringTextColor.a <= 0)
                {
                    ResetWarringPopUp();
                }
            }
        }
    }

    private void ResetWarringPopUp()
    {
        activeWarringUI = false;
        disappearTime = 2f;
        warringTextColor.a = 1;
        warringTMP.color = warringTextColor;
        warringPopUpUi_transform.position = originalPos_warringUI;
        warringPopUpUi_transform.gameObject.SetActive(false);
    }

    public void Show_Dialog(bool win)
    {
        if (win)
        {
            result.text = resultWin;
            this.point.text = pointWin;
        }
        else
        {
            result.text = resultLose;
            this.point.text = pointLose;
        }
        DialogWinUI.SetActive(true);
    }

    public void Hiden_Dialog()
    {
        DialogWinUI.SetActive(false);
    }

    #region F_ChamPa
    public void ChamPa_UI()
    {
        if (F_ChamPa.ChamPaAmount_Current <= F_ChamPa.ChamPaAmount_Lv_1)
        {
            Load_ChamPa_data_to_UI(UnitFaction.Champa, F_ChamPa.ChamPaAmount_Current, F_ChamPa.ChamPaAmount_Lv_1);
        }
    }

    private void Load_ChamPa_data_to_UI(UnitFaction unitFaction, int currentAmount, int Lv_Amount)
    {
        if (ChamPaUI == null)
        {
            Create_ChamPaUI(unitFaction, currentAmount, Lv_Amount);
        }
        else
        {
            Update_ChamPaUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_ChamPaUI(UnitFaction unitFaction, int CurrentAmount, int Lv_Amount)
    {
        ChamPaUI = Instantiate(Default_SynergyUI, SynergyUI.transform);
        ChamPaUI.transform.Find(BackgroundName).Find(nameSynergy).GetComponent<Text>().text = UnitString.GetFactionString(unitFaction);
        ChamPaUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        ChamPaUI.SetActive(true);
    }

    private void Update_ChamPaUI(int CurrentAmount, int Lv_Amount)
    {   
        if(CurrentAmount != 0)
        {
            ChamPaUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            ChamPaUI.SetActive(true);
        }
        else
        {
            ChamPaUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            ChamPaUI.SetActive(false);
        }
        
    }
    #endregion

    #region F_MongNguyen
    public void MongNguyen_UI()
    {
        if (F_MongNguyen.MongNguyenAmount_Current <= F_MongNguyen.MongNguyenAmount_Lv_1)
        {
            Load_MongNguyen_data_to_UI(UnitFaction.MongNguyen, F_MongNguyen.MongNguyenAmount_Current, F_MongNguyen.MongNguyenAmount_Lv_1);
        }
    }

    private void Load_MongNguyen_data_to_UI(UnitFaction unitFaction, int currentAmount, int Lv_Amount)
    {
        if (MongNguyenUI == null)
        {
            Create_MongNguyenUI(unitFaction, currentAmount, Lv_Amount);
        }
        else
        {
            Update_MongNguyenUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_MongNguyenUI(UnitFaction unitFaction, int CurrentAmount, int Lv_Amount)
    {
        MongNguyenUI = Instantiate(Default_SynergyUI, SynergyUI.transform);
        MongNguyenUI.transform.Find(BackgroundName).Find(nameSynergy).GetComponent<Text>().text = UnitString.GetFactionString(unitFaction);
        MongNguyenUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        MongNguyenUI.SetActive(true);
    }

    private void Update_MongNguyenUI(int CurrentAmount, int Lv_Amount)
    {   
        if(CurrentAmount != 0)
        {
            MongNguyenUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            MongNguyenUI.SetActive(true);
        }
        else
        {
            MongNguyenUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            MongNguyenUI.SetActive(false);
        }
        
    }

    #endregion

    #region F_VietNam
    public void VietNam_UI()
    {
        if (F_VietNam.VietnamAmount_Current <= F_VietNam.VietnamrAmount_Lv_1)
        {
            Load_VietNam_data_to_UI(UnitFaction.VietNam, F_VietNam.VietnamAmount_Current, F_VietNam.VietnamrAmount_Lv_1);
        }
    }

    private void Load_VietNam_data_to_UI(UnitFaction unitFaction, int currentAmount, int Lv_Amount)
    {
        if (VietNamUI == null)
        {
            Create_VietNamUI(unitFaction, currentAmount, Lv_Amount);
        }
        else
        {
            Update_VietNamUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_VietNamUI(UnitFaction unitFaction, int CurrentAmount, int Lv_Amount)
    {
        VietNamUI = Instantiate(Default_SynergyUI, SynergyUI.transform);
        VietNamUI.transform.Find(BackgroundName).Find(nameSynergy).GetComponent<Text>().text = UnitString.GetFactionString(unitFaction);
        VietNamUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        VietNamUI.SetActive(true);
    }

    private void Update_VietNamUI(int CurrentAmount, int Lv_Amount)
    {   
        if(CurrentAmount != 0)
        {
            VietNamUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            VietNamUI.SetActive(true);
        }
        else
        {
            VietNamUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            VietNamUI.SetActive(false);
        }
        
    }

    #endregion

    #region U_Archer
    public void Archer_UI()
    {
        if (C_Archer.ArcherAmount_Current < C_Archer.ArcherAmount_Lv_1)
        {
            Load_Archer_data_to_UI(UnitClass.Archer, C_Archer.ArcherAmount_Current, C_Archer.ArcherAmount_Lv_1);
        }
        else if (C_Archer.ArcherAmount_Lv_1 <= C_Archer.ArcherAmount_Current && C_Archer.ArcherAmount_Current < C_Archer.ArcherAmount_Lv_2)
        {
            Load_Archer_data_to_UI(UnitClass.Archer, C_Archer.ArcherAmount_Current, C_Archer.ArcherAmount_Lv_2);
        }
        else if (C_Archer.ArcherAmount_Current == C_Archer.ArcherAmount_Lv_2)
        {
            Load_Archer_data_to_UI(UnitClass.Archer, C_Archer.ArcherAmount_Current, C_Archer.ArcherAmount_Lv_2);
        }
    }

    private void Load_Archer_data_to_UI(UnitClass unitClass, int currentAmount, int Lv_Amount)
    {
        if (ArcherUI == null)
        {
            Create_ArcherUI(unitClass, currentAmount, Lv_Amount);
        }
        else
        {
            Update_ArcherUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_ArcherUI(UnitClass unitClass, int currentAmount, int Lv_Amount)
    {
        ArcherUI = Instantiate(Default_SynergyUI, SynergyUI.transform);
        ArcherUI.transform.Find(BackgroundName).Find(nameSynergy).GetComponent<Text>().text = UnitString.GetClassString(unitClass);
        ArcherUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
        ArcherUI.SetActive(true);
    }

    private void Update_ArcherUI(int currentAmount, int Lv_Amount)
    {   
        if(currentAmount != 0)
        {
            ArcherUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            ArcherUI.SetActive(true);
        }
        else
        {
            ArcherUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            ArcherUI.SetActive(false);
        }
        
    }

    #endregion

    #region U_Cavalry
    public void Cavalry_UI()
    {
        
        if (C_Cavalry.CavalryAmount_Current < C_Cavalry.CavalryAmount_Lv_1)
        {
            Load_Cavalry_data_to_UI(UnitClass.Cavalry, C_Cavalry.CavalryAmount_Current, C_Cavalry.CavalryAmount_Lv_1);
        }
        else if (C_Cavalry.CavalryAmount_Lv_1 <= C_Cavalry.CavalryAmount_Current && C_Cavalry.CavalryAmount_Current < C_Cavalry.CavalryAmount_Lv_2)
        {
            Load_Cavalry_data_to_UI(UnitClass.Cavalry, C_Cavalry.CavalryAmount_Current, C_Cavalry.CavalryAmount_Lv_2);
        }
        else if (C_Cavalry.CavalryAmount_Lv_2 <= C_Cavalry.CavalryAmount_Current && C_Cavalry.CavalryAmount_Current < C_Cavalry.CavalryAmount_Lv_3)
        {
            Load_Cavalry_data_to_UI(UnitClass.Cavalry, C_Cavalry.CavalryAmount_Current, C_Cavalry.CavalryAmount_Lv_3);
        }
        else if (C_Cavalry.CavalryAmount_Current == C_Cavalry.CavalryAmount_Lv_3)
        {
            Load_Cavalry_data_to_UI(UnitClass.Cavalry, C_Cavalry.CavalryAmount_Current, C_Cavalry.CavalryAmount_Lv_3);
        }
    }

    private void Load_Cavalry_data_to_UI(UnitClass unitClass, int currentAmount, int Lv_Amount)
    {
        if (CavalryUI == null)
        {
            Create_CavalryUI(unitClass, currentAmount, Lv_Amount);
        }
        else
        {
            Update_CavalryUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_CavalryUI(UnitClass unitClass, int currentAmount, int Lv_Amount)
    {
        CavalryUI = Instantiate(Default_SynergyUI, SynergyUI.transform);
        CavalryUI.transform.Find(BackgroundName).Find(nameSynergy).GetComponent<Text>().text = UnitString.GetClassString(unitClass);
        CavalryUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
        CavalryUI.SetActive(true);
    }

    private void Update_CavalryUI(int currentAmount, int Lv_Amount)
    {   
        if(currentAmount != 0)
        {
            CavalryUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            CavalryUI.SetActive(true);
        }
        else
        {
            CavalryUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            CavalryUI.SetActive(false);
        }
    }
    #endregion

    #region U_Infantry
    public void Infantry_UI()
    {
        
        if(C_Infantry.InfantryAmount_Current < C_Infantry.InfantryAmount_Lv_1)
        {
            Load_Infantry_data_to_UI(UnitClass.Infantry, C_Infantry.InfantryAmount_Current, C_Infantry.InfantryAmount_Lv_1);
        }
        else if(C_Infantry.InfantryAmount_Lv_1 <= C_Infantry.InfantryAmount_Current && C_Infantry.InfantryAmount_Current < C_Infantry.InfantryAmount_Lv_2)
        {
            Load_Infantry_data_to_UI(UnitClass.Infantry, C_Infantry.InfantryAmount_Current, C_Infantry.InfantryAmount_Lv_2);
        }
        else if(C_Infantry.InfantryAmount_Lv_2 <= C_Infantry.InfantryAmount_Current && C_Infantry.InfantryAmount_Current < C_Infantry.InfantryAmount_Lv_3)
        {
            Load_Infantry_data_to_UI(UnitClass.Infantry, C_Infantry.InfantryAmount_Current, C_Infantry.InfantryAmount_Lv_3);
        }
        else if(C_Infantry.InfantryAmount_Current == C_Infantry.InfantryAmount_Lv_3)
        {
            Load_Infantry_data_to_UI(UnitClass.Infantry, C_Infantry.InfantryAmount_Current, C_Infantry.InfantryAmount_Lv_3);
        }
    }

    private void Load_Infantry_data_to_UI(UnitClass unitClass, int CurrentAmount, int Lv_Amount)
    {
        if (InfantryUI == null)
        {
            Create_InfantryUI(unitClass, CurrentAmount, Lv_Amount);
        }
        else
        {
            Update_InfantryUI(CurrentAmount, Lv_Amount);
        }  
    }

    private void Create_InfantryUI(UnitClass unitClass, int CurrentAmount, int Lv_Amount)
    {   
        InfantryUI = Instantiate(Default_SynergyUI, SynergyUI.transform);
        InfantryUI.transform.Find(BackgroundName).Find(nameSynergy).GetComponent<Text>().text = UnitString.GetClassString(unitClass);
        InfantryUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        InfantryUI.SetActive(true);
    }

    private void Update_InfantryUI(int CurrentAmount, int Lv_Amount)
    {   
        if(CurrentAmount != 0)
        {
            InfantryUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            InfantryUI.SetActive(true);
        }
        else
        {
            InfantryUI.transform.Find(BackgroundAmount).Find(amount).GetComponent<Text>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            InfantryUI.SetActive(false);
        }
        
    }

    #endregion
    private string Synergy_SetAmount_By_Form(int currentAmount, int lvAmount)
    {
        return currentAmount + "/" + lvAmount;
    }


    #region ScrollRect UnitOfPlayer>
    public void Load_List_UnitOfPlayer()
    {
        
        GameObject g;

        Player_Database data = Save_System.LoadPlayer();
        if (data.hero_list != null)
        {
            foreach (UnitOfPlayer unit in data.hero_list)
            {
                unitGraph = DataGraph.Get_Graph_ByID(unit.HeroID);
                g = Instantiate(Unit_avatar, Unitcontent);
                g.transform.Find("Text").GetComponent<Text>().text = unit.Hero_name;
                g.transform.Find("Avatar").GetComponent<Image>().sprite = unitGraph.UnitAvatar;
                g.transform.Find("ID").GetComponent<Text>().text = unit.HeroID;
                g.transform.Find("BG").GetComponent<Image>().sprite = Get_BackGround_avatar(unit);
                GameObject mask = g.transform.Find("Mask").gameObject;
                g.transform.GetComponent<Button>().onClick.AddListener(() => { MoveUnit(unit); MaskButton(mask); });
                Add_hero_to_List_gameOBJ(unit, g);
            }
        }

        Destroy(Unit_avatar);
    }

    private void MoveUnit(UnitOfPlayer hero)
    {
        
        if (!Unit_Is_onGrid(hero))
        {
            AddToGrid(hero);
        } 
    }
    private void MaskButton(GameObject mask)
    {
        mask.SetActive(true);
    }

    private void AddToGrid(UnitOfPlayer hero)
    {
        UnitGraph unitGraph = DataGraph.Get_Graph_ByID(hero.HeroID);
        BattleSystem.instance.AddUnit_For(Team.Team1, hero, unitGraph,Unit_Type.Hero);
    }

    public void UnitBackToList(BaseEntiny e)
    {
        foreach(Transform unit_button in Unitcontent)
        {   
            if(unit_button.Find("ID").GetComponent<Text>().text == e.Unit_ID)
            {
                unit_button.Find("Mask").gameObject.SetActive(false);
            }    
        }
    }

    
    private bool Unit_Is_onGrid(UnitOfPlayer hero)
    {   
        if(BattleSystem.instance.unitOfTeam[Team.Team1].Count <= 0)
        {
            return false;
        }
        else
        {
            foreach (BaseEntiny unit in BattleSystem.instance.unitOfTeam[Team.Team1])
            {
                if (unit.Unit_ID == hero.HeroID)
                {
                    return true;
                }
            }
            return false;
        }  
    }

    private void Add_hero_to_List_gameOBJ(UnitOfPlayer hero, GameObject g)
    {
        switch (hero.Cost)
        {
            case 1:
                one_star.Add(g);
                break;
            case 2:
                two_star.Add(g);
                break;
            case 3:
                three_star.Add(g);
                break;
        }
    }

    private Sprite Get_BackGround_avatar(UnitOfPlayer hero)
    {
        switch (hero.Cost)
        {
            case 1:
                return label1Cost;
            case 2:
                return label2Cost;
            case 3:
                return label3Cost;
            default:
                return label1Cost;
        }
    }
    public void Set_view_mode_3Star()
    {
        foreach (GameObject gameobj in three_star)
        {
            gameobj.SetActive(true);
        }
        foreach (GameObject gameobj in two_star)
        {
            gameobj.SetActive(false);
        }
        foreach (GameObject gameobj in one_star)
        {
            gameobj.SetActive(false);
        }
    }

    public void Set_view_mode_2Star()
    {
        foreach (GameObject gameobj in three_star)
        {
            gameobj.SetActive(false);
        }
        foreach (GameObject gameobj in two_star)
        {
            gameobj.SetActive(true);
        }
        foreach (GameObject gameobj in one_star)
        {
            gameobj.SetActive(false);
        }
    }

    public void Set_view_mode_1Star()
    {
        foreach (GameObject gameobj in three_star)
        {
            gameobj.SetActive(false);
        }
        foreach (GameObject gameobj in two_star)
        {
            gameobj.SetActive(false);
        }
        foreach (GameObject gameobj in one_star)
        {
            gameobj.SetActive(true);
        }
    }

    public void Set_view_mode_full()
    {
        foreach (GameObject gameobj in three_star)
        {
            gameobj.SetActive(true);
        }
        foreach (GameObject gameobj in two_star)
        {
            gameobj.SetActive(true);
        }
        foreach (GameObject gameobj in one_star)
        {
            gameobj.SetActive(true);
        }
    }

    public void Set_Active_UnitShop()
    {
        if (UnitShop_IsActive)
        {
            UnitShop_IsActive = false;
            UnitShop.gameObject.SetActive(UnitShop_IsActive);
        }
        else
        {
            UnitShop_IsActive = true;
            UnitShop.SetActive(UnitShop_IsActive);
        }
    }
    public void UnActive_UnitShop()
    {   
        if (BattleSystem.Lose) return; //Frezze UI if player lose

        UnitShop_IsActive = false;
        UnitShop.gameObject.SetActive(UnitShop_IsActive);
    }

    public void Active_UnitShop()
    {
        if (BattleSystem.Lose) return; //Frezze UI if player lose

        UnitShop_IsActive = true;
        UnitShop.gameObject.SetActive(UnitShop_IsActive);
    }
    #endregion

    public IEnumerator TimeBattle(float maxTimeBattle)
    {
        
        slider_timeBattle.maxValue = maxTimeBattle;
        slider_timeBattle.value = slider_timeBattle.maxValue;

        float sub = slider_timeBattle.maxValue / 200;

        while (slider_timeBattle.value > slider_timeBattle.minValue && BattleSystem.InBattleMode)
        {
            slider_timeBattle.value -= sub;

            yield return new WaitForSeconds(sub);
        }
        StartCoroutine(TransitionToOutBattleMode());
    }

    private IEnumerator TransitionToOutBattleMode()
    {
        
        slider_timeBattle.maxValue = transitionOutBattleMode;
        slider_timeBattle.value = slider_timeBattle.maxValue;

        float sub = slider_timeBattle.maxValue / 100;

        while (slider_timeBattle.value > slider_timeBattle.minValue)
        {
            slider_timeBattle.value -= sub;
            yield return new WaitForSeconds(sub);
        }
        ResetSliderTime();
        if (!BattleSystem.Lose)
        {
            Hiden_Dialog();
        }
        
    }

    private void ResetSliderTime()
    {
        slider_timeBattle.value = slider_timeBattle.maxValue;
    }
    #endregion

}
