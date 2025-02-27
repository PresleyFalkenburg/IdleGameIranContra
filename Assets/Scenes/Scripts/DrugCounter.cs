using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrugCounter : MonoBehaviour
{
    public DiplomatCounter diplomatCounter; // Reference to the DiplomatCounter script
    public TextMeshProUGUI cocaineText; // Reference to the TextMeshPro text component for cocaine count
    public int tonsOfCocaine = 0; // Variable to store the tons of cocaine

    // Start is called before the first frame update
    void Start()
    {
        UpdateCocaineText();
    }

    // Update is called once per frame
    void Update()
    {
        //IncrementCocaine();
        UpdateCocaineText();
    }

    // private void IncrementCocaine()
    // {
    //     if (diplomatCounter != null)
    //     {
    //         tonsOfCocaine = diplomatCounter.fundContrasCallCount * 5;
    //     }
    // }

    private void UpdateCocaineText()
    {
        if (cocaineText != null)
        {
            cocaineText.text = "Tons of Cocaine: " + tonsOfCocaine.ToString();
        }
    }
}
