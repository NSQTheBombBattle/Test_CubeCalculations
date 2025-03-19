using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text numberText;
    public float slotNumber;

    private void Start()
    {
        numberText.text = slotNumber.ToString();
    }
}
