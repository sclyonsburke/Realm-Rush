using UnityEngine;

[ExecuteInEditMode]
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// The reward for defeating the enemy
    /// </summary>
    [SerializeField]
    private int goldReward = 25;

    /// <summary>
    /// The penalty for the enemy making it to the end
    /// </summary>
    [SerializeField]
    private int goldPenalty = 25;

    /// <summary>
    /// The bank
    /// </summary>
    private Bank bank;

    /// <summary>
    /// Gets the bank object at start
    /// </summary>
    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    /// <summary>
    /// Rewards gold when the enemy is defeated
    /// </summary>
    public void RewardGold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Deposit(goldReward);
    }

    /// <summary>
    /// Steals gold when the enemy reaches the end
    /// </summary>
    public void StealGold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Withdraw(goldPenalty);
    }
}
