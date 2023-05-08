using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerManager player;
    public Vector3 newPos;

    public bool run = false;
    public bool unlocked = false;
    public bool active = false;
    public bool activate = false;
    public bool n = false;
    public bool r = false;
    public int count = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (r)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            r = false;
        }

        if (n)
        {
            Grab.nextLevel();
            n = false;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

        if (GameObject.Find("Key") == null)
        {
            unlocked = true;
        }
        else unlocked = false;
    }
}

