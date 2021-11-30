using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerLife 
{
    private static int currentLife;
    public static int CurrentLife { get => currentLife; }

    public static int GetStartLife()
    {
        currentLife = RaidManager.currentRaid.PlayerLife;
        return currentLife;
    }

    public static void Sub(int life)
    {
        currentLife -= life;
    }
}
