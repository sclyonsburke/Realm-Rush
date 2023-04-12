using NUnit.Framework;
using UnityEngine;

public class GridManagerTests
{
    /// <summary>
    /// Tests GetCoordinatesFromPosition
    /// </summary>
    [Test]
    public void GetCoordinatesFromPositionTest()
    {
        GameObject rootObj = new GameObject();
        GridManager gridManager = rootObj.AddComponent<GridManager>();
        Vector3 position = new Vector3(20, 0, 30);
        var result = gridManager.GetCoordinatesFromPosition(position);
        Assert.AreEqual(2, result.x);
        Assert.AreEqual(3, result.y);
    }

    /// <summary>
    /// Tests GetPositionFromCoordinates
    /// </summary>
    [Test]
    public void GetPostionFromCoordinatesTest()
    {
        GameObject rootObj = new GameObject();
        GridManager gridManager = rootObj.AddComponent<GridManager>();
        Vector2Int coordinates = new Vector2Int(2, 3);
        var result = gridManager.GetPositionFromCoordinates(coordinates);
        Assert.AreEqual(20, result.x);
        Assert.AreEqual(30, result.z);
    }
}
