using UnityEngine;

[System.Serializable]
public class Node
{
    /// <summary>
    /// The Node Coordinates
    /// </summary>
    public Vector2Int coordinates;

    /// <summary>
    /// Whether or not the node is walkable
    /// </summary>
    public bool isWalkable;

    /// <summary>
    /// Whether or not the node is explored
    /// </summary>
    public bool isExplored;

    /// <summary>
    /// Whether or not the node is in the path
    /// </summary>
    public bool isPath;

    /// <summary>
    /// The node above this one in the tree
    /// </summary>
    public Node connectedTo;

    /// <summary>
    /// Constructs the node
    /// </summary>
    /// <param name="coordinates">The node coordinates</param>
    /// <param name="isWalkable">Whether the node is walkable</param>
    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}
