using UnityEngine;
using System.Collections;

public class iTweenTest : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = Vector3.zero;
            Hashtable hash = new Hashtable();
            hash.Add("scale", Vector3.one);
            hash.Add("time", 1.0f);
            hash.Add("easetype", iTween.EaseType.easeOutElastic);

            iTween.ScaleTo(gameObject, hash);

            //hash.Clear();
            Hashtable hash2 = new Hashtable();
            hash2.Add("y", 1080.0f);
            hash2.Add("time", 2.0f);
            hash2.Add("easetype", iTween.EaseType.easeOutExpo);

            iTween.RotateTo(gameObject, hash2);
        }
	}
}
