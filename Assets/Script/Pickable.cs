using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public Player player;

    public Rigidbody rigi;

    public TMP_Text pickupText;


    private void Awake()
    {
        pickupText.transform.position = this.transform.position;
        pickupText.gameObject.SetActive(false);

        rigi = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        TextLook();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            pickupText.gameObject.SetActive(true);

            if (Input.GetButtonDown("Pickup")) 
            {
                player.inventory.PickUp(this);
                
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
        pickupText.transform.LookAt(player.transform.position);
    }


}
