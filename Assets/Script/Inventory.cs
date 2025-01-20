using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] //บังคับให้ Unity ส่ง Private Property เข้าไปแสดงผลใน inspecter
    private GameObject[] items = new GameObject[9]; 

    //Only Apply Name Like (00_ObjectName)
    public GameObject[] allItems;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void PickUp(Pickable pickUpItem) 
    {
        Debug.Log($"Item picked up {pickUpItem.name}");
        for (int slot = 0; slot < items.Length; slot++)
        {
            //Slot Check
            if (items[slot] == null) 
            {
                //Check Item Exist
                for (int itemInfoCheck = 0;itemInfoCheck < allItems.Length;itemInfoCheck++) 
                {
                    if (pickUpItem.gameObject.name == allItems[itemInfoCheck].gameObject.name) 
                    {
                        //Posess Info
                        items[slot] = pickUpItem.gameObject; 
                        pickUpItem.gameObject.SetActive(false);
                        return;
                    }
                }
            }
            else if (slot >= items.Length) 
            {
                //Full
                Debug.Log("Inventory Full");
                return;
            }
        }
    }


    public void DropItem() 
    {
        
    }

    public void Sort() 
    { 
        
    }

}
