using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotList;
    private List<NumberSlot> numberList = new List<NumberSlot>();
    private List<OperatorSlot> operationList = new List<OperatorSlot>();

    private void Start()
    {
        //InitSlots();
        //RandomSlots();
        //Calculate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitSlots();
        }
    }

    private void InitSlots()
    {
        numberList.Clear();
        operationList.Clear();
        bool isNumber = true;
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].GetComponent<NumberSlot>() != null)
            {
                if (!slotList[i].GetComponent<NumberSlot>().occupied)
                    continue;
                if (!isNumber)
                {
                    Debug.Log("Double number detected!");
                    break;
                }
                numberList.Add(slotList[i].GetComponent<NumberSlot>());
            }
            else if (slotList[i].GetComponent<OperatorSlot>() != null)
            {
                if (!slotList[i].GetComponent<OperatorSlot>().occupied)
                    continue;
                if (isNumber)
                {
                    Debug.Log("Double number detected!");
                    break;
                }
                operationList.Add(slotList[i].GetComponent<OperatorSlot>());
            }
            isNumber = !isNumber;
        }
        if (operationList.Count != numberList.Count - 1)
        {
            Debug.Log("Invalid Operation! The number of the operator must be 1 lesser than the number!");
            Debug.Log($"Operator count: {operationList.Count}, number count: {numberList.Count}");
        }
        Calculate();
    }

    private void RandomSlots()
    {
        for (int i = 0; i < numberList.Count; i++)
        {
            numberList[i].slotNumber = Random.Range(1, 10);
        }
        for (int i = 0; i < operationList.Count; i++)
        {
            operationList[i].GetRandomOperation();
            if(operationList[i].operationType == OperationType.Divide)
            {
                numberList[i].slotNumber = numberList[i].slotNumber * numberList[i + 1].slotNumber;
            }
        }
    }

    private void RandomSlots2()
    {

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
