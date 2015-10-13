using UnityEngine;
using System.Collections;

public class iTweenColorTest : MonoBehaviour 
{
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {

            Hashtable hash = new Hashtable();

            hash.Add("from", 0.0f);
            hash.Add("to", 255.0f);
            hash.Add("time", 5.0f);
            hash.Add("onupdate", "UpdateValue");

            iTween.ValueTo(gameObject, hash);
        }
	}

    void UpdateValue(float value)
    {
        mat.color = Color.red * (value / 255.0f);
    }
}
