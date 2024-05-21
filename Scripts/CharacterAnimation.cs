using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{



    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W) == true) || (Input.GetKey(KeyCode.A) == true) || (Input.GetKey(KeyCode.D) == true) || (Input.GetKey(KeyCode.S) == true))
            if (Input.GetKey(KeyCode.LeftShift) == true || Input.GetKey(KeyCode.RightShift) == true)
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
                anim.SetBool("Walk", true);
            }
        else
        {
            anim.SetBool("Running", false);
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        {
            anim.SetBool("Attack 0", true);
            
        }
        else
        {
            anim.SetBool("Attack 0", false);
        }

    }
}
