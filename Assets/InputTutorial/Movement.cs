using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private string playerName;

    [SerializeField]
    float movementSpeed;
    
    [SerializeField]
    Vector2 input;

    private void Awake()
    {
        Debug.Log("this is awake");
        Debug.Log("PlayerName: "+playerName);

    }
    void Start()
    {
        playerName = "MyName";
        Debug.Log("this is start");
        Debug.Log("PalyerName: " + playerName);
    }

    void Update()
    {
        // distance = time * speed
        transform.position += (Vector3)input * movementSpeed * Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }


}
