using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The enemy movement behavior
/// </summary>
public class EnemyMover : MonoBehaviour
{
    /// <summary>
    /// The list of waypoints in the path
    /// </summary>
    [SerializeField]
    private List<Waypoint> path = new List<Waypoint>();

    /// <summary>
    /// The enemy speed
    /// </summary>
    [SerializeField]
    [Range(0f, 5f)]
    private float speed = 1f;

    /// <summary>
    /// Basic setup for the enemy path and moving along it
    /// </summary>
    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    /// <summary>
    /// Finds all path tiles and adds it to path list
    /// </summary>
    private void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    /// <summary>
    /// Sets the enemy to the starting location
    /// </summary>
    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    /// <summary>
    /// Moves the enemy along the path and destroys it when it reaches the destination
    /// </summary>
    private IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < speed)
            {
                travelPercent += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        gameObject.SetActive(false);
    }
}
