using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int wallValue;
    public Sprite wallImage;

    public void InitWall(int value, Sprite image)
    {
        wallValue = value;
        wallImage = image;

        GetComponent<SpriteRenderer>().sprite = image;
    }
}
