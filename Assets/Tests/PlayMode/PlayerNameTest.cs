using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerNameTest
{
    
    //Need more test when Multiplayer

    [Test]
    public void PlayerNameTestNull()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result =  gameObject.GetComponent<LoginManager>().CanUse(null);
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_MaxRangeCharacter()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result = gameObject.GetComponent<LoginManager>().CanUse("15characterrrrr");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_MinRangeCharacter()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result = gameObject.GetComponent<LoginManager>().CanUse("2c");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_Space()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result = gameObject.GetComponent<LoginManager>().CanUse("tran dao");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_Space2()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result = gameObject.GetComponent<LoginManager>().CanUse("tran  dao");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_SpecialCharacter()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result = gameObject.GetComponent<LoginManager>().CanUse("@@@");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_SpecialCharacter2()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result = gameObject.GetComponent<LoginManager>().CanUse("///");
        Assert.AreEqual(result, false);
    }

    [Test]
    public void PlayerNameTest_SpecialCharacter3()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<LoginManager>();
        var result = gameObject.GetComponent<LoginManager>().CanUse("\\");
        Assert.AreEqual(result, false);
    }



}
