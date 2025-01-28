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
    public Pickable[] items;
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
                        pickUpItem.rigi.isKinematic = true;
                        pickUpItem.thisSlotPos = slot;
                        pickUpItem.isInUI = true;
                        items[slot] = pickUpItem;
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


    public void DropItem(int slot) 
    {
        
        try
        {
            Collider itemCollider = items[slot].GetComponent<Collider>();
            itemCollider.enabled = true;
            items[slot].isInUI = false;
            items[slot].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        catch (MissingReferenceException) { items[slot] = null; return; }
        catch (NullReferenceException) { return; }

        
        items[slot].transform.position = slotPos[slot].transform.position;
        items[slot].rigi.isKinematic = false;
        items[slot].gameObject.SetActive(true);
        items[slot] = null;
    }


    public void UseItem()
    {
        
    }



}
