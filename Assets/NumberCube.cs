using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberCube : MonoBehaviour
{
    public int number;
    [SerializeField] private TMP_Text numberText;
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private NumberSlot numberSlot;

    void Start()
    {
        mainCamera = Camera.main;
        numberText.text = number.ToString();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
        if (numberSlot != null)
        {
            transform.position = numberSlot.gameObject.transform.position;
            numberSlot.UpdateNumber(number);
        }
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    public void UpdateNumber(int numberToUpdate)
    {
        number = numberToUpdate;
        numberText.text = number.ToString();
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<NumberSlot>() != null)
        {
            numberSlot = collision.GetComponent<NumberSlot>();
            numberSlot.occupied = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<NumberSlot>() != null)
        {
            numberSlot.occupied = false;
            numberSlot = null;
        }
    }
}
