using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
    How to setup a pickup
    1.Setup Object
        =Change naem for example (00_Object1 , 01_Object2 )
        -Add comp 
            -Sphere collider with IsTrigger
            -Rigibody
        -Add UI Text
    2.Setup Script 
        -Set Player
        -Set Rigibody
        -Set Text
    3.Add to Prefab
    4.Add Prefab to Item list in Game Manage Object
*/

public class Pickable : MonoBehaviour
{
    public bool isInUI;
    public int thisSlotPos;

    public Player player;

    public Rigidbody rigi;

    public TMP_Text pickupText;


    private void Awake()
    {
        isInUI = false;

        
        pickupText.gameObject.SetActive(false);

        rigi = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        pickupText.transform.position = this.transform.position + new Vector3(0f, 0.5f, 0f);
        TextLook();

        //UI Update
        if (isInUI) 
        {
            this.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
            this.transform.position = player.inventory.slotPos[thisSlotPos].transform.position;
            this.transform.LookAt(player.camPos);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            pickupText.gameObject.SetActive(true);

            if (Input.GetButtonDown("Pickup")) 
            {
                Collider collider = this.GetComponent<Collider>();
                player.inventory.PickUp(this);
                collider.enabled = false;
                this.gameObject.SetActive(false);
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pickupText.gameObject.active != false) 
        {
            pickupText.gameObject.SetActive(false);
        }
    }


    //====================
    //Method

    public void TextLook() 
    {
        if (!isInUI) 
        {
            pickupText.transform.LookAt(player.cam.transform.position);
        }
        
    }


}
