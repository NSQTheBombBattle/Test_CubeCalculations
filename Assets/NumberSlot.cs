using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberSlot : MonoBehaviour
{
    public bool occupied;
    [SerializeField] private TMP_Text numberText;
    public float slotNumber;

    public void InitText()
    {
        numberText.text = slotNumber.ToString();
    }

    public void UpdateNumber(int number)
    {
        slotNumber = number;
        InitText();
    }
}
