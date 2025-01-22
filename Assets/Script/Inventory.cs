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
    public GameObject[] items;
    public GameObject[] slotPos = new GameObject[9];
    

    public GameManager gameManager;


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
                for (int itemInfoCheck = 0; itemInfoCheck < gameManager.allItems.Length; itemInfoCheck++)
                {
                    if (pickUpItem.gameObject.name == gameManager.allItems[itemInfoCheck].gameObject.name)
                    {
                        //Posess Info
                        pickUpItem.slotPos = slot;
                        items[slot] = pickUpItem.gameObject;
                        return;
                    }

                }
            }
            else if (items[slot] != null) 
            { 
                
            }
            else
            {
                //Full
                Debug.Log("Inventory Full");
                return;
            }
        }
    }


    public void DropItem(GameObject dropedItem ,int slot) 
    {
        dropedItem = items[slot].GetComponent<GameObject>();
        items[slot] = null;
        dropedItem.isInUI = false;
        dropedItem.transform.position = slotPos[slot].transform.position + new Vector3 (0, 0, 1);
        dropedItem.transform.localScale = Vector3.one;
        dropedItem.gameObject.SetActive(true);
    }
    public void UseItem()
    {
        
    }


}
