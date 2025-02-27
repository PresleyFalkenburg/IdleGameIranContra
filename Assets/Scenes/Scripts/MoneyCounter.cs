using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public int initialMoney = 0; // Initial money count
    public int money = 0;
    public TextMeshProUGUI moneyText; // Reference to the TextMeshPro text component

    void Start()
    {
        money = initialMoney; // Set the initial money count
        UpdateMoneyText();
    }

   public void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: $" + money.ToString();
        }
    }
}
