using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : BaseEntiny
{
    Player_Database data;

    private int HP_base;
    private float Atk_speed_base;
    private int HP_buff_1 ;
    private int HP_buff_2 ;
    private int Str_buff_1;
    private int Str_buff_2;
    private float Atk_speed_buff_1;
    private float Atk_speed_buff_2;

    private List<BaseEntiny> myteamMate;
    public void GetTalent(CardUnitID id, BaseEntiny unit_want_get_talent)
    {
        switch (id)
        {
            case CardUnitID.SungX:

                break;
            case CardUnitID.SungY:
                break;
            case CardUnitID.SungZ:
                break;
            case CardUnitID.Wolf:
                break;
            case CardUnitID.MaCay:
                break;
            case CardUnitID.Golem:
                break;
            default:
                break;
        }
    }

    
    
    
}
