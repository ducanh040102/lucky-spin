using System;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int error = 0;
    public int time = 0;

    public TextMeshProUGUI errorText;
    public TextMeshProUGUI timeText;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public Drop drop1;
    public Drop drop2;
    public Drop drop3;
    public Drop drop4;

    public LuckyWheel luckyWheel;

    private void Start()
    {
        UpdateErrorText();
    }

    private void Update()
    {
        float timeF = Time.time - Time.deltaTime;
        time = (int)timeF;
        timeText.text = "Time: " + time;
    }

    private void Awake()
    {
        button1.onClick.AddListener(() =>
        {
            UpdateError(drop1);
        });
        button2.onClick.AddListener(() =>
        {
            UpdateError(drop2);
        });
        button3.onClick.AddListener(() =>
        {
            UpdateError(drop3);
        });
        button4.onClick.AddListener(() =>
        {
            UpdateError(drop4);
        });
    }

    public void UpdateError(Drop drop) 
    {
        if (luckyWheel.GetSelectedColor() != drop.GetPlacedColor())
        {
            error++;
            UpdateErrorText();
        }
    }

    public void UpdateErrorText()
    {
        errorText.text = "Error: " + error;
    }

    public void ElasedTime()
    {

    }
}
