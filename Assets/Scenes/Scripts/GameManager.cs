using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CounterScript counterScript;
    public MoneyCounter moneyCounter;
    public DiplomatCounter diplomatCounter;
    private bool rewardGiven = false;
    private bool bigRewardGiven = false;

    void Start()
    {
        // Start the coroutine to increment the counter once per second
        StartCoroutine(IncrementCounter());
    }

    void Update()
    {
        if (counterScript != null && moneyCounter != null)
        {
            if (counterScript.number >= 100 && !rewardGiven)
            {
                moneyCounter.money += 75000;
                moneyCounter.UpdateMoneyText();
                rewardGiven = true;
                Debug.Log("Reward given: 75000 money");
            }

            if (counterScript.number >= 1000 && !bigRewardGiven)
            {
                moneyCounter.money += 1000000;
                moneyCounter.UpdateMoneyText();
                bigRewardGiven = true;
                Debug.Log("Big reward given: 1000000 money");
            }
        }
    }

    private IEnumerator IncrementCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second

            if (counterScript != null && diplomatCounter != null)
            {
                counterScript.IncrementNumber(diplomatCounter.diplomatCount); // Add diplomat count to the counter number
                counterScript.UpdateNumberText(); // Update the TextMeshPro text components
            }
        }
    }

    public void ResetRewards()
    {
        rewardGiven = false;
        bigRewardGiven = false;
    }
}