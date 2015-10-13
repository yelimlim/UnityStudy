using UnityEngine;
using System.Collections;

public class BoomScript : MonoBehaviour 
{
    public GameObject explosionParticle;

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("OnCollisionEnter : " + other.gameObject.name);

        GameObject explosionParticleObj = Instantiate(explosionParticle) as GameObject;
        explosionParticleObj.transform.position = transform.position;
        
        Destroy(gameObject);
    }
}
