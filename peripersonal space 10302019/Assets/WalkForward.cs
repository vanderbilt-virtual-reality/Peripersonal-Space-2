using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkForward : MonoBehaviour
{
    public float speed = 0.5f;
    public int step = 2;
    public int wait = 5;
    public int converted_wait = 0;
    public int current_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        //gameObject.transform.Translate(0, 0.05, -8);
        //transform.position = new Vector3(0, 0, -8);
        converted_wait = wait * 60;
        StartCoroutine(Waiter());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current_time > converted_wait)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(-17, 0, -8), step);
            if (gameObject.transform.localPosition == new Vector3(-17, 0, -8))
            {
                gameObject.transform.localPosition = gameObject.transform.localPosition + new Vector3(0, 0, 18);
            }
        }
        current_time++;
    }

    IEnumerator Waiter()
    {
        print(Time.time);
        yield return new WaitForSeconds(10);
        print("Waiting!");
        print(Time.time);
    }
}
