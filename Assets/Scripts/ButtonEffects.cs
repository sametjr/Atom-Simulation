using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    Color32 prevColor;
    public void ChangeColor(Image btnImage)
    {
        prevColor = btnImage.color;
        btnImage.color = Color.red;
    }

    public void ReturnPreviousColor(Image btnImage)
    {
        btnImage.color = prevColor;
    }

}
