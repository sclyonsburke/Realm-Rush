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
    Transform weapon;

    /// <summary>
    /// The target for the weapon
    /// </summary>
    [SerializeField]
    Transform target;

    /// <summary>
    /// Sets the target
    /// </summary>
    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    /// <summary>
    /// Updates the weapon target every frame
    /// </summary>
    void Update()
    {
        AimWeapon();
    }

    /// <summary>
    /// Sets the weapon to point at the target
    /// </summary>
    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
