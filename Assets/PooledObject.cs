using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(ModelSelector))]
public class PooledObject : MonoBehaviour
{
    public ObjectPool<ModelSelector> Pool { get; set; }
    private ModelSelector _modelSelector;
    void Start()
    {
        _modelSelector = GetComponent<ModelSelector>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cull"))
        {
            ReleaseObject();
        }
    }

    void ReleaseObject()
    {
        if (Pool != null)
        {
            Pool.Release(GetComponent<ModelSelector>());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
