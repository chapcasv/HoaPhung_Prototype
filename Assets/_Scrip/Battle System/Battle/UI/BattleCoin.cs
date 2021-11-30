using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleCoin 
{
    private static int currentCoin;

    public static int CurrentCoin { get => currentCoin; }

    public static int GetStartCoin()
    {
        currentCoin = RaidManager.currentRaid.Coin;
        return CurrentCoin;
    }

    public static void Sub(int coin)
    {
        currentCoin -= coin;
    }

    public static void Add(int coin)
    {
        currentCoin += coin;
    }

    public static void CalculatorIncome()
    {

    }

   
}
