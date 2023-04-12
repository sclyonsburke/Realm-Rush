using UnityEngine;
using TMPro;

/// <summary>
/// Labels the coordinates
/// </summary>
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    /// <summary>
    /// The default color for the coordinates
    /// </summary>
    [SerializeField]
    private Color defaultColor = Color.white;

    /// <summary>
    /// The coordinate color for blocked tiles
    /// </summary>
    [SerializeField]
    private Color blockedColor = Color.gray;

    /// <summary>
    /// The default color for the coordinates
    /// </summary>
    [SerializeField]
    private Color exploredColor = Color.yellow;

    /// <summary>
    /// The coordinate color for blocked tiles
    /// </summary>
    private Color pathColor = new Color(1f, 0.5f, 0f);

    /// <summary>
    /// The label for the coordinates
    /// </summary>
    private TextMeshPro label;

    /// <summary>
    /// The coordinates for the tile
    /// </summary>
    private Vector2Int coordinates = new Vector2Int();

    /// <summary>
    /// The Grid Manager
    /// </summary>
    private GridManager gridManager;

    /// <summary>
    /// Sets up the label and waypoint for the tile
    /// </summary>
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        label.enabled = false;
    }

    /// <summary>
    /// Updates the labels
    /// </summary>
    private void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    /// <summary>
    /// Toggles the label display
    /// </summary>
    private void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    /// <summary>
    /// Sets the coordinate colors based on if objects can be placed on the tile
    /// </summary>
    private void SetLabelColor()
    {
        if(gridManager == null)
        {
            return;
        }

        Node node = gridManager.GetNode(coordinates);

        if(node == null)
        {
            return;
        }

        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }

    }

    /// <summary>
    /// Displays the coordinates for the tile
    /// </summary>
    private void DisplayCoordinates()
    {
        if(gridManager == null)
        {
            return;
        }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    /// <summary>
    /// Updates the object name with the coordinates
    /// </summary>
    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
