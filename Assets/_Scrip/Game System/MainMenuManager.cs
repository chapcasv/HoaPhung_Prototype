using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject selectedMode_popUp;
    [SerializeField] TextMeshProUGUI display_playerName;
    [SerializeField] TextMeshProUGUI display_level;
    [SerializeField] TextMeshProUGUI display_runeCoin;
    [SerializeField] TextMeshProUGUI display_money;
    //exp

    void Start()
    {
        Player_Database data = Save_System.LoadPlayer();
        Display_Player_data(data);
        DecksData.LoadPlayerDeckToGame();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SelectScene.Login.ToString());
        }
    }


    public void Display_Player_data(Player_Database data)
    {
        display_playerName.text = data.P_name;
        //display_level.text = data.level.ToString();
        //display_runeCoin.text = data.runeCoin.ToString();
        //display_money.text = data.money.ToString();
    }


    public void Back_Main_menu()
    {
        SceneManager.LoadScene(SelectScene.MainMenu.ToString());
    }


    public void GoTo_collection()
    {
        SceneManager.LoadScene(SelectScene.Collection.ToString());
    }

    public void SelectedModePlay()
    {
        selectedMode_popUp.SetActive(true);
    }

    public void Go_to_raid()
    {
        SceneManager.LoadScene(SelectScene.Raid.ToString());
    }
}
