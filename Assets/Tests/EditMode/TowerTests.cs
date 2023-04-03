using NUnit.Framework;
using UnityEngine;

public class TowerTests
{
    /// <summary>
    /// Tests behavior when bank is null
    /// </summary>
    [Test]
    public void CreateTower_NullBank()
    {
        GameObject rootObj = new GameObject();
        Tower tower = rootObj.AddComponent<Tower>();
        var result = tower.CreateTower(tower, new Vector3());
        Assert.IsFalse(result);
    }

    /// <summary>
    /// Tests behavior when there is enough gold in the bank
    /// </summary>
    [Test]
    public void CreateTower_EnoughGoldTest()
    {
        GameObject rootObj = new GameObject();
        Bank bank = rootObj.AddComponent<Bank>();
        Tower tower = rootObj.AddComponent<Tower>();
        bank.Deposit(500);
        var result = tower.CreateTower(tower, new Vector3());
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Tests behavior when there is not enough gold in the bank
    /// </summary>
    [Test]
    public void CreateTower_NotEnoughGoldTest()
    {
        GameObject rootObj = new GameObject();
        Bank bank = rootObj.AddComponent<Bank>();
        Tower tower = rootObj.AddComponent<Tower>();
        var result = tower.CreateTower(tower, new Vector3());
        Assert.IsFalse(result);
    }
}
