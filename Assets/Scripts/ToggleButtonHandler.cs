using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonHandler : MonoBehaviour
{ 
    [SerializeField] private GameObject targetObject;

    public GameObject TargetObject
    {
        get => targetObject;
        private set => targetObject = value;
    }
    
    ToggleGroupHandler _pickerContainer;

    void Start()
    {
        _pickerContainer = transform.parent.GetComponentInParent<ToggleGroupHandler>();
        Debug.Log(name + " Obtained Toggle Group Container: "+_pickerContainer.name);
        GetComponent<Toggle>().onValueChanged.AddListener(UpdateObjectPicker);
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
        GetComponent<Toggle>().onValueChanged.RemoveListener(UpdateObjectPicker);

    }

}
