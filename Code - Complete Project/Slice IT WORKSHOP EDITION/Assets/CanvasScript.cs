using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Text FirstMsg;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("P",5f);
    }
    void DisableText(){
        FirstMsg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
