using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class ParametersUpdateHandler : MonoBehaviour
{
    [SerializeField]
    private IntroToProgramming introObject;

    [SerializeField] private TMP_InputField numObjectsField;
    [SerializeField] private TMP_InputField objectScaleField;
    [SerializeField] private ToggleGroupHandler colorToggles, objectToggles;

    void Start()
    {
        
        introObject = GetComponent<IntroToProgramming>();
        
        colorToggles.toggledObjectChanged.AddListener(UpdateColor);
        objectToggles.toggledObjectChanged.AddListener(UpdateModel);
        numObjectsField.onEndEdit.AddListener(UpdateCount);
        objectScaleField.onEndEdit.AddListener(UpdateScale);
    }

    void UpdateColor(GameObject image)
    {
        Color col = image.GetComponent<Image>().color;
        introObject.ModelColor = col;
    }

    void UpdateModel(GameObject model)
    {
        introObject.selectedModel = model.GetComponent<ModelSelector>().SelectedModel;
    }

    void UpdateCount(string str)
    {
        introObject.NumberOfInstancesToCreate = int.Parse(str);
    }

    void UpdateScale(string str)
    {
        introObject.InstanceScale = float.Parse(str);
    }

    void OnDestroy()
    {
        colorToggles.toggledObjectChanged.RemoveListener(UpdateColor);
        objectToggles.toggledObjectChanged.RemoveListener(UpdateModel);

        numObjectsField.onEndEdit.RemoveListener(UpdateCount);
        objectScaleField.onEndEdit.RemoveListener(UpdateScale);
    }
    
}
