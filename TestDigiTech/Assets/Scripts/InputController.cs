using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;
    [HideInInspector] public bool isSelected = false;
    [HideInInspector] public float mouseWheel;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (isSelected)
        {
            mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        }  
    }
}
