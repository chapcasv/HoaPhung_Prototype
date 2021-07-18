using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class LoginManager : MonoBehaviour
{
    
    public GameObject InputNewPlayerUI;
    public Text inputPlayerName;

    [SerializeField] Text ruler_PlayerName;
    private string player_name;
    private bool InputNewPlayerUI_IsActive = false;

    public void Create_new_player()
    {

        player_name = inputPlayerName.GetComponent<Text>().text; ;
        if (CanUse(player_name))
        {
            Player p = gameObject.AddComponent<Player>();
            Set_data_new_player(p, player_name);
            Save_System.SavePlayer(p);

            GoTo_mainMenu();
        }
        else
        {
            NotifyCantUsePlayerName();
        }
        
    }

    public bool CanUse(string player_name)
    {
        if(player_name != null)
        {
            if(player_name.Length <=14 && player_name.Length >= 3 
                && !haveSpace(player_name)
                && dontHaveSpecialCharacter(player_name))
            {   
                return true;
            }
            else
            {
                return false;
            }
        }
        else return false;
    }

    private void NotifyCantUsePlayerName()
    {
        ruler_PlayerName.GetComponent<Text>().text = UnitString.rulePlayerName_Error;
    }

    private bool dontHaveSpecialCharacter(string player_name)
    {
        var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

        if (regexItem.IsMatch(player_name))
        {
            return true;
        }
        else return false;
    }

    private bool haveSpace(string player_name)
    {
        if (player_name.Contains(" "))
        {
            return true;
        }
        else return false;
    }

    private void Set_data_new_player(Player p, string player_name)
    {
        p.P_name = player_name;
        
        p.level = 1;
        p.money = 9000;
        p.hero_database = new List<UnitOfPlayer>();
        p.item_database = new List<Item_Database>();
        p.team_database = new List<Team_database>();
        p.team_database.Add(new Team_database() { team_name = "Trận hình 1" });
        p.team_database.Add(new Team_database() { team_name = "Trận hình 2" });
        p.team_database.Add(new Team_database() { team_name = "Trận hình 3" });
        p.Max_member = 3;
        p.Max_cost = 5;
        p.Team_Selected = 1;
    }

    public void Show_UI_Input_playerName()
    {
        InputNewPlayerUI_IsActive = !InputNewPlayerUI_IsActive;
        InputNewPlayerUI.SetActive(InputNewPlayerUI_IsActive);
    }

    public void Hiden_UI_Input_playerName()
    {
        InputNewPlayerUI_IsActive = false;
        InputNewPlayerUI.SetActive(InputNewPlayerUI_IsActive);
    }

    public void GoTo_mainMenu()
    {
        SceneManager.LoadScene(ListScene.SelectScene.MainMenu.ToString());
    }

    public void Quit_game()
    {
        Application.Quit();
    }


}
