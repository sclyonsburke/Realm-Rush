using NUnit.Framework;
using UnityEngine;

public class EnemyTests
{
    /// <summary>
    /// Tests that null handling functions for reward gold
    /// </summary>
    [Test]
    public void Enemy_RewardGold_NullBankTest()
    {
        GameObject rootObj = new GameObject();
        Enemy enemy = rootObj.AddComponent<Enemy>();
        enemy.RewardGold();
    }

    /// <summary>
    /// Tests that null handling functions for steal gold
    /// </summary>
    [Test]
    public void Enemy_StealGold_NullBankTest()
    {
        GameObject rootObj = new GameObject();
        Enemy enemy = rootObj.AddComponent<Enemy>();
        enemy.StealGold();
    }
}
