using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    public TextMeshProUGUI notificationText; // Reference to the TextMeshPro text component
    public MoneyCounter moneyCounter; // Reference to the MoneyCounter script
    public DiplomatCounter diplomatCounter; // Reference to the DiplomatCounter script
    public CounterScript counterScript; // Reference to the CounterScript script
    public OutrageMeter outrageMeter; // Reference to the OutrageMeter script

    void Start()
    {
        UpdateNotification();
    }

    void Update()
    {
        UpdateNotification();
    }

    private void UpdateNotification()
    {
        if (counterScript.number >= 1000)
        {
            notificationText.text = "Congrats Congress has funded your intelligence operations but you now have audits.";
        }
        else if (moneyCounter.money > 0)
        {
            notificationText.text = "Recruit Diplomats to influence governments for you.";
        }
        else if (diplomatCounter.diplomatCount > 0)
        {
            notificationText.text = "Expand Intelligence operation to start making money.";
        }
        else if (outrageMeter.outrageMeter >= 100)
        {
            notificationText.text = "Public outrage is too high, resulting in impeachment! Resetting values.";
        }
        else if (diplomatCounter.fundContrasCallCount > 0)
        {
            notificationText.text = "Funded Nicaraguan Contras " + diplomatCounter.fundContrasCallCount + " times.";
        }
        else if (diplomatCounter.tonsOfCocaine > 0)
        {
            notificationText.text = "You have " + diplomatCounter.tonsOfCocaine + " tons of cocaine.";
        }
        else if (outrageMeter.outrageMeter > 50)
        {
            notificationText.text = "Public outrage is rising. Consider conducting PSYOP.";
        }
        else if (diplomatCounter.sellWeaponsCallCount >= 1)
        {
            notificationText.text = "Arms sales to Iran are increasing. Be cautious of public outrage.";
        }
        else if (diplomatCounter.diplomatCount >= 50)
        {
            notificationText.text = "You have a strong network of diplomats. Use them wisely.";
        }
        else if (moneyCounter.money >= 1000000)
        {
            notificationText.text = "You have been granted emergency 'hostage' rescue funds.";
        }
        else if (outrageMeter.outrageMeter > 75)
        {
            notificationText.text = "Public outrage is very high. Immediate action is required.";
        }
        else if (counterScript.number > 0)
        {
            notificationText.text = "You have " + counterScript.number + " spies in operation.";
        }
        else
        {
            notificationText.text = "Recruit contacts in Iran and Israel to gain government contracts from the Intelligence Agency.";
        }
    }
}
