using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberSlot : MonoBehaviour
{
    public bool occupied;
    public float slotNumber;

    public void UpdateNumber(int number)
    {
        slotNumber = number;
    }
}
