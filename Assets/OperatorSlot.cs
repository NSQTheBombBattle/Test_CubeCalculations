using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum OperationType
{
    Add,
    Minus,
    Multiply,
    Divide
}

public class OperatorSlot : MonoBehaviour
{
    public bool isEmpty;
    [SerializeField] private TMP_Text operationText;
    public OperationType operationType;

    // Start is called before the first frame update
    public void InitText()
    {
        switch (operationType)
        {
            case OperationType.Add:
                operationText.text = "+";
                break;
            case OperationType.Minus:
                operationText.text = "-";
                break;
            case OperationType.Multiply:
                operationText.text = "X";
                break;
            case OperationType.Divide:
                operationText.text = "/";
                break;
            default:
                operationText.text = "?";
                break;
        }
    }

    public void GetRandomOperation()
    {
        OperationType[] values = (OperationType[])System.Enum.GetValues(typeof(OperationType));
        int randomIndex = Random.Range(0, values.Length);
        operationType = values[randomIndex];
    }

    public void UpdateOperation(OperationType type)
    {
        operationType = type;
        InitText();
    }
}

