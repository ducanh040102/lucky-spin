using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LuckyWheel : MonoBehaviour
{
    public enum WheelColor
    {
        Red, Green, Yellow, Purple
    }

    public float rotationSpeed = 100f;
    public float spinTime;
    public WheelColor selectedColor = WheelColor.Red;

    public int selectedSegment = 0;
    private int currentSegment = 0;

    private bool isSpinning = false;

    private void Start()
    {
        UpdateSelectedSegment();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && !isSpinning)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            UpdateSelectedSegment();
            StartCoroutine(SpinWheel());
        }

        if (isSpinning)
        {
            UpdateCurrentSegment();
        }

        if (isSpinning)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator SpinWheel()
    {
        isSpinning = true;

        float timer = 0f;

        while (timer < spinTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        while (currentSegment != selectedSegment)
        {
            yield return null;
        }

        isSpinning = false;
    }

    void UpdateSelectedSegment()
    {
        if (selectedColor == WheelColor.Red)
        {
            selectedSegment = 0;
        }
        if (selectedColor == WheelColor.Purple)
        {
            selectedSegment = 1;
        }
        if (selectedColor == WheelColor.Yellow)
        {
            selectedSegment = 2;
        }
        if (selectedColor == WheelColor.Green)
        {
            selectedSegment = 3;
        }
    }

    void UpdateCurrentSegment()
    {
        float currentRotation = transform.eulerAngles.z;

        currentRotation = (currentRotation + 360) % 360;
        float segmentSize = 360f / 4;
        currentSegment = Mathf.FloorToInt(currentRotation / segmentSize);
    }

    public string GetSelectedColor()
    {
        return selectedColor.ToString();
    }
}
