using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public bool isLock;

    public GameObject requiredItem;
    private Rigidbody rigi;

    public TMP_Text ui;


    private void Start()
    {
        rigi = this.GetComponent<Rigidbody>();
        ui.gameObject.SetActive(false);
        if (isLock) 
        { 
            rigi.isKinematic = true;
        }
    }
    private void Update()
    {
        Vector3 camPos = Camera.main.transform.position;

        ui.transform.LookAt(new Vector3(-camPos.x, transform.position.y, -camPos.z));
    }


    //Check Key Items
    private void OnTriggerEnter(Collider item)
    {
        if (item.gameObject == requiredItem.gameObject) 
        {
            rigi.isKinematic = false;
            Destroy(item.gameObject);
        }
    }

    private void OnTriggerStay(Collider player)
    {
        if (isLock) 
        {
            if (player.tag == "Player")
            {
                ui.gameObject.SetActive(true);
                


            }
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (ui.gameObject.active != false)
        {
            ui.gameObject.SetActive(false);
        }
    }

}
