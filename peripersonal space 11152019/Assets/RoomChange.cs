using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RoomChange : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentRoom = 1;
    public string currentAvatar = "";
    public static string fileName;
    public string getFileName;
    void Start()
    {
        fileName = getFileName;
        if (!File.Exists(fileName))
            File.Create(fileName);
        File.WriteAllText(fileName, "file " + System.DateTime.Now + System.Environment.NewLine + System.Environment.NewLine);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject user = GameObject.FindGameObjectWithTag("OVRPlayer");
        if (OVRInput.Get(OVRInput.Button.One))
        {
            if (currentAvatar != GetComponent<HapticFeedback>().currentAvatar)
            {
                File.AppendAllText(fileName, "Avatar: " + GetComponent<HapticFeedback>().currentAvatar + System.Environment.NewLine
                    + "Reaction Time: " + GetComponent<HapticFeedback>().reactionTime + System.Environment.NewLine
                    + "Room Number: " + currentRoom + System.Environment.NewLine);
                currentAvatar = GetComponent<HapticFeedback>().currentAvatar;
            }
        } else if (OVRInput.Get(OVRInput.Button.Two))
        {
            user.transform.position = new Vector3(-16.93f, 1.398f, -5);
            ResetAvatars(10);
            currentRoom = 1;
        } else if (OVRInput.Get(OVRInput.Button.Three))
        {
            user.transform.position = new Vector3(-16.93f, 1.398f, -2);
            ResetAvatars(13);
            currentRoom = 2;
        } else if (OVRInput.Get(OVRInput.Button.Four))
        {
            user.transform.position = new Vector3(-16.93f, 1.398f, 3);
            ResetAvatars(18);
            currentRoom = 3;
        }
    }

    void ResetAvatars(int start)
    {
        ArrayList avatars = new ArrayList();
        avatars.AddRange(GameObject.FindGameObjectsWithTag("Avatar"));
        avatars.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        int count = start;
        foreach (GameObject i in avatars)
        {
            if(i.tag == "Monster")
            {
                i.transform.position = new Vector3(-16.93f, 1, count);
            }
            else
            {
                i.transform.position = new Vector3(-16.93f, 0, count);
            }
            count += 7;
        }
    }
}
