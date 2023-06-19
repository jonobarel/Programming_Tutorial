using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class InputFieldHandler : MonoBehaviour
{
    [SerializeField]
    private IntroToProgramming target;
    
    // Start is called before the first frame update
    void Start()
    {
        Type type = typeof(IntroToProgramming);
        MemberInfo[] members = type.GetMembers();
        string joined = "";
        foreach (var s in members)
        {
            joined += s.Name;
            joined += ", ";
        }
        Debug.Log(joined);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
