using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class HapticFeedback : MonoBehaviour
{
    public DateTime CurrentTime;
    StringBuilder data = new StringBuilder();
    public float reactionTime = 0;
    public string currentAvatar = "";
    private float startReaction = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ArrayList avatars = new ArrayList();
        avatars.AddRange(GameObject.FindGameObjectsWithTag("Avatar"));
        avatars.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        bool detected = false;
        foreach (GameObject i in avatars) {
            float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("OVRPlayer").transform.position, i.transform.position);
            if (dist <= 2)
            {
                if(currentAvatar != i.name)
                {
                    startReaction = Time.realtimeSinceStartup;
                }
                OVRInput.SetControllerVibration(4 - 2 * dist, 4 - 2 * dist, OVRInput.Controller.LTouch);
                OVRInput.SetControllerVibration(4 - 2 * dist, 4 - 2 * dist, OVRInput.Controller.RTouch);
                currentAvatar = i.name;
                detected = true;
                reactionTime = Time.realtimeSinceStartup - startReaction;
            }
        }
        if (!detected){
            reactionTime = 0;
        }
    }
}
