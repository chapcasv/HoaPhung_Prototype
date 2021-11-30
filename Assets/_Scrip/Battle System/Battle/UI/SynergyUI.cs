using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SynergyUI : MonoBehaviour
{
    
    private GameObject Default_SynergyUI;
    private GameObject WarriorUI;
    private GameObject HunterUI;
    private GameObject CavalryUI;

    private GameObject WaterUI;
    private GameObject RockMountainUI;
    private GameObject BeastUI;
    private GameObject GodDragonUI;


    private const string defaultSynergyUI = "Default_SynergyUI";
    private const string nameSynergy = "Name Synergy";
    private const string amount = "Amount";
    private const string key_BackgroundName = "BackgroundName";
    private const string key_BackgroundAmount = "BackgroundAmount";

    
    public void SetUp()
    {
        Get_Default_Synergy();
    }

    private void Get_Default_Synergy()
    {
        Default_SynergyUI = transform.Find(defaultSynergyUI).gameObject;
        Default_SynergyUI.SetActive(false);
    }

    public void F_Beast_UI()
    {
        if (F_Beast.Amount_Current <= F_Beast.Amount_Lv_1)
        {
            Load_Beast_data_to_UI(UnitFaction.Beast, F_Beast.Amount_Current, F_Beast.Amount_Lv_1);
        }
    }

    private void Load_Beast_data_to_UI(UnitFaction unitFaction, int currentAmount, int Lv_Amount)
    {
        if (BeastUI == null)
        {
            Create_BeastUI(unitFaction, currentAmount, Lv_Amount);
        }
        else
        {
            Update_BeastUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_BeastUI(UnitFaction unitFaction, int CurrentAmount, int Lv_Amount)
    {
        BeastUI = Instantiate(Default_SynergyUI, transform);
        BeastUI.transform.Find(key_BackgroundName).Find(nameSynergy).GetComponent<TextMeshProUGUI>().text = CardString.GetFactionString(unitFaction);
        BeastUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        BeastUI.SetActive(true);
    }

    private void Update_BeastUI(int CurrentAmount, int Lv_Amount)
    {
        if (CurrentAmount != 0)
        {
            BeastUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            BeastUI.SetActive(true);
        }
        else
        {
            BeastUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            BeastUI.SetActive(false);
        }

    }


    public void F_GodDragon_UI()
    {
        if (F_GodDragon.Amount_Current <= F_GodDragon.Amount_Lv_1)
        {
            Load_GodDragon_data_to_UI(UnitFaction.GodDragon, F_GodDragon.Amount_Current, F_GodDragon.Amount_Lv_1);
        }
    }

    private void Load_GodDragon_data_to_UI(UnitFaction unitFaction, int currentAmount, int Lv_Amount)
    {
        if (GodDragonUI == null)
        {
            Create_GodDragonUI(unitFaction, currentAmount, Lv_Amount);
        }
        else
        {
            Update_GodDragonUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_GodDragonUI(UnitFaction unitFaction, int CurrentAmount, int Lv_Amount)
    {
        GodDragonUI = Instantiate(Default_SynergyUI, transform);
        GodDragonUI.transform.Find(key_BackgroundName).Find(nameSynergy).GetComponent<TextMeshProUGUI>().text = CardString.GetFactionString(unitFaction);
        GodDragonUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        GodDragonUI.SetActive(true);
    }

    private void Update_GodDragonUI(int CurrentAmount, int Lv_Amount)
    {
        if (CurrentAmount != 0)
        {
            GodDragonUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            GodDragonUI.SetActive(true);
        }
        else
        {
            GodDragonUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            GodDragonUI.SetActive(false);
        }

    }


    public void RockMountain_UI()
    {
        if (F_RockMountain.Amount_Current <= F_RockMountain.Amount_Lv_1)
        {
            Load_RockMountain_data_to_UI(UnitFaction.RockMountain, F_RockMountain.Amount_Current, F_RockMountain.Amount_Lv_1);
        }
    }

    private void Load_RockMountain_data_to_UI(UnitFaction unitFaction, int currentAmount, int Lv_Amount)
    {
        if (RockMountainUI == null)
        {
            Create_RockMountainUI(unitFaction, currentAmount, Lv_Amount);
        }
        else
        {
            Update_RockMountainUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_RockMountainUI(UnitFaction unitFaction, int CurrentAmount, int Lv_Amount)
    {
        RockMountainUI = Instantiate(Default_SynergyUI, transform);
        RockMountainUI.transform.Find(key_BackgroundName).Find(nameSynergy).GetComponent<TextMeshProUGUI>().text = CardString.GetFactionString(unitFaction);
        RockMountainUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        RockMountainUI.SetActive(true);
    }

    private void Update_RockMountainUI(int CurrentAmount, int Lv_Amount)
    {
        if (CurrentAmount != 0)
        {
            RockMountainUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            RockMountainUI.SetActive(true);
        }
        else
        {
            RockMountainUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            RockMountainUI.SetActive(false);
        }

    }

    public void Water_UI()
    {
        if (F_Water.Amount_Current <= F_Water.Amount_Lv_1)
        {
            Load_Water_data_to_UI(UnitFaction.Water, F_Water.Amount_Current, F_Water.Amount_Lv_1);
        }
    }

    private void Load_Water_data_to_UI(UnitFaction unitFaction, int currentAmount, int Lv_Amount)
    {
        if (WaterUI == null)
        {
            Create_WaterUI(unitFaction, currentAmount, Lv_Amount);
        }
        else
        {
            Update_WaterUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_WaterUI(UnitFaction unitFaction, int CurrentAmount, int Lv_Amount)
    {
        WaterUI = Instantiate(Default_SynergyUI, transform);
        WaterUI.transform.Find(key_BackgroundName).Find(nameSynergy).GetComponent<TextMeshProUGUI>().text = CardString.GetFactionString(unitFaction);
        WaterUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        WaterUI.SetActive(true);
    }

    private void Update_WaterUI(int CurrentAmount, int Lv_Amount)
    {
        if (CurrentAmount != 0)
        {
            WaterUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            WaterUI.SetActive(true);
        }
        else
        {
            WaterUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            WaterUI.SetActive(false);
        }

    }

    public void Hunter_UI()
    {
        if (C_Hunter.Amount_Current < C_Hunter.Amount_Lv_1)
        {
            Load_Hunter_data_to_UI(UnitClass.Hunter, C_Hunter.Amount_Current, C_Hunter.Amount_Lv_1);
        }
        else if (C_Hunter.Amount_Lv_1 <= C_Hunter.Amount_Current && C_Hunter.Amount_Current < C_Hunter.Amount_Lv_2)
        {
            Load_Hunter_data_to_UI(UnitClass.Hunter, C_Hunter.Amount_Current, C_Hunter.Amount_Lv_2);
        }
        else if (C_Hunter.Amount_Current == C_Hunter.Amount_Lv_2)
        {
            Load_Hunter_data_to_UI(UnitClass.Hunter, C_Hunter.Amount_Current, C_Hunter.Amount_Lv_2);
        }
    }

    private void Load_Hunter_data_to_UI(UnitClass unitClass, int currentAmount, int Lv_Amount)
    {
        if (HunterUI == null)
        {
            Create_HunterUI(unitClass, currentAmount, Lv_Amount);
        }
        else
        {
            Update_HunterUI(currentAmount, Lv_Amount);
        }
    }

    private void Create_HunterUI(UnitClass unitClass, int currentAmount, int Lv_Amount)
    {
        HunterUI = Instantiate(Default_SynergyUI, transform);
        HunterUI.transform.Find(key_BackgroundName).Find(nameSynergy).GetComponent<TextMeshProUGUI>().text = CardString.GetClassString(unitClass);
        HunterUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
        HunterUI.SetActive(true);
    }

    private void Update_HunterUI(int currentAmount, int Lv_Amount)
    {
        if (currentAmount != 0)
        {
            HunterUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            HunterUI.SetActive(true);
        }
        else
        {
            HunterUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            HunterUI.SetActive(false);
        }

    }


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
        CavalryUI = Instantiate(Default_SynergyUI, transform);
        CavalryUI.transform.Find(key_BackgroundName).Find(nameSynergy).GetComponent<TextMeshProUGUI>().text = CardString.GetClassString(unitClass);
        CavalryUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
        CavalryUI.SetActive(true);
    }

    private void Update_CavalryUI(int currentAmount, int Lv_Amount)
    {
        if (currentAmount != 0)
        {
            CavalryUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            CavalryUI.SetActive(true);
        }
        else
        {
            CavalryUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(currentAmount, Lv_Amount);
            CavalryUI.SetActive(false);
        }
    }


    public void Warrior_UI()
    {

        if (C_Warrior.Amount_Current < C_Warrior.Amount_Lv_1)
        {
            Load_Warrior_data_to_UI(UnitClass.Warrior, C_Warrior.Amount_Current, C_Warrior.Amount_Lv_1);
        }
        else if (C_Warrior.Amount_Lv_1 <= C_Warrior.Amount_Current && C_Warrior.Amount_Current < C_Warrior.Amount_Lv_2)
        {
            Load_Warrior_data_to_UI(UnitClass.Warrior, C_Warrior.Amount_Current, C_Warrior.Amount_Lv_2);
        }
        else if (C_Warrior.Amount_Lv_2 <= C_Warrior.Amount_Current && C_Warrior.Amount_Current < C_Warrior.Amount_Lv_3)
        {
            Load_Warrior_data_to_UI(UnitClass.Warrior, C_Warrior.Amount_Current, C_Warrior.Amount_Lv_3);
        }
        else if (C_Warrior.Amount_Current == C_Warrior.Amount_Lv_3)
        {
            Load_Warrior_data_to_UI(UnitClass.Warrior, C_Warrior.Amount_Current, C_Warrior.Amount_Lv_3);
        }
    }

    private void Load_Warrior_data_to_UI(UnitClass unitClass, int CurrentAmount, int Lv_Amount)
    {
        if (WarriorUI == null)
        {
            Create_WarriorUI(unitClass, CurrentAmount, Lv_Amount);
        }
        else
        {
            Update_WarriorUI(CurrentAmount, Lv_Amount);
        }
    }

    private void Create_WarriorUI(UnitClass unitClass, int CurrentAmount, int Lv_Amount)
    {
        WarriorUI = Instantiate(Default_SynergyUI, transform);
        WarriorUI.transform.Find(key_BackgroundName).Find(nameSynergy).GetComponent<TextMeshProUGUI>().text = CardString.GetClassString(unitClass);
        WarriorUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
        WarriorUI.SetActive(true);
    }

    private void Update_WarriorUI(int CurrentAmount, int Lv_Amount)
    {
        if (CurrentAmount != 0)
        {
            WarriorUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            WarriorUI.SetActive(true);
        }
        else
        {
            WarriorUI.transform.Find(key_BackgroundAmount).Find(amount).GetComponent<TextMeshProUGUI>().text = Synergy_SetAmount_By_Form(CurrentAmount, Lv_Amount);
            WarriorUI.SetActive(false);
        }

    }

    private string Synergy_SetAmount_By_Form(int currentAmount, int lvAmount)
    {
        return currentAmount + "/" + lvAmount;
    }
}
