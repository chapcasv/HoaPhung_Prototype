using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class CloneBattleTest : MonoBehaviour
{
    [Test]
    public void CloneBattle_Test()
    {

        BattleSystem.instance.unitOfTeam = new Dictionary<Team, List<BaseEntiny>>();


        CloneBattleSystem.Clone_For(Team.Team1);
        Assert.AreEqual(BattleSystem.instance.unitOfTeam.Count,CloneBattleSystem.startNode.Count);
    }
}


