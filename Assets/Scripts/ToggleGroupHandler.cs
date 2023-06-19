using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ToggleGroupHandler : MonoBehaviour
{
    private ToggleGroup _group;
    [SerializeField] private GameObject chosenObject;

    public UnityEvent<GameObject> toggledObjectChanged; 
    public GameObject ChosenObject
    {
        set
        {
            chosenObject = value;
            toggledObjectChanged?.Invoke(chosenObject);
        }
        get => chosenObject;
    } 

    void Start()
    {
        _group = GetComponent<ToggleGroup>();
        Toggle[] toggles = GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            toggle.group = _group;
        }
        
    }
}
