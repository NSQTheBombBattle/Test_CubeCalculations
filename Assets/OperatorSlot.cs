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
    [SerializeField] private TMP_Text operationText;
    public OperationType operationType;

    // Start is called before the first frame update
    void Start()
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
}
