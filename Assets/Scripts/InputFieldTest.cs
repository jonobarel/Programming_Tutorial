using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FieldUpdated()
    {
        Debug.Log("Field Updated");
    }

    public void EditEnded()
    {
        Debug.Log("Edit Ended");
    }
}
