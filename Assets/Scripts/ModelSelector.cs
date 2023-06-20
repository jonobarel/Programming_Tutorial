using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Serialization;

public class ModelSelector : MonoBehaviour
{
    private Dictionary<string, GameObject> _models = new Dictionary<string, GameObject>();
    [SerializeField] string defaultModel = "cocktail";
    
    [FormerlySerializedAs("_selectedModel")] [SerializeField]
    private string selectedModel;
    public string SelectedModel
    {
        get => selectedModel;
        set
        {
            if (_models.ContainsKey(value))
            {
                ToggleModel(value);
                selectedModel = value;
            }
        }
    }
    private GameObject _current = null;
    
    void Awake()
    {
        PopulateModelsDict();
        SelectedModel = selectedModel.Equals("") ? defaultModel : selectedModel;

    }


    void PopulateModelsDict()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(false);
            _models.Add(child.name, child);
        }
    }

    void ToggleModel(string s)
    {
        if (_current != null)
        {
            _current.SetActive(false);    
        }
        _current = _models[s];
        _current.SetActive(true);
    }
    
    
}
