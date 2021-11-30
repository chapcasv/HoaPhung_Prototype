using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerNameTest : InitializeNewPlayer
{
    
    //Need more test when Multiplayer

    [Test]
    public void PlayerNameTestNull()
    {   
        var result =  CanUse(null);
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_MaxRangeCharacter()
    {
        var result = CanUse("15characterrrrr");
        Assert.AreEqual(result, false);

    }

    [Test]
    public void PlayerNameTest_MinRangeCharacter()
    {
        var result = CanUse("2C");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_Space()
    {
        var result = CanUse("tran dao");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_Space2()
    {
        var result = CanUse("tran  dao");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_SpecialCharacter()
    {
        var result = CanUse("@@@");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_SpecialCharacter2()
    {
        var result = CanUse("///");
        Assert.AreEqual(result, false); ;
    }

    [Test]
    public void PlayerNameTest_SpecialCharacter3()
    {
        var result = CanUse("\\");
        Assert.AreEqual(result, false);
    }



}
