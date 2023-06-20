using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private GameObject modelPrefab;
    [SerializeField] private string modelSelectorString;
    [Tooltip("Scale for the object to appear correctly on the selector button")]
    [SerializeField] private float scaleFactor; //scale the model to appear correctly in camera
    private void Start()
    {
        //instantiate the object for display on the button and create material and texture for camera
        GameObject model = Instantiate(modelPrefab, transform);
        model.transform.position = transform.position;
        model.transform.localScale = Vector3.one * scaleFactor;
        HelperMethods.ApplyLayer(model, "UI");
        model.GetComponent<ModelSelector>().SelectedModel = modelSelectorString;
        transform.parent.GetComponent<ToggleButtonHandler>().TargetObject = model;
    }
}
