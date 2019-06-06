using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHittable
{
    public float maxBounceAngle = 45f;
    public float maxVelocity = 1f;
    private Vector3 velocity = Vector2.zero;

    public void UpdateStep() {
        
        transform.position += velocity * Time.fixedDeltaTime;
        velocity = Vector3.zero;

        float playerHalfWidth = transform.localScale.x/2f;

        Wall rightWall = GameController.GetInstance().rightWall;
        float rightWallHitPositionX = rightWall.transform.position.x - rightWall.transform.localScale.x/2f;

        Wall leftWall = GameController.GetInstance().leftWall;
        float leftWallHitPositionX = leftWall.transform.position.x + leftWall.transform.localScale.x/2f;

        if(transform.position.x + playerHalfWidth > rightWallHitPositionX){
            transform.position = new Vector3(rightWallHitPositionX - playerHalfWidth, transform.position.y, transform.position.z);
        }
        if(transform.position.x - playerHalfWidth < leftWallHitPositionX){
            transform.position = new Vector3(leftWallHitPositionX + playerHalfWidth, transform.position.y, transform.position.z);
        }


    }

    public void MoveLeft(){
        velocity = new Vector3(-maxVelocity,0f,0f);
        GameController.GetInstance().currentScore -= 1;
        
    }

    public void MoveRight(){
        velocity = new Vector3(maxVelocity,0f,0f);
        GameController.GetInstance().currentScore -= 1;
    }

    public void UpdateOnHit(){}

    public Vector3 GetHitVelocity(RaycastHit2D hit, Vector3 velocity)
    {
        Vector3 projectedPoint = new Vector3(hit.point.x, transform.position.y, transform.position.z);
        float distanceFromCenter = Vector3.Distance(projectedPoint, transform.position);
        float angle = distanceFromCenter / ((transform.localScale.x / 2f)) * maxBounceAngle * Mathf.Sign(transform.position.x-hit.point.x);
        Vector3 defaultVelocity = Vector3.Reflect(velocity, hit.normal);

        return Quaternion.Euler(0f,0f, angle) * Vector3.up * velocity.magnitude;
    }
}
