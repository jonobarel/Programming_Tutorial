using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private OrbitingCamera orbitingCamera;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        if (orbitingCamera == null || slider == null)
        {
            Debug.Log("Missing camera or slider gameobject");
        }

        slider.onValueChanged.AddListener(UpdateOrbitSpeed);
    }

    void Start()
    {
        orbitingCamera.RotationSpeed = slider.value;
    }

    private void UpdateOrbitSpeed(float value)
    {
        orbitingCamera.RotationSpeed = value;
    }
}
