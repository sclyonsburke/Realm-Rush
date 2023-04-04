using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    /// <summary>
    /// The starting balance
    /// </summary>
    [SerializeField]
    private int startingBalance = 150;

    /// <summary>
    /// The current balance
    /// </summary>
    private int currentBalance;

    /// <summary>
    /// The Display UI for the bank balance
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI displayBalance;

    /// <summary>
    /// Accessor for the current balance
    /// </summary>
    public int CurrentBalance
    {
        get { return currentBalance; }
    }

    /// <summary>
    /// Sets the starting value for the current balance
    /// </summary>
    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    /// <summary>
    /// Adds money to the account
    /// </summary>
    /// <param name="amount">The amount to be deposited</param>
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    /// <summary>
    /// Withdraws money from the accound
    /// </summary>
    /// <param name="amount">The amount to be withdrawn</param>
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalance < 0)
        {
            ReloadScene();
        }
    }

    /// <summary>
    /// Reloads the scene
    /// </summary>
    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    /// <summary>
    /// Updates the Display
    /// </summary>
    private void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
}
