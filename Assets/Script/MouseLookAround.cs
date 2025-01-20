using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    public float rotationX = 0f;
    public float rotationY = 0f;

    public Vector2 sensitivity = Vector2.one * 360f;

    public GameObject player;

    void Update()
    {
        //Input
        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity.x;
        rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * -1 * sensitivity.y;
        //Vertical Look Limit (จำกับการมองแนวตัง ปล.ก้ม/เงยหน้า)
        if (rotationX < -65 || rotationX > 45) 
        {
            if (rotationX < -65) 
            { 
                rotationX = -65; 
            }
            if (rotationX > 45) 
            { 
                rotationX = 45; 
            }
        }
        //Possess คำสั่งให้กล้องหันตามเมาส์ 
        player.transform.localEulerAngles = new Vector3(0f,rotationY,0f);
        this.transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}