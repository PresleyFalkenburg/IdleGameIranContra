using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiplomatCounter : MonoBehaviour
{
    public int initialCost = 27000; // cost of a diplomat
    public float costMultiplier = 1.05f; 
    public float costMultiplierContas = 2;
    public int diplomatCount = 0; 
    public int currentCost; // Current cost of a diplomat
    public TextMeshProUGUI diplomatCountText; // Reference to the TextMeshPro text component for diplomat count
    public TextMeshProUGUI currentCostText; // Reference to the TextMeshPro text component for current cost
    public CounterScript counterScript; // Reference to the CounterScript
    public MoneyCounter moneyCounter; // Reference to the MoneyCounter
    public OutrageMeter outrageMeter; // Reference to the OutrageMeter

    public DrugCounter drugCounter; // Reference to the DrugCounter
    public TextMeshProUGUI cocaineText; // Reference to the TextMeshPro text component for cocaine count

    private float outrageMultiplier = 1.05f; // Multiplier for outrage meter
    private int fundContrasCost = 75000; // Initial cost for funding Nicaraguan Contras
    private int psyopSubtractionAmount = 1000; // Initial subtraction amount for ConductPSYOP
    private int sellDrugsAmount = 100000; // Initial amount for selling drugs

    public int fundContrasCallCount = 0; // Count how many times FundNicaraguanContras was called
    public int tonsOfCocaine = 0; // Variable to store the tons of cocaine
    public int sellWeaponsCallCount = 0; // Count how many times SellWeapons was called

    void Start()
    {
        currentCost = initialCost; // Set the initial cost
        UpdateDiplomatText();
        UpdateCocaineText();
    }

    void Update()
    {
        // Update logic if needed
    }

    public void PurchaseDiplomat()
    {
        // Subtract the current cost from the money (assuming you have a MoneyCounter script)
        MoneyCounter moneyCounter = FindObjectOfType<MoneyCounter>();
        if (moneyCounter != null && moneyCounter.money >= currentCost)
        {
            moneyCounter.money -= currentCost;
            moneyCounter.UpdateMoneyText();

            // Increment the diplomat count
            diplomatCount++;

            // Increment the cost by the multiplier
            currentCost = Mathf.RoundToInt(currentCost * costMultiplier);

            // Update the TextMeshPro text components
            UpdateDiplomatText();

            Debug.Log("Diplomat purchased. New count: " + diplomatCount + ", New cost: " + currentCost);
        }
        else
        {
            Debug.Log("Not enough money to purchase a diplomat.");
        }
    }

    public void SellWeapons()
    {
        OutrageMeter outrageMeter = FindObjectOfType<OutrageMeter>();
        MoneyCounter moneyCounter = FindObjectOfType<MoneyCounter>();
        CounterScript counterScript = FindObjectOfType<CounterScript>();
        if (counterScript.number > 1000)
        {
            moneyCounter.money += 50000;
            moneyCounter.UpdateMoneyText();

            outrageMeter.outrageMeter += 1;
            outrageMeter.outrageMeter = Mathf.RoundToInt(outrageMeter.outrageMeter * outrageMultiplier);
            outrageMeter.UpdateOutrageText();
             sellWeaponsCallCount++;


            Debug.Log("Weapon sold: Money increased by 50000, Outrage increased with multiplier.");
        }
        else
        {
            Debug.Log("Count is not above 1000. Cannot sell weapons.");
        }
    }

    public void FundNicaraguanContras()
    {
        OutrageMeter outrageMeter = FindObjectOfType<OutrageMeter>();
        MoneyCounter moneyCounter = FindObjectOfType<MoneyCounter>();
        CounterScript counterScript = FindObjectOfType<CounterScript>();
        if (moneyCounter.money >= fundContrasCost)
        {
            moneyCounter.money -= fundContrasCost;
            moneyCounter.UpdateMoneyText();

            // Double the current count of diplomats
            diplomatCount *= 2;

            // Increase outrage by 10 and apply the multiplier
            outrageMeter.outrageMeter += 10;
            outrageMeter.outrageMeter = Mathf.RoundToInt(outrageMeter.outrageMeter * outrageMultiplier);
            outrageMeter.UpdateOutrageText();

            // Increment the cost by the multiplier
            fundContrasCost = Mathf.RoundToInt(fundContrasCost * costMultiplierContas);

            // Increment the call count
            fundContrasCallCount++;

            // Update the TextMeshPro text components
            UpdateDiplomatText();

            // Update the cocaine count
            UpdateCocaineCount();

            Debug.Log("Funded Nicaraguan Contras: Diplomat count doubled, outrage increased, new cost: " + fundContrasCost);
        }
        else
        {
            Debug.Log("Not enough money to fund Nicaraguan Contras.");
        }
    }

    public void ConductPSYOP()
    {
        OutrageMeter outrageMeter = FindObjectOfType<OutrageMeter>();
        MoneyCounter moneyCounter = FindObjectOfType<MoneyCounter>();
        CounterScript counterScript = FindObjectOfType<CounterScript>();
        DrugCounter drugCounter = FindObjectOfType<DrugCounter>();
        if (counterScript.number >= psyopSubtractionAmount)
        {
            // Decrease the outrage meter by 30 percent
            outrageMeter.outrageMeter *= 0.7f;
            outrageMeter.UpdateOutrageText();

            // Subtract the count from CounterScript by the current subtraction amount
            counterScript.number -= psyopSubtractionAmount;
            counterScript.UpdateNumberText();

            // Increment the subtraction amount by 1000 for the next call
            psyopSubtractionAmount += 1000;

            Debug.Log("Conducted PSYOP: Outrage decreased by 30%, count decreased by " + psyopSubtractionAmount);
        }
        else
        {
            Debug.Log("Not enough count to conduct PSYOP.");
        }
    }

    public void SellDrugsToAmericans()
    {
        OutrageMeter outrageMeter = FindObjectOfType<OutrageMeter>();
        MoneyCounter moneyCounter = FindObjectOfType<MoneyCounter>();
        CounterScript counterScript = FindObjectOfType<CounterScript>();
        DrugCounter drugCounter = FindObjectOfType<DrugCounter>();
        if (tonsOfCocaine > 0)
        {
            moneyCounter.money += sellDrugsAmount;
            moneyCounter.UpdateMoneyText();

            // Decrease the total of cocaine by one
            tonsOfCocaine -= 1;
            UpdateCocaineText();

            // Increment the sell drugs amount by the cost multiplier
            sellDrugsAmount = Mathf.RoundToInt(sellDrugsAmount * costMultiplier);

            Debug.Log("Drugs sold to Americans: Money increased by " + sellDrugsAmount + ", Cocaine decreased by 1.");
        }
        else
        {
            Debug.Log("Not enough cocaine to sell.");
        }
    }

    public void RedactInformation()
    {
        OutrageMeter outrageMeter = FindObjectOfType<OutrageMeter>();
        MoneyCounter moneyCounter = FindObjectOfType<MoneyCounter>();
        CounterScript counterScript = FindObjectOfType<CounterScript>();
        DrugCounter drugCounter = FindObjectOfType<DrugCounter>();
        if (counterScript.number >= 2000)
        {
            // Decrease the outrage meter by 20
            outrageMeter.outrageMeter -= 20;
            outrageMeter.UpdateOutrageText();

            // Subtract the count from CounterScript by 2000
            counterScript.number -= 2000;
            counterScript.UpdateNumberText();

            Debug.Log("Information redacted: Outrage decreased by 20, count decreased by 2000.");
        }
        else
        {
            Debug.Log("Not enough count to redact information.");
        }
    }

    private void UpdateCocaineCount()
    {
        tonsOfCocaine = fundContrasCallCount * 5;
        UpdateCocaineText();
    }

    private void UpdateCocaineText()
    {
        if (cocaineText != null)
        {
            cocaineText.text = "Tons of Cocaine: " + tonsOfCocaine.ToString();
        }
    }

    public void UpdateDiplomatText()
    {
        if (diplomatCountText != null)
        {
            diplomatCountText.text = "Diplomats: " + diplomatCount.ToString();
        }

        if (currentCostText != null)
        {
            currentCostText.text = "Cost: $" + currentCost.ToString();
        }
    }
}
