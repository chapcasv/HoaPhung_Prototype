using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Display_My_list_hero : MonoBehaviour
{

    public static Display_My_list_hero instance;

    public UnitOfPlayer hero_chosen;
    public GameObject stat_and_equip_obj;

    public Slot_Equip slot1_UI;
    public Slot_Equip slot2_UI;
    public Slot_Equip slot3_UI;
    public Slot_Equip slot4_UI;

    public List<Slot_Equip> slot_equipment;


    #region Display Stat Base
    public Text hp;
    public Text sp_max;
    public Text sp_regen;
    public Text Int;
    public Text Str;
    public Text Atk_speed;
    public Text Range;
    public Text Crit;

    public Text talent;
    public Text skill;
    public Text level;
    public Text exp_current;
    public Text exp_max;

    public GameObject cost;
    public Image avatar;
    public Sprite Label_1cost;
    public Sprite Label_2cost;
    public Sprite Label_3cost;
    Player_Database data;
    #endregion

    public static string ID_Hero_chosen = null;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        slot_equipment = new List<Slot_Equip>() { slot1_UI, slot2_UI, slot3_UI, slot4_UI };
        Display_my_list_hero();
    }

    public static string GetID_hero_chosen()
    {
        return ID_Hero_chosen;
    }

    bool Player_have_hero()
    {
        data = Save_System.LoadPlayer();
        if(data.hero_list.Count <= 0)
        {
            stat_and_equip_obj.SetActive(false);
            return false;
        }
        else
        {
            stat_and_equip_obj.SetActive(true);
            return true;
        }

    }

    void Display_my_list_hero()
    {
        GameObject button_temp = transform.GetChild(0).gameObject;
        GameObject g;
        data = Save_System.LoadPlayer();
        if(Player_have_hero())
        {
            foreach (UnitOfPlayer hero in data.hero_list)
            {
                g = Instantiate(button_temp, transform);
                g.transform.GetChild(0).GetComponent<Text>().text = hero.Hero_name;
                g.GetComponent<Image>().sprite = sprite_ByCost(hero.Cost);
                g.GetComponent<Button>().onClick.AddListener(delegate ()
                {
                   
                    Show_stat(hero);
                });
            }
            UnitOfPlayer default_hero = data.hero_list[0];
            Show_stat(default_hero);
            Destroy(button_temp);
        }
        else
        {
            button_temp.SetActive(false);
        }
        
    }

    Sprite sprite_ByCost(int cost)
    {
        switch (cost)
        {
            case 1:
                return Label_1cost;
            case 2:
                return Label_2cost;
            case 3:
                return Label_3cost;
            default:
                return Label_1cost;

        }
    }

    public void Show_stat(UnitOfPlayer hero)
    {
        data = Save_System.LoadPlayer();


        ID_Hero_chosen = hero.HeroID;

        hero_chosen =  Load_Item_Equipment(data,ID_Hero_chosen);


        hp.text = hero_chosen.HP.ToString();
        sp_max.text = hero_chosen.SP_max.ToString();
        sp_regen.text = hero_chosen.SP_regen.ToString();
        Int.text = hero_chosen.Int.ToString();
        Str.text = hero_chosen.Str.ToString();
        Atk_speed.text = hero_chosen.Atk_Speed.ToString();
        talent.text = hero_chosen.talent_description.ToString();
        skill.text = hero_chosen.skill_description.ToString();
        Range.text = hero_chosen.Range.ToString();
        Crit.text = hero_chosen.Crit.ToString();
        level.text = hero_chosen.level.ToString();
        exp_current.text = hero_chosen.exp_current.ToString();
        exp_max.text = hero_chosen.exp_max.ToString();



        Show_Cost_Icon(hero_chosen.Cost);
        var temp = DataGraph.Get_Graph_ByID(hero_chosen.HeroID);
        avatar.sprite = temp.UnitAvatar;

        
    }

    public void Load_Stat_Item_toHero(Item_Database item_data, UnitOfPlayer hero_equipment)
    {

        switch (item_data.stat_opt1)
        {
            case StatType.Str:
                StrBonus((int)item_data.value_stat_opt1, hero_equipment);
                break;
            case StatType.HP:
                HPBonus((int)item_data.value_stat_opt1, hero_equipment);
                break;
            case StatType.Int:
                IntBonus((int)item_data.value_stat_opt1, hero_equipment);
                break;
        }
        switch (item_data.stat_opt2)
        {
            case StatType.Str:
                StrBonus((int)item_data.value_stat_opt2, hero_equipment);
                break;
            case StatType.HP:
                HPBonus((int)item_data.value_stat_opt2, hero_equipment);
                break;
            case StatType.Int:
                IntBonus((int)item_data.value_stat_opt2, hero_equipment);
                break;
            case StatType.Atk_speed:
                Atk_Speed_Bonus(item_data.value_stat_opt2, hero_equipment);
                break;
            case StatType.Sp_regen:
                Sp_regen_bonus((int)item_data.value_stat_opt2, hero_equipment);
                break;
        }
    }

    private void StrBonus(int val, UnitOfPlayer hero_equipment)
    {
        hero_equipment.Str += val;
    }

    private void HPBonus(int val, UnitOfPlayer hero_equipment)
    {
        hero_equipment.HP += val;
    }

    private void IntBonus(int val, UnitOfPlayer hero_equipment)
    {
        hero_equipment.Int += val;
    }

    private void Atk_Speed_Bonus(float val, UnitOfPlayer hero_equipment)
    {
        hero_equipment.Atk_Speed += val;
    }

    private void Sp_regen_bonus(int val, UnitOfPlayer hero_equipment)
    {
        hero_equipment.SP_regen += val;
    }


    public UnitOfPlayer Load_Item_Equipment(Player_Database data, string ID)
    {
        hero_chosen = Save_System.GetHero_Database_From_ID(data, ID);

        List<Item_Database> hero_equipments = new List<Item_Database>() {
            hero_chosen.slot1,
            hero_chosen.slot2,
            hero_chosen.slot3,
            hero_chosen.slot4
        };

        for (int i = 0; i < hero_equipments.Count; i++)
        {
            Item slot = DataGraph.Get_Item_ByID(hero_equipments[i].ID);
            slot_equipment[i].icon.sprite = slot.icon;
            slot_equipment[i].item_data = hero_equipments[i];
            Load_Stat_Item_toHero(hero_equipments[i], hero_chosen);
        }

        return hero_chosen;
    }

    public void Save_Item_Equipment(Player_Database data)
    {
        

        if (data.hero_list.Count <= 0) return;

        foreach(UnitOfPlayer hero in data.hero_list)
        {
            if(hero.HeroID == ID_Hero_chosen)
            {   
                hero.slot1 = slot1_UI.item_data;
                hero.slot2 = slot2_UI.item_data;
                hero.slot3 = slot3_UI.item_data;
                hero.slot4 = slot4_UI.item_data;
                Save_System.SaveData(data);
            }
        }
        Save_Inventory();
    }
    void Save_Inventory()
    {
        InventoryUI.instance.Save_Inventory_to_PlayerData();
    }

    void Show_Cost_Icon(int hero_cost)
    {
        switch (hero_cost)
        {
            case 1:
                cost.transform.GetChild(1).gameObject.SetActive(true);
                cost.transform.GetChild(2).gameObject.SetActive(false);
                cost.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 2:
                cost.transform.GetChild(1).gameObject.SetActive(false);
                cost.transform.GetChild(2).gameObject.SetActive(true);
                cost.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 3:
                cost.transform.GetChild(1).gameObject.SetActive(false);
                cost.transform.GetChild(2).gameObject.SetActive(false);
                cost.transform.GetChild(3).gameObject.SetActive(true);
                break;

        }
    }

    public void Close_my_hero_list()
    {
        
        SceneManager.LoadScene(ListScene.SelectScene.MainMenu.ToString());
    }


}
