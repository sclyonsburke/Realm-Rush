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
}
