using UnityEngine;

/// <summary>
/// The waypoint behavior
/// </summary>
public class Waypoint : MonoBehaviour
{
    /// <summary>
    /// The tower object
    /// </summary>
    [SerializeField]
    private GameObject towerPrefab;

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
    /// Places a tower on click
    /// </summary>
    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
