using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour 
{
    public Transform cameraTransform;
    public GameObject fireobject;
    public float forwardPower = 20.0f;
    public float upPower = 5.0f;

    public Transform firePosTransform;

    PlayerState playerState = null;


    void Start()
    {
        playerState = GetComponent<PlayerState>();
    }

	// Update is called once per frame
	void Update () 
    {
        if (playerState.isDead)
        {
            return;
        }

	    if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(fireobject) as GameObject;
            obj.transform.position = firePosTransform.position;
            obj.GetComponent<Rigidbody>().velocity = cameraTransform.forward * forwardPower + Vector3.up * upPower;

            obj.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }
	}
}
