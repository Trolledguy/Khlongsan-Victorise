using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Player player;
    private Inventory inventory;

    public int slot;

    private void Start()
    {
        
        inventory = player.inventory;
    }

    public void InventoryClick() 
    {
        
    }



}
