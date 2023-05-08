using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grab : MonoBehaviour
{
    private static int lvlCount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "P1")
        {
            Destroy(other.gameObject);
            GameManager.instance.active = true;
        }

        if (other.gameObject.tag == "P3")
        {
            Destroy(other.gameObject);
            GameManager.instance.run = true;
        }

        if (other.gameObject.tag == "Finish")
        {
            if (GameManager.instance.unlocked)
            {
                nextLevel();
            }
        }

        if (other.gameObject.tag == "End")
        {
            if (GameManager.instance.unlocked)
            {
                System.Diagnostics.Process.Start(Application.dataPath + "/../The_World's_Hardester_Game.exe");
                Application.Quit();
            }
        }
    }
    public static void nextLevel()
    {
        GameManager.instance.count++;
        lvlCount = GameManager.instance.count;

        switch (lvlCount)
        {
            case 1:
                SceneManager.LoadScene("Level 1");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
            case 4:
                SceneManager.LoadScene("Level 4");
                break;
            case 5:
                SceneManager.LoadScene("Level 5");
                break;
            case 6:
                SceneManager.LoadScene("Level 6");
                break;
            case 7:
                SceneManager.LoadScene("Level 7");
                break;
            default:
                break;
        }
    }
}