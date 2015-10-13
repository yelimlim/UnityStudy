using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour 
{
    public GameObject enemy;
    public float spawnTime = 2.0f;
    
    float deltaSpawnTime = 0.0f;

    int characterCount = 0;
    public int characterCountMax = 1;

    public void characterDead()
    {
        --characterCount;
    }

	// Update is called once per frame
	void Update ()
    {
        if(characterCount >= characterCountMax)
        {
            return;
        }

        deltaSpawnTime += Time.deltaTime;
        if (deltaSpawnTime > spawnTime)
        {
            deltaSpawnTime = 0.0f;

            GameObject enemyObj = Instantiate(enemy) as GameObject;
            float x = Random.Range(-20.0f, 20.0f);
            enemyObj.transform.position = new Vector3(x, 0.1f, 20.0f);
            ++characterCount;
        }
	}
}
