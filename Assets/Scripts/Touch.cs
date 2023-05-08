using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!GameManager.instance.active)
            {
                GameManager.instance.run = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                GameManager.instance.active = false;
            }
        }
    }
}
