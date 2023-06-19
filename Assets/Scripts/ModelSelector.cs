using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelector : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, GameObject> models;
    [SerializeField] string defaultModel = "cocktail";

    private GameObject current = null;
    void Start()
    {
        models = new Dictionary<string, GameObject>();
        PopulateModelsDict();
        ToggleModel(defaultModel);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateModelsDict()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(false);
            models.Add(child.name, child);
        }
    }

    void ToggleModel(string s)
    {
        if (current != null)
        {
            current.SetActive(false);    
        }
        current = models[s];
        current.SetActive(true);
    }
    
    
}
