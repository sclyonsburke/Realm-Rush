using UnityEngine;

/// <summary>
/// The waypoint behavior
/// </summary>
public class Tile : MonoBehaviour
{
    /// <summary>
    /// The tower object
    /// </summary>
    [SerializeField]
    private Tower towerPrefab;

    /// <summary>
    /// Indicates if something can be placed here
    /// </summary>
    [SerializeField]
    private bool isPlaceable;

    /// <summary>
    /// Indicates if something can be placed here
    /// </summary>
    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }

    /// <summary>
    /// The grid manager
    /// </summary>
    private GridManager gridManager;

    /// <summary>
    /// The path finder
    /// </summary>
    private Pathfinder pathfinder;

    /// <summary>
    /// The coordinates
    /// </summary>
    private Vector2Int coordinates;

    /// <summary>
    /// Grabs gridmanager and pathfinder on Awake
    /// </summary>
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    /// <summary>
    /// Sets up the place in the grid
    /// </summary>
    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    /// <summary>
    /// Places a tower on click
    /// </summary>
    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
