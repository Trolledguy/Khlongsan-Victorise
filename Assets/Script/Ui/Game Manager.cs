using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    //Only Apply Name Like (00_ObjectName)
    public GameObject[] allItems;

    private int levelUnlock;

    private void Start()
    {
        //Sorting Items
        SortInfo(allItems);
    }

    private enum status
    { 
        stage1, stage2, stage3
    }

    private void Update()
    {
        

    }

    //Method
    private void SortInfo(GameObject[] items) 
    {
        foreach (GameObject item in items) 
        {
            string rawItemCode = item.name.Substring(0, 2);
            int itemCode = int.Parse(rawItemCode);
            Debug.Log($"This is Item Code : {itemCode}");
        }


    }

}
