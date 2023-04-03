using UnityEngine;

/// <summary>
/// The Tower script
/// </summary>
public class Tower : MonoBehaviour
{
    /// <summary>
    /// The tower cost
    /// </summary>
    [SerializeField]
    private int cost = 75;

    /// <summary>
    /// Creates a tower if the money is available
    /// </summary>
    /// <param name="tower">The tower</param>
    /// <param name="position">The tower position</param>
    /// <returns></returns>
    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
