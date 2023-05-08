using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Material Cube;
    [SerializeField] private Material Shield;

    private float ySpeed;
    private float ogStepOffset;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = Cube;
        controller = GetComponent<CharacterController>();
        ogStepOffset = controller.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.activate)
        {
            print(GameManager.instance.newPos);
            gameObject.SetActive(false);
            transform.position = GameManager.instance.newPos;
            gameObject.SetActive(true);

            GameManager.instance.activate = false;
        }
            if (GameManager.instance.active)
        {
            gameObject.GetComponent<MeshRenderer>().material = Shield;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = Cube;
        }
        if (transform.position.y <= -3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            float mag = Mathf.Clamp01(move.magnitude) * speed;
            move.Normalize();

            ySpeed += Physics.gravity.y * Time.deltaTime;

            if (controller.isGrounded)
            {
                controller.stepOffset = ogStepOffset;
                ySpeed = -0.5f;

                if (Input.GetButton("Jump"))
                {
                    ySpeed = jumpSpeed;
                }
            }
            else
            {
                controller.stepOffset = 0;
            }

            Vector3 velocity = move * mag;
            velocity.y = ySpeed;

            controller.Move(velocity * Time.deltaTime);

            if (move != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rSpeed * Time.deltaTime);
            }
        }

        if (Input.GetButtonDown("Restart")) GameManager.instance.r = true;
        if (Input.GetButtonDown("Next Level")) GameManager.instance.n = true;
    }
}
