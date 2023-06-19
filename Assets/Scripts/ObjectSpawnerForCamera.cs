using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerForCamera : MonoBehaviour
{
    [SerializeField] private Transform objectSpawnPosition;
    private Transform spawnedObject;
    void Start()
    {
        GameObject objectToSpawn = GetComponent<ToggleButtonHandler>().TargetObject;
        if (objectToSpawn != null)
        {
            spawnedObject = Instantiate(objectToSpawn, objectSpawnPosition).transform;
            spawnedObject.position = objectSpawnPosition.position;

        }

    }

    void Update()
    {
        spawnedObject.Rotate(objectSpawnPosition.transform.up, 90 * Time.deltaTime);
    }
}
