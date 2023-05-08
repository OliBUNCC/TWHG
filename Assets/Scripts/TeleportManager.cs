using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform partner;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.activate = true;
            GameManager.instance.newPos = new Vector3(partner.position.x, 0.5f, partner.position.z);
        }
    }
}
