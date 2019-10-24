using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBackSystem : MonoBehaviour
{
    public delegate void OnMessageReceived();

    // Start is called before the first frame update
    void Start()
    {
        OnMessageReceived test = WriteMessage;
        test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WriteMessage()
    {
        Debug.Log("WriteMessage() Called");
    }
}
