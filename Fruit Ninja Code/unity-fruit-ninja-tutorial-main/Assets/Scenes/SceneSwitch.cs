using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int BoxCount = 0;
    public int WatermelonCount = 0;
    void OnTriggerEnter(Collider other){

        if(BoxCount + WatermelonCount > 50){
        SceneManager.LoadScene(1);
        }
    }
}
