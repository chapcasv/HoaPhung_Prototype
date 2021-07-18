using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Exp 
{
    public static int MaxExp_Lv1 = 100;
    public static int MaxExp_Lv2 = 200;
    public static int MaxExp_Lv3 = 400;
    public static int MaxExp_Lv4 = 800;
    public static int MaxExp_Lv5 = 1600;
    public static int MaxExp_Lv6 = 3500;
    public static int MaxExp_Lv7 = 8000;
    public static int MaxExp_Lv8 = 18000;
    public static int MaxExp_Lv9 = 40000;
    public static int MaxLV = 0;

    public static int MaxExp(int level)
    {
        switch (level)
        {
            case 1:
                return MaxExp_Lv1;
            case 2:
                return MaxExp_Lv2;
            case 3:
                return MaxExp_Lv3;
            case 4:
                return MaxExp_Lv4;
            case 5:
                return MaxExp_Lv5;
            case 6:
                return MaxExp_Lv6;
            case 7:
                return MaxExp_Lv7;
            case 8:
                return MaxExp_Lv8;
            case 9:
                return MaxExp_Lv9;
            default:
                return MaxLV;
        }
    }
}
