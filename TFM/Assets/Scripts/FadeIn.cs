using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float time = 5f;
    private float fadeAmount;

    Color objectColor;

    void Start()
    {
        objectColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = new Color (objectColor.r, objectColor.g, objectColor.b, 1f);
    }

    void Update()
    {
        fadeAmount = GetComponent<Image>().color.a - (Time.deltaTime);
        objectColor = new Color (objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        gameObject.GetComponent<Image>().color = objectColor;
    }
}
