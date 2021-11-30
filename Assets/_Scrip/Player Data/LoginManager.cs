﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class LoginManager : MonoBehaviour
{
    
    [SerializeField] GameObject newPlayer_popUp;
    [SerializeField] TextMeshProUGUI input_PlayerName;
    [SerializeField] TextMeshProUGUI ruler_PlayerName;

    private string playerName;
    private bool newPlayer_popUp_IsActive = false;

    public void StarGame()
    {
        if (Save_System.isHavePlayerData()) GoTo_mainMenu();
        else active_newPlayerName_popUp(); ;
    }

    public void ResetPlayer()
    {
        Save_System.ResetPlayerData();
    }

    public void Create_newPlayer()
    {
        playerName = input_PlayerName.GetComponent<TextMeshProUGUI>().text; ;

        if (InitializeNewPlayer.Try_Initialize(playerName))
        {
            GoTo_mainMenu();
        }
        else  NotifyCantUsePlayerName();
    }


    private void NotifyCantUsePlayerName()
    {
        ruler_PlayerName.GetComponent<TextMeshProUGUI>().text = SystemString.rulePlayerName_Error;
    }

    private void active_newPlayerName_popUp()
    {
        newPlayer_popUp_IsActive = !newPlayer_popUp_IsActive;
        newPlayer_popUp.SetActive(newPlayer_popUp_IsActive);
    }

    public void unActive_newPlayerName_popUp()
    {
        newPlayer_popUp_IsActive = false;
        newPlayer_popUp.SetActive(newPlayer_popUp_IsActive);
    }

    public void GoTo_mainMenu()
    {
        SceneManager.LoadScene(SelectScene.MainMenu.ToString());
    }

    public void Quit_game()
    {
        Application.Quit();
    }


}
