using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
    Vector3 localPosition = Vector3.zero;
    float slowSpeed = 0.1f;

	// Use this for initialization
	void Start () 
    {
        localPosition = transform.localPosition;
	}

    public void PlayCameraShake()
    {
        StopAllCoroutines();
        StartCoroutine(CameraShakeProcess(1.0f, 0.2f));
    }

    IEnumerator CameraShakeProcess(float shakeTime, float shakeSense)
    {
        float deltaTime = 0.0f;

        while(deltaTime < shakeTime)
        {
            deltaTime += Time.deltaTime;

            transform.localPosition = localPosition;
            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(-shakeSense, shakeSense);
            pos.y = Random.Range(-shakeSense, shakeSense);
            pos.z = Random.Range(-shakeSense, shakeSense);
            transform.localPosition += pos;

            yield return new WaitForEndOfFrame();
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, localPosition, slowSpeed * Time.deltaTime);
        yield return null;
    }
}
