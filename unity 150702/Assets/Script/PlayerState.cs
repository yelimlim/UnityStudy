using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour 
{
    public int healthPoint = 5;
    public bool isDead = false;

    public void DamageByEnemy()
    {
        if(isDead)
        {
            return;
        }

        --healthPoint;
        GetComponentInChildren<CameraShake>().PlayCameraShake();

        if(healthPoint <= 0)
        {
            isDead = true;
        }
    }

    void OnGUI()
    {
        float x = (Screen.width / 2.0f) - 100;

        Rect rect = new Rect(x, 10, 200, 25);

        if(isDead == true)
        {
            GUI.Box(rect, "Game Over!");
        }
        else
        {
            GUI.Box(rect, "My Health :" + healthPoint);

        }

        GUI.Box(rect, "My Health :" + healthPoint);
    }
    
}
