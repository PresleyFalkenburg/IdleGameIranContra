using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterScript : MonoBehaviour
{
    public int number = 0;
    public TextMeshProUGUI numberText; // Reference to the TextMeshPro text component

    void Start()
    {
        UpdateNumberText();
    }

    public void IncrementNumber(int amount)
    {
        number += amount;
        Debug.Log("Number incremented to: " + number);
        UpdateNumberText();
    }

    public void UpdateNumberText()
    {
        if (numberText != null)
        {
            numberText.text = "Network of Contacts: " + number.ToString();
        }
    }
}