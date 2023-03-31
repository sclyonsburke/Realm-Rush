using UnityEngine;

/// <summary>
/// Keeps track of enemy health
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    /// <summary>
    /// The maximum hit points for the enemy
    /// </summary>
    [SerializeField]
    private int maxHitPoints = 5;

    /// <summary>
    /// The current hit points for the enemy
    /// </summary>
    [SerializeField]
    private int currentHitPoints = 0;

    /// <summary>
    /// Sets current health to max
    /// </summary>
    private void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    /// <summary>
    /// The behavior when the enemy is hit
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    /// <summary>
    /// Subtracts hit points on hit, and destroys object if it reaches 0 hit points
    /// </summary>
    private void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
