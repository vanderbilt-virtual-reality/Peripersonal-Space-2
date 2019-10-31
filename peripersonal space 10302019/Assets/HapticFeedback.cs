using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("OVRPlayer").transform.position, GameObject.FindGameObjectWithTag("Avatar").transform.position) == 2){
            print("Hi!!!");
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        }
    }
}
