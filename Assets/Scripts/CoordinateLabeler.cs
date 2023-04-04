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
    /// The label for the coordinates
    /// </summary>
    private TextMeshPro label;

    /// <summary>
    /// The coordinates for the tile
    /// </summary>
    private Vector2Int coordinates = new Vector2Int();

    /// <summary>
    /// The tile waypoint
    /// </summary>
    private Waypoint waypoint;

    /// <summary>
    /// Sets up the label and waypoint for the tile
    /// </summary>
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
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
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    /// <summary>
    /// Displays the coordinates for the tile
    /// </summary>
    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

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
