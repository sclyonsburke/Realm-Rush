using UnityEngine;

/// <summary>
/// Keeps track of enemy health
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    /// <summary>
    /// The maximum hit points for the enemy
    /// </summary>
    [SerializeField]
    private int maxHitPoints = 5;

    /// <summary>
    /// Adds amount to maxHitPoints when enemy dies
    /// </summary>
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField]
    private int difficultyRamp = 1;

    /// <summary>
    /// The current hit points for the enemy
    /// </summary>
    private int currentHitPoints = 0;

    /// <summary>
    /// The enemy
    /// </summary>
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    /// <summary>
    /// Sets current health to max
    /// </summary>
    private void OnEnable()
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
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
