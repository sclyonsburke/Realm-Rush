using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The enemy movement behavior
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    /// <summary>
    /// The list of waypoints in the path
    /// </summary>
    [SerializeField]
    private List<Node> path = new List<Node>();

    /// <summary>
    /// The enemy speed
    /// </summary>
    [SerializeField]
    [Range(0f, 5f)]
    private float speed = 1f;

    /// <summary>
    /// The enemy
    /// </summary>
    private Enemy enemy;

    /// <summary>
    /// The Grid Manager
    /// </summary>
    private GridManager gridManager;

    /// <summary>
    /// The Path Finder
    /// </summary>
    private Pathfinder pathfinder;

    /// <summary>
    /// Gets the enemy component
    /// </summary>
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

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
        path = pathfinder.GetNewPath();
    }

    /// <summary>
    /// Sets the enemy to the starting location
    /// </summary>
    private void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    /// <summary>
    /// What to do when reaching the end of the path
    /// </summary>
    private void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Moves the enemy along the path and destroys it when it reaches the destination
    /// </summary>
    private IEnumerator FollowPath()
    {
        for(int i = 0; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
      