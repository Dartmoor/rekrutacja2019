using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IHittable
{
    public Vector3 GetHitVelocity(RaycastHit2D hit, Vector3 velocity)
    {
        return Vector3.Reflect(velocity, hit.normal);
    }

    public void UpdateOnHit()
    {
        gameObject.SetActive(false);
        GameController.GetInstance().blockCountLeft--;
        GameController.GetInstance().currentScore += 1000;

        if(GameController.GetInstance().blockCountLeft==0){
            GameController.GetInstance().isPlaying = false;
        }
        
    }

}
