using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{

    public TMP_Text ui;


    private void Start()
    {
        ui.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {
            Inventory playerInvent = other.GetComponent<Inventory>();
            if (playerInvent == null)
            {
                return;
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
