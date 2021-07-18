using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Text Display_player_name;
    public Text Display_level;
    public Text Display_food;
    public Text Display_money;

    void Start()
    {
        Player_Database data = Save_System.LoadPlayer();
        Display_Player_data(data);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(ListScene.SelectScene.Login.ToString());
        }
    }


    public void Display_Player_data(Player_Database data)
    {
        Display_player_name.text = data.P_name;

        Display_level.text = data.level.ToString();
        Display_food.text = data.food.ToString();
        Display_money.text = data.money.ToString();
    }

    public void List_Hero()
    {
        SceneManager.LoadScene(ListScene.SelectScene.List_Hero.ToString());
    }

    public void Back_Main_menu()
    {
        SceneManager.LoadScene(ListScene.SelectScene.MainMenu.ToString());
    }


    public void Go_to_My_hero_list()
    {
        SceneManager.LoadScene(ListScene.SelectScene.My_hero_list.ToString());
    }

    public void Go_to_raid()
    {
        SceneManager.LoadScene(ListScene.SelectScene.Raid.ToString());
    }
}
