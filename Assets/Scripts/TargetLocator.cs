using UnityEngine;

/// <summary>
/// Finds the target
/// </summary>
public class TargetLocator : MonoBehaviour
{
    /// <summary>
    /// The weapon being pointed
    /// </summary>
    [SerializeField]
    private Transform weapon;

    /// <summary>
    /// The weapon particle system
    /// </summary>
    [SerializeField]
    private ParticleSystem projectileParticles;

    /// <summary>
    /// The weapon range
    /// </summary>
    [SerializeField]
    private float range = 15f;

    /// <summary>
    /// The target for the weapon
    /// </summary>
    [SerializeField]
    private Transform target;

    /// <summary>
    /// Updates the weapon target every frame
    /// </summary>
    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    /// <summary>
    /// Finds the closest enemy target
    /// </summary>
    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    /// <summary>
    /// Sets the weapon to point at the target
    /// </summary>
    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        this.Attack(targetDistance < range);
        weapon.LookAt(target);
    }

    /// <summary>
    /// Controls if the weapon will be firing
    /// </summary>
    /// <param name="isActive">Whether or not the weapon should fire</param>
    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
