using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour
{
    public bool go = false;
    private float speed = 8f;
   
    // Update is called once per frame
    void Update()
    {
        go = GameManager.instance.run;
        if (go)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        }
    }
}
