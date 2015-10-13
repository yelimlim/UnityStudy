using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour 
{
    public float sensitivity = 700.0f;
    public float limit_up = 90.0f;
    public float limit_down = 270.0f;
    public float limit_left = -30.0f;
    public float limit_right = 30.0f;

    float rotationX;
    float rotationY;

    PlayerState playerState = null;

    void Start()
    {
        playerState = transform.parent.GetComponent<PlayerState>();
    }

	// Update is called once per frame
	void Update () 
    {
        if(playerState.isDead)
        {
            return;
        }

        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        rotationX %= 360;
        rotationY %= 360;

        //float camera = Camera.main.transform.rotation.x;

//         if (-rotationX >= limit_down)
//         {
//             rotationX = -limit_down;
//         }
//         else if (-rotationX <= limit_up)
//         {
//             rotationX = -limit_up;
//         }
// 
//         if(rotationY >= limit_right)
//         {
//             rotationY = limit_right;
//         }
//         else if(rotationY <= limit_left)
//         {
//             rotationY = limit_left;
//         }

        //Debug.Log("Rotation X : " + rotationX);
        
        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
	}
}
