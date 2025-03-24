using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum OperationType
{
    Add,
    Minus,
    Multiply,
    Divide,
    None
}

public class OperatorSlot : MonoBehaviour
{
    public bool occupied;
    public OperationType operationType;

    public void GetRandomOperation()
    {
        OperationType[] values = (OperationType[])System.Enum.GetValues(typeof(OperationType));
        int randomIndex = Random.Range(0, values.Length);
        operationType = values[randomIndex];
    }

    public void UpdateOperation(OperationType type)
    {
        operationType = type;
    }
}

