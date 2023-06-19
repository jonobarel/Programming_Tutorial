using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private TMP_InputField inputField;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(SetTextFromSlider);
        inputField.onEndEdit.AddListener(SetSliderToText);
     
        SetSliderToText(inputField.text);
    }

    void SetSliderToText(string str)
    {
        _slider.value = float.Parse(str);
    }

    void SetTextFromSlider(float value)
    {
        inputField.text = $"{value}";
        inputField.onEndEdit?.Invoke(inputField.text);
    }

    void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(SetTextFromSlider);
        inputField.onEndEdit.RemoveListener(SetSliderToText);
    }
}
