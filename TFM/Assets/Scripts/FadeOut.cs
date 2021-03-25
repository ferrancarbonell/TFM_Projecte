using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float time = 5f;
    private float fadeAmount;

    Color objectColor;

    void Start()
    {
        objectColor = gameObject.GetComponent<Image>().color;
    }

    void Update()
    {
        fadeAmount = GetComponent<Image>().color.a + (Time.deltaTime/3);
        objectColor = new Color (objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        gameObject.GetComponent<Image>().color = objectColor;
    }
}
