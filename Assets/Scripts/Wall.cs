using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IHittable
{
    public bool endGameOnHit = false;
    public Vector3 normal = Vector3.right;
    public Vector3 GetHitVelocity(RaycastHit2D hit, Vector3 velocity)
    {
        return Vector3.Reflect(velocity, hit.normal);
    }

    public void UpdateOnHit(){

        if(endGameOnHit){

            GameController.GetInstance().isPlaying = false;

        }
    }
}
