using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject playerAnimObj;
    public GameObject playerLogicObj;

    AudioSource AS;

    public AudioClip TVDialogue;
    public AudioClip TissueBoxDialogue;
    public AudioClip PillowDialogue;
    public AudioClip LPCarDialogue;
    public AudioClip LPBootDialogue;
    public AudioClip BalloonDialogue;

    public int value;
    // Start is called before the first frame update
    void Start()
    {
        AS = GameObject.FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player" || other.name == "Player")
        {
            FindObjectOfType<GameManager>().addItem(value);

            // Destroy(gameObject);
            this.GetComponent<Collider>().enabled = false;
            playerAnimObj.GetComponent<Animator>().SetBool("isSmelling", true);
            Invoke("stopSmelling", 3.3f);

            playerLogicObj.GetComponent<PlayerMovement>().enabled = false;
            //play sound in GameManager

        }
    }
    void stopSmelling() {

        playerAnimObj.GetComponent<Animator>().SetBool("isSmelling", false);
        playerLogicObj.GetComponent<PlayerMovement>().enabled = true;
        //Trigger dialogue here
        if(this.name == "TV Variant")
        {
            Debug.Log("Play TV Dialogue");
            AS.PlayOneShot(TVDialogue);
        }
        else if(this.name == "TissueBox Variant")
        {
            Debug.Log("Play TissueBox Dialogue");
            AS.PlayOneShot(TissueBoxDialogue);
        }
        else if (this.name == "Pillow Variant")
        {
            Debug.Log("Play Pillow Dialogue");
            AS.PlayOneShot(PillowDialogue);
        }
        else if (this.name == "LPCar Variant")
        {
            Debug.Log("Play LPCar Dialogue");
            AS.PlayOneShot(LPCarDialogue);
        }
        else if (this.name == "LPBoot Variant")
        {
            Debug.Log("Play LPBoot Dialogue");
            AS.PlayOneShot(LPBootDialogue);
        }
        else if (this.name == "Balloon Variant")
        {
            Debug.Log("Play Balloon Dialogue");
            AS.PlayOneShot(BalloonDialogue);
        }

    }
}
