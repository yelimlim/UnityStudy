using UnityEngine;
using System.Collections;

public class iTweenMoveTest : MonoBehaviour 
{
    public Transform target;
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            Hashtable hash = new Hashtable();
            hash.Add("Position", target);
            hash.Add("orienttopath", true);
            hash.Add("looktime", 2.0f);
            hash.Add("easetype", iTween.EaseType.easeInOutExpo);
            hash.Add("time", 2.0f);

            iTween.MoveTo(gameObject, hash);
        }
	}
}
