using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerHealthTest {

	[UnityTest]
	public IEnumerator PlayerHealthTest_Minus() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject _PlayerGO = new GameObject();
        Player _Player = _PlayerGO.AddComponent<Player>();

        _Player.MaxHealth = 6;
        _Player.Health = 6;

        _Player.DoHealthCalc(-2);

        Assert.AreEqual(4, _Player.Health);

        yield return null;
	}

    [UnityTest]
    public IEnumerator PlayerHealthTest_Add()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject _PlayerGO = new GameObject();
        Player _Player = _PlayerGO.AddComponent<Player>();

        _Player.MaxHealth = 6;
        _Player.Health = 2;

        _Player.DoHealthCalc(+3);

        Assert.AreEqual(5, _Player.Health);

        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerHealthTest_Max()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject _PlayerGO = new GameObject();
        Player _Player = _PlayerGO.AddComponent<Player>();

        _Player.MaxHealth = 6;
        _Player.Health = 4;

        _Player.DoHealthCalc(3);

        Assert.AreEqual(6, _Player.Health);

        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerHealthTest_Min()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject _PlayerGO = new GameObject();
        Player _Player = _PlayerGO.AddComponent<Player>();

        _Player.MaxHealth = 6;
        _Player.Health = 6;

        _Player.DoHealthCalc(-21);

        Assert.AreEqual(0, _Player.Health);

        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerArmorTest_Add()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject _PlayerGO = new GameObject();
        Player _Player = _PlayerGO.AddComponent<Player>();

        _Player.Armor = 4;

        _Player.DoArmorCalc(+3);

        Assert.AreEqual(7, _Player.Armor);

        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerArmorTest_Minus()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject _PlayerGO = new GameObject();
        Player _Player = _PlayerGO.AddComponent<Player>();

        _Player.Armor = 4;

        _Player.DoArmorCalc(-6);

        Assert.AreEqual(0, _Player.Armor);

        yield return null;
    }

}
