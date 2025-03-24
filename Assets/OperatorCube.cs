using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OperatorCube : MonoBehaviour
{
    public OperationType operationType;
    [SerializeField] private TMP_Text operationText;
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private OperatorSlot operationSlot;

    void Start()
    {
        mainCamera = Camera.main;
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
            case OperationType.None:
                operationText.text = "?";
                break;
            default:
                operationText.text = "?";
                break;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (operationSlot != null)
        {
            transform.position = operationSlot.gameObject.transform.position;
            operationSlot.UpdateOperation(operationType);
        }
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    public void UpdateOperation(OperationType typeToUpdate)
    {
        operationType = typeToUpdate;
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
            case OperationType.None:
                operationText.text = "?";
                break;
            default:
                operationText.text = "?";
                break;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<OperatorSlot>() != null)
        {
            operationSlot = collision.GetComponent<OperatorSlot>();
            operationSlot.occupied = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<OperatorSlot>() != null)
        {
            operationSlot.occupied = false;
            operationSlot = null;
        }
    }
}
