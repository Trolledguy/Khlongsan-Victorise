using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class WarpPhoto : MonoBehaviour
{

    public GameManager GameManager;

    public int level;
    public bool isAvalible;

    public TMP_Text ui;
    public Vector3 uiOffsett;

    private void Start()
    {
        ui.gameObject.SetActive(false);
        ui.transform.position = this.transform.position + uiOffsett;
    }


    private void OnTriggerStay(Collider other)
    {
        if (isAvalible)
        {

            if (other.gameObject.tag == "Player")
            {
                ui.gameObject.SetActive(true);
                UiLookAt(other);

                if (Input.GetButtonDown("Pickup"))
                {
                    Debug.Log($"Level {level} : loaded");
                    //SceneManager.LoadScene(level);
                }
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

    private void UiLookAt(Collider other) 
    {
        Player player = other.GetComponent<Player>();
        ui.transform.LookAt(player.camPos);
    }
}
