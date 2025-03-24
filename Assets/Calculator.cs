using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private List<GameObject> slotList;
    private List<float> numberList = new List<float>();
    private List<OperationType> operationList = new List<OperationType>();

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
                    return;
                }
                numberList.Add(slotList[i].GetComponent<NumberSlot>().slotNumber);
            }
            else if (slotList[i].GetComponent<OperatorSlot>() != null)
            {
                if (!slotList[i].GetComponent<OperatorSlot>().occupied)
                    continue;
                if (isNumber)
                {
                    Debug.Log("Double operator detected!");
                    return;
                }
                operationList.Add(slotList[i].GetComponent<OperatorSlot>().operationType);
            }
            isNumber = !isNumber;
        }
        if (isNumber)
        {
            Debug.Log("Invalid Operation! Equation cannot ends with an operator");
            return;
        }
        Calculate();
    }

    private void RandomSlots()
    {
        //for (int i = 0; i < numberList.Count; i++)
        //{
        //    numberList[i] = Random.Range(1, 10);
        //}
        //for (int i = 0; i < operationList.Count; i++)
        //{
        //    operationList[i].GetRandomOperation();
        //    if(operationList[i].operationType == OperationType.Divide)
        //    {
        //        numberList[i].slotNumber = numberList[i].slotNumber * numberList[i + 1].slotNumber;
        //    }
        //}
    }

    private void RandomSlots2()
    {

    }

    private void Calculate()
    {
        for (int i = 0; i < operationList.Count; i++)
        {
            if (operationList[i] == OperationType.Divide)
            {
                numberList[i] = numberList[i] / numberList[i + 1];
                numberList.RemoveAt(i + 1);
                operationList.RemoveAt(i);
                i--;
            }
        }

        for (int i = 0; i < operationList.Count; i++)
        {
            if (operationList[i] == OperationType.Multiply)
            {
                numberList[i] = numberList[i] * numberList[i + 1];
                numberList.RemoveAt(i + 1);
                operationList.RemoveAt(i);
                i--;
            }
        }

        for (int i = 0; i < operationList.Count; i++)
        {
            if (operationList[i] == OperationType.Minus)
            {
                numberList[i + 1] = -numberList[i + 1];
            }
        }

        float answer = 0;
        for (int i = 0; i < numberList.Count; i++)
        {
            answer += numberList[i];
        }
        Debug.Log(answer);
    }
}
