using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RegulatorController : MonoBehaviour
{
    public GameObject regulator; 
    public Material selectedMaterial;
    private Material _normalMaterial;
    private MeshRenderer _renderRegulator;

    private float _speedRotation = 7f;

    void Start()
    {
        _renderRegulator = regulator.GetComponent<MeshRenderer>();
        _normalMaterial = _renderRegulator.material;
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Regulator")
            {
                _renderRegulator.material = selectedMaterial;
                InputController.instance.isSelected = true;
                Debug.Log(InputController.instance.mouseWheel * 10);
                if(InputController.instance.mouseWheel < 0.0f)
                {
                    transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime * _speedRotation);
                }
                if (InputController.instance.mouseWheel > 0.0f)
                {
                    transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime * _speedRotation);
                }

            }
        }
        else
        {
            _renderRegulator.material = _normalMaterial;
            InputController.instance.isSelected = false;
        }
    }
}
