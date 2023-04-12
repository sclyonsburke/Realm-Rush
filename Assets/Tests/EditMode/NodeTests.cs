using NUnit.Framework;
using UnityEngine;

public class NodeTests
{
    /// <summary>
    /// Tests the Node constructor
    /// </summary>
    [Test]
    public void NodeConstructorTest()
    {
        var node = new Node(new Vector2Int(2,3), true);

        Assert.AreEqual(2, node.coordinates.x);
        Assert.AreEqual(3, node.coordinates.y);
        Assert.AreEqual(true, node.isWalkable);
    }
}
