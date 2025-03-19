using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotList;

    [SerializeField] private List<NumberSlot> numberList;

    [SerializeField] private List<OperatorSlot> operationList;

    private void Start()
    {
        float answer = numberList[0].slotNumber;
        for (int i = 1; i < numberList.Count; i++)
        {
            OperationType operation = operationList[i - 1].operationType;
            switch (operation)
            {
                case OperationType.Add:
                    answer = answer + numberList[i].slotNumber;
                    break;
                case OperationType.Minus:
                    answer = answer - numberList[i].slotNumber;
                    break;
                case OperationType.Multiply:
                    answer = answer * numberList[i].slotNumber;
                    break;
                case OperationType.Divide:
                    answer = answer / numberList[i].slotNumber;
                    break;
                default:
                    break;
                    //throw new ArgumentException("Invalid operation type");
            }
        }
        Debug.Log(answer);
    }
}
