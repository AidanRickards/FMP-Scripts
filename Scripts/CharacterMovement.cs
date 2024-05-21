using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public UIScript ui;
    public CharacterController controller;
    public Transform cam;
    Animator anim;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    bool isGrounded;

    public float speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (ui.healthPot >= 1)
            {
                ui.Heal(20);
                ui.healthPot--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (ui.strengthPot >= 1)
            {
                ui.Strength();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (ui.speedPot >= 1)
            {
                ui.Speed();
            }
        }



        if (Input.GetKey(KeyCode.LeftShift) == true || Input.GetKey(KeyCode.RightShift) == true)
        {
            speed = ui.baseSpeed * 1.5f;
        }
        else
        {
            speed = ui.baseSpeed;
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isGrounded == false)
        {
            if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true || Input.GetKey(KeyCode.S) == true)
            {
                anim.SetBool("MoveJump", true);
            }
            else
            {
                anim.SetBool("IdleJump", true);
            }
        }
        else
        {
            anim.SetBool("MoveJump", false);
            anim.SetBool("IdleJump", false);
        }
    }
}
