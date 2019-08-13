using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimExample : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)) ||
            (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.S))) {

            anim.SetBool("isRunning", true);

        }
         if ((Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.D)) ||
            (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S))) {

            anim.SetBool("isRunning", false);

        }
        if (Input.GetKeyDown(KeyCode.Space)) {

            anim.SetBool("isJumping", true);
            Invoke("stopJump", 1.45f);

           

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            anim.SetBool("isBarking", true);
            Invoke("stopBark", 0.45f);


        }
        if (Input.GetKeyDown(KeyCode.E)) {

            anim.SetBool("isSmelling", true);
            Invoke("stopSmell", 3.3f);


        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        print("working");
        if ((other.tag == "Memory") && (Input.GetKeyDown(KeyCode.R))) {

            anim.SetBool("isSmelling", true);
            Invoke("stopSmell", 2f);


        }
    }*/

    public void stopJump()
    {

        anim.SetBool("isJumping", false);

    }
    public void stopBark()
    {

        anim.SetBool("isBarking", false);

    }
    public void stopSmell()
    {

        anim.SetBool("isSmelling", false);

    }

}

