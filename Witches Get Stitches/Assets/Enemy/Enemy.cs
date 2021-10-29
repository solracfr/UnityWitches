using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25; // split into two to give devs a bit more control

    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // Video Lecture tells us to expand method to return a bool
    // so that there is a method to confirm whether a deposit 
    // was made
    public void RewardGold()
    {
        if(bank == null) { return; } // safeguard... 
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if(bank == null) { return; }
        bank.Withdraw(goldPenalty);
    }
}
