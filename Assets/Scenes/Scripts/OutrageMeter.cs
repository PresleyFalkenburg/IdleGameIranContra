using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutrageMeter : MonoBehaviour
{
    public float outrageMeter = 0; // Public variable for the outrage meter
    public TextMeshProUGUI outrageText; // Reference to the TextMeshPro text component
    public MoneyCounter moneyCounter; // Reference to the MoneyCounter script
    public CounterScript counterScript; // Reference to the CounterScript script
    public DiplomatCounter diplomatCounter; // Reference to the DiplomatCounter script
    public GameManager gameManager; // Reference to the GameManager script

    void Start()
    {
        UpdateOutrageText();
    }

    void Update()
    {
        if (outrageMeter >= 100)
        {
            ResetValues();
        }
        UpdateOutrageText();
    }

    public void UpdateOutrageText()
    {
        // Ensure outrageMeter does not go below 0
        if (outrageMeter < 0)
        {
            outrageMeter = 0;
        }

        if (outrageText != null)
        {
            outrageText.text = "Public Outrage: " + outrageMeter.ToString("F2") + "%";
        }
    }

    private void ResetValues()
    {
        outrageMeter = 0;
        if (moneyCounter != null)
        {
            moneyCounter.money = 0;
            moneyCounter.UpdateMoneyText();
        }
        if (counterScript != null)
        {
            counterScript.number = 0;
            counterScript.UpdateNumberText();
        }
        if (diplomatCounter != null)
        {
            diplomatCounter.diplomatCount = 0;
            diplomatCounter.UpdateDiplomatText();
        }
        if (gameManager != null)
        {
            gameManager.ResetRewards();
        }
    }

    public void DecreaseOutrage(float amount)
    {
        outrageMeter -= amount;
        if (outrageMeter < 0)
        {
            outrageMeter = 0;
        }
        UpdateOutrageText();
    }
}
