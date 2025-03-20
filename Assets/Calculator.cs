using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotList;
    private List<NumberSlot> numberList = new List<NumberSlot>();
    private List<OperatorSlot> operationList = new List<OperatorSlot>();

    private void Start()
    {
        InitSlots();
        RandomSlots();
        Calculate();
    }

    private void InitSlots()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].GetComponent<NumberSlot>() != null)
            {
                numberList.Add(slotList[i].GetComponent<NumberSlot>());
                slotList[i].GetComponent<NumberSlot>().InitText();
            }
            else if (slotList[i].GetComponent<OperatorSlot>() != null)
            {
                operationList.Add(slotList[i].GetComponent<OperatorSlot>());
                slotList[i].GetComponent<OperatorSlot>().InitText();
            }
        }
    }

    private void RandomSlots()
    {
        for (int i = 0; i < numberList.Count; i++)
        {
            numberList[i].slotNumber = Random.Range(0, 10);
            numberList[i].InitText();
        }
        for (int i = 0; i < operationList.Count; i++)
        {
            operationList[i].GetRandomOperation();
            operationList[i].InitText();
        }
    }

    private void Calculate()
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
