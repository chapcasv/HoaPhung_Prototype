using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synergy : Manager<Synergy>
{
    #region Class 
 

    public void Set_Archer_by(List<BaseEntiny> listUnit_Archer)
    {
        C_Hunter.Set_Hunter_by(listUnit_Archer);
    }

    public void Set_Cavalry_by(List<BaseEntiny> listUnit_Cavalry)
    {
        C_Cavalry.Set_Cavalry_by(listUnit_Cavalry);
    }

    public void Set_Infantry_by(List<BaseEntiny> listUnit_Infantry)
    {
        C_Warrior.Set_Warrior_by(listUnit_Infantry);
    }



    #endregion

    #region Faction

    public void Set_Beast_by(List<BaseEntiny> listUnit)
    {
        F_Beast.Set_Beast_by(listUnit);
    }

    public void Set_Water_by(List<BaseEntiny> listUnit)
    {
        F_Water.Set_Water_by(listUnit);
    }
    public void Set_RockMountain_by(List<BaseEntiny> listUnit)
    {
        F_RockMountain.Set_RockMountain_by(listUnit);
    }

    public void Set_GodDragon_by(List<BaseEntiny> listUnit)
    {
        F_GodDragon.Set_GodDragon_by(listUnit);
    }

    #endregion
}
