using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class MultimeterController : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI omegaText;
    public TextMeshProUGUI ACText;
    public TextMeshProUGUI DCText;
    public TextMeshProUGUI amplerText;
    private float R = 1000, P = 400, I, U; 

    void Start()
    {
        I = Mathf.Sqrt(P / R);
        U = I * R; 
    }

    private void ShowValue(TextMeshProUGUI showenText)
    {
        List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();
        textList.Add(omegaText);
        textList.Add(ACText);
        textList.Add(DCText);
        textList.Add(amplerText);

        for (int i =0; i< textList.Count; i++)
        {
            if(textList[i] != showenText)
            {
                textList[i].text = "0";
            }
        }
    }

    private void ChangeText(float value, TextMeshProUGUI text)
    {
        if (value %1 == 0)
        {
            displayText.text = ((int)value).ToString();
            text.text = ((int)value).ToString();
        }
        else
        {
            displayText.text = (value).ToString("f2");
            text.text = value.ToString("f2");
        }
    }

    void Update()
    {
        if (transform.localEulerAngles.z >35 && transform.localEulerAngles.z <55)
        {
            ShowValue(ACText);
            ChangeText(U, ACText);
        }
        if (transform.localEulerAngles.z > 125 && transform.localEulerAngles.z < 145)
        {
            ShowValue(DCText);
            ChangeText(0.01f, DCText);
        }
        if (transform.localEulerAngles.z > 215 && transform.localEulerAngles.z < 235)
        {
            ShowValue(amplerText);
            ChangeText(I, amplerText);
        }
        if (transform.localEulerAngles.z > 305 && transform.localEulerAngles.z < 325)
        {
            ShowValue(omegaText);
            ChangeText(R, omegaText);
        }
        if(transform.localEulerAngles.z > 350 || transform.localEulerAngles.z < 10)
        {
            ShowValue(omegaText);
            ChangeText(0, omegaText);
        }
    }
}
