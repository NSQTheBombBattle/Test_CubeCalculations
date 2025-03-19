using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotList;

    [SerializeField] private List<NumberSlot> numberList;

    [SerializeField] private List<OperatorSlot> operationList;

    private void Start()
    {
        TestingCalculation();
        //float answer = numberList[0].slotNumber;
        //for (int i = 1; i < numberList.Count; i++)
        //{
        //    OperationType operation = operationList[i - 1].operationType;
        //    switch (operation)
        //    {
        //        case OperationType.Add:
        //            answer = answer + numberList[i].slotNumber;
        //            break;
        //        case OperationType.Minus:
        //            answer = answer - numberList[i].slotNumber;
        //            break;
        //        case OperationType.Multiply:
        //            answer = answer * numberList[i].slotNumber;
        //            break;
        //        case OperationType.Divide:
        //            answer = answer / numberList[i].slotNumber;
        //            break;
        //        default:
        //            break;
        //            //throw new ArgumentException("Invalid operation type");
        //    }
        //}
        //Debug.Log(answer);
    }

    private void TestingCalculation()
    {
        for (int i = 0; i < operationList.Count; i++)
        {
            if (operationList[i].operationType == OperationType.Divide)
            {
                numberList[i].slotNumber = numberList[i].slotNumber / numberList[i + 1].slotNumber;
                numberList.RemoveAt(i + 1);
                operationList.RemoveAt(i);
                i--;
            }
        }
        for (int i = 0; i < operationList.Count; i++)
        {
            if (operationList[i].operationType == OperationType.Multiply)
            {
                numberList[i].slotNumber = numberList[i].slotNumber * numberList[i + 1].slotNumber;
                numberList.RemoveAt(i + 1);
                operationList.RemoveAt(i);
                i--;
            }
        }
        for (int i = 0; i < operationList.Count; i++)
        {
            if (operationList[i].operationType == OperationType.Minus)
            {
                numberList[i + 1].slotNumber = -numberList[i + 1].slotNumber;
            }
        }
        float answer = 0;
        for (int i = 0; i < numberList.Count; i++)
        {
            answer += numberList[i].slotNumber;
        }
        Debug.Log(answer);
    }
}
