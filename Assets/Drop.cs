using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public enum PlacedColor
    {
        None,
        Red,
        Green,
        Yellow,
        Purple,
    }

    public PlacedColor placedColor = PlacedColor.None;

    public void SetPlacedColor(string color)
    {
        if(color == "Red")
        {
            placedColor = PlacedColor.Red;
        }
        
        if(color == "Green")
        {
            placedColor = PlacedColor.Green;
        }
        if(color == "Yellow")
        {
            placedColor = PlacedColor.Yellow;
        }
        if(color == "Purple")
        {
            placedColor = PlacedColor.Purple;
        }
        if(color == "None")
        {
            placedColor = PlacedColor.None;
        }
    }

    public string GetPlacedColor()
    {
        return placedColor.ToString();
    }
}
