using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synergy : Manager<Synergy>
{
    #region Class 
 

    public void Set_Archer_by(List<BaseEntiny> listUnit_Archer)
    {
        C_Archer.Set_Archer_by(listUnit_Archer);
    }

    public void Set_Cavalry_by(List<BaseEntiny> listUnit_Cavalry)
    {
        C_Cavalry.Set_Cavalry_by(listUnit_Cavalry);
    }

    public void Set_Infantry_by(List<BaseEntiny> listUnit_Infantry)
    {
        C_Infantry.Set_Infantry_by(listUnit_Infantry);
    }



    #endregion

    #region Faction

    public void Set_ChamPa_by(List<BaseEntiny> listUnit_ChamPa)
    {
        F_ChamPa.Set_ChamPa_by(listUnit_ChamPa);
    }

    public void Set_Vietnam_by(List<BaseEntiny> listUnit_Vietnam)
    {
        F_VietNam.Set_Vietnam_by(listUnit_Vietnam);
    }
    public void Set_MongNguyen_by(List<BaseEntiny> listUnit_MongNguyen)
    {
        F_MongNguyen.Set_MongNguyen_by(listUnit_MongNguyen);
    }

    #endregion
}
