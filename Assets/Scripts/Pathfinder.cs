using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    /// <summary>
    /// The start coordinates
    /// </summary>
    [SerializeField]
    private Vector2Int startCoordinates;

    /// <summary>
    /// The accessor for the start coordinates
    /// </summary>
    public Vector2Int StartCoordinates
    {
        get { return startCoordinates; }
    }

    /// <summary>
    /// The destination coordinates
    /// </summary>
    [SerializeField]
    private Vector2Int destinationCoordinates;

    /// <summary>
    /// The accessor for the destination coordinates
    /// </summary>
    public Vector2Int DestinationCoordinates
    {
        get { return destinationCoordinates; }
    }

    /// <summary>
    /// The start node
    /// </summary>
    private Node startNode;

    /// <summary>
    /// The destination node
    /// </summary>
    private Node destinationNode;

    /// <summary>
    /// The current search node
    /// </summary>
    private Node currentSearchNode;

    /// <summary>
    /// The queue of upcoming nodes to search
    /// </summary>
    private Queue<Node> frontier = new Queue<Node>();

    /// <summary>
    /// The dictionary of nodes that have already been reached
    /// </summary>
    private Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    /// <summary>
    /// The basic directions
    /// </summary>
    private Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };

    /// <summary>
    /// The grid manager
    /// </summary>
    private GridManager gridManager;

    /// <summary>
    /// The grid
    /// </summary>
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    /// <summary>
    /// Sets things up on awake
    /// </summary>
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
            startNode = grid[startCoordinates];
            destinationNode = grid[destinationCoordinates];
            startNode.isWalkable = true;
            destinationNode.isWalkable = true;
        }
    }

    /// <summary>
    /// Sets values at start and gets initial path
    /// </summary>
    private void Start()
    {
        startNode = grid[startCoordinates];
        destinationNode = grid[destinationCoordinates];

        GetNewPath();
    }

    /// <summary>
    /// Gets the path to take
    /// </summary>
    /// <returns>The path to take</returns>
    public List<Node> GetNewPath()
    {
        gridManager.ResetNodes();
        BreadthFirstSearch();
        return BuildPath();
    }

    /// <summary>
    /// Explores the new path
    /// </summary>
    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    /// <summary>
    /// Does a breadth first search for the path
    /// </summary>
    private void BreadthFirstSearch()
    {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;

        frontier.Clear();
        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }

    /// <summary>
    /// Builds the path once one has been found
    /// </summary>
    /// <returns>The path that can be taken</returns>
    private List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();

        return path;
    }

    /// <summary>
    /// Determines if a move will block a path being taken
    /// </summary>
    /// <param name="coordinates">The coordinates for the move</param>
    /// <returns>Whether it would block the path</returns>
    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = previousState;

            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }

            return false;
        }

        return false;
    }
}
