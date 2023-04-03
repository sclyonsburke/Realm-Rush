using NUnit.Framework;
using UnityEngine;

public class BankTests
{
    /// <summary>
    /// Tests Deposit behavior
    /// </summary>
    [Test]
    public void Bank_DepositTest()
    {
        GameObject rootObj = new GameObject();
        Bank bank = rootObj.AddComponent<Bank>();
        bank.Deposit(500);
        Assert.AreEqual(500, bank.CurrentBalance);
    }

    /// <summary>
    /// Tests Withdrawal behavior
    /// </summary>
    [Test]
    public void Bank_WithdrawalTest()
    {
        GameObject rootObj = new GameObject();
        Bank bank = rootObj.AddComponent<Bank>();
        bank.Deposit(500);
        bank.Withdraw(50);
        Assert.AreEqual(450, bank.CurrentBalance);
    }
}
