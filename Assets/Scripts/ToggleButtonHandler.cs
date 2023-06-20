using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonHandler : MonoBehaviour
{ 
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Toggle toggle;
    public GameObject TargetObject
    {
        get => targetObject;
        set => targetObject = value;
    }
    
    ToggleGroupHandler _pickerContainer;

    void Start()
    {
        _pickerContainer = transform.GetComponentInParent<ToggleGroupHandler>();
        Debug.Log(name + " Obtained Toggle Group Container: "+_pickerContainer.name);
        toggle = GetComponentInChildren<Toggle>();
        toggle.onValueChanged.AddListener(UpdateObjectPicker);
    }

    void UpdateObjectPicker(bool isSet)
    {
        if (isSet)
        {
            _pickerContainer.ChosenObject = targetObject;
        }
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(UpdateObjectPicker);

    }

}
