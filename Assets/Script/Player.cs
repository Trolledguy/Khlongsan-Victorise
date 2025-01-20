using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;


public class Player : MonoBehaviour
{

    public float speed;

    public GameManager manager;
    public Inventory inventory;

    public GameObject cam;
    public Transform camPos;


    //Comp For Debug


    public TMP_Text debugMouseScroll;


    private void Update()
    {
        float moveX = Input.GetAxis("MovementX");
        float moveZ = Input.GetAxis("MovementZ");

        //Input Session

        if (moveX != 0 || moveZ != 0) 
        {
            if (moveZ != 0) 
            {
                this.transform.position = transform.position + this.transform.forward * moveZ * speed * Time.deltaTime;
            }
            if (moveX != 0) 
            { 
                this.transform.position = transform.position + this.transform.right * moveX * speed * Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Open Inventory")) 
        { 
            OpenInventory();
        }

        //For update method
        MoveCam();


        //DebugZone



    }

    public void OpenInventory() 
    {
        if (inventory.gameObject.active != true)
        {
            inventory.gameObject.SetActive(true);
        }
        else 
        {
            inventory.gameObject.SetActive(false);
        }
    }


    private void MoveCam() 
    {
        cam.transform.position = camPos.transform.position;

    }

   
}
