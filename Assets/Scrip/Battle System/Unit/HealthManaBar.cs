using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManaBar : MonoBehaviour
{
    public Slider sliderHP;
    public Slider sliderSP;
    [SerializeField] Sprite ColorHPTeam1;
    [SerializeField] Sprite ColorHPTeam2;
    [SerializeField] Text UnitLv;

    public GameObject SP_bar;
    public GameObject Stack_bar;
    public GameObject HP_bar;

    public GameObject stack1;
    public GameObject stack2;
    public GameObject stack3;
    public GameObject stack4;

    public void SetMaxHP(int maxHP)
    {
        sliderHP.maxValue = maxHP;
        sliderHP.value = maxHP;
        SetHP(maxHP);
    }

    public void SetHP(int HP)
    {
        sliderHP.value = HP;
    }

    public void SetStack(int stack)
    {
        switch (stack)
        {
            case 0:
                stack1.SetActive(false);
                stack2.SetActive(false);
                stack3.SetActive(false);
                stack4.SetActive(false);
                break;
            case 1:
                stack1.SetActive(true);
                stack2.SetActive(false);
                stack3.SetActive(false);
                stack4.SetActive(false);
                break;
            case 2:
                stack2.SetActive(true);
                break;
            case 3:
                stack3.SetActive(true);
                break;
            case 4:
                stack4.SetActive(true);
                break;
        }
    }
   

    public void SetMaxSP(int maxSP, int currentSP = 0)
    {
        sliderSP.maxValue = maxSP;
        sliderSP.value = currentSP;
    }
    public void SetSP(int SP)
    {
        sliderSP.value = SP;
    }

    public void SetUP(int maxHP, int maxSP, int SP_current, Team team, int level, bool HaveSP_bar = true, bool HaveStack_bar = false)
    {
        Set_ColorHPbar_by(team);

        Set_UI_UnitLevel_by(level);

        SetMaxHP(maxHP);
        SetMaxSP(maxSP, SP_current);
        SetStack(0);
        if (HaveSP_bar && !HaveStack_bar)
        {
            SP_bar.SetActive(true);
            Stack_bar.SetActive(false);
        }
        else if(!HaveSP_bar && HaveStack_bar)
        {
            SP_bar.SetActive(false);
            Stack_bar.SetActive(true);
        }
        else if(HaveSP_bar && HaveStack_bar)
        {
            Debug.Log("have stack and sp");
            SP_bar.SetActive(true);
            Stack_bar.SetActive(true);
            HP_bar.transform.position = new Vector3(HP_bar.transform.position.x, HP_bar.transform.position.y + 0.1f);
            SP_bar.transform.position = new Vector3(SP_bar.transform.position.x, SP_bar.transform.position.y + 0.07f);
            Stack_bar.transform.position = new Vector3(Stack_bar.transform.position.x, Stack_bar.transform.position.y - 0.01f);
        }
        else
        {
            SP_bar.SetActive(false);
            Stack_bar.SetActive(false);
        }
        


    }

    private void Set_UI_UnitLevel_by(int level)
    {
        UnitLv.text = level.ToString();
    }

    private void Set_ColorHPbar_by(Team team)
    {
        if (team == Team.Team1)
        {
            transform.Find("HPbar").Find("Fill").GetComponent<Image>().sprite = ColorHPTeam1;
        }
        else
        {
            transform.Find("HPbar").Find("Fill").GetComponent<Image>().sprite = ColorHPTeam2;
        }
    }
}
