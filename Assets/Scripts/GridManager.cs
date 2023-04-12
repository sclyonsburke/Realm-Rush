using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    /// <summary>
    /// The Grid Size
    /// </summary>
    [SerializeField]
    private Vector2Int gridSize;

    /// <summary>
    /// The size of a grid space by the unity editor snap settings
    /// </summary>
    [Tooltip("World Grid Size - Should match UnityEditor snap settings")]
    [SerializeField]
    private int unityGridSize = 10;

    /// <summary>
    /// The accessor for the unity grid size
    /// </summary>
    public int UnityGridSize
    {
        get { return unityGridSize; }
    }

    /// <summary>
    /// The grid
    /// </summary>
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    /// <summary>
    /// The accessor for the grid
    /// </summary>
    public Dictionary<Vector2Int, Node> Grid
    {
        get { return grid; }
    }

    /// <summary>
    /// Creates the grid on Awake
    /// </summary>
    private void Awake()
    {
        CreateGrid();
    }

    /// <summary>
    /// Gets a node at a specific set of coordinates
    /// </summary>
    /// <param name="coordinates">The node coordinates</param>
    /// <returns>The node at that location</returns>
    public Node GetNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }

    /// <summary>
    /// Blocks a node
    /// </summary>
    /// <param name="coordinates">The coordinates of the node to block</param>
    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    /// <summary>
    /// Resets the nodes in the grid
    /// </summary>
    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }

    /// <summary>
    /// Converts a vector 3 position to coordinates in the grid
    /// </summary>
    /// <param name="position">The position to convert</param>
    /// <returns>The coordinates</returns>
    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        return coordinates;
    }

    /// <summary>
    /// Converts a set of coordinates in the grid to a vector 3 position
    /// </summary>
    /// <param name="coordinates">The coordinates to convert</param>
    /// <returns>The position</returns>
    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;
        return position;
    }

    /// <summary>
    /// Creates the grid
    /// </summary>
    private void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}
