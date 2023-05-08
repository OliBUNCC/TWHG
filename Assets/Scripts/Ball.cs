using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float x, z;

    private Vector3 startPos;
    private Vector3 dP;

    private bool forward;
    private bool right;

    private float speed = 8f;
    private float zDif;
    private float xDif;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        dP = new Vector3(x, 0.6f, z);

        forward = true;
        right = true;

        zDif = startPos.z - dP.z;
        xDif = startPos.x - dP.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (zDif == 0) forward = false;
        else
        {
            if (forward)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
                if (transform.position.z <= dP.z && zDif > 0 ||
                    transform.position.z >= dP.z && zDif < 0) forward = false;
            }
            else
            {
                transform.Translate(transform.forward * -speed * Time.deltaTime, Space.World);
                if (transform.position.z >= startPos.z && zDif > 0 ||
                    transform.position.z <= startPos.z && zDif < 0) forward = true;
            }
        }
        if (xDif == 0) right = false;
        else
        {
            if (right)
            {
                transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
                if (transform.position.x <= dP.x && xDif > 0 ||
                    transform.position.x >= dP.x && xDif < 0) right = false;
            }
            else
            {
                transform.Translate(transform.right * -speed * Time.deltaTime, Space.World);
                if (transform.position.x >= startPos.x && xDif > 0 ||
                    transform.position.x <= startPos.x && xDif < 0) right = true;
            }
        }
    }
}
