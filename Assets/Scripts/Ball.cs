using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 velocity = new Vector3(1f,1f, 0f);

    public void UpdateStep(){

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(velocity.x,velocity.y), (velocity.magnitude * Time.fixedDeltaTime));

        if(hit.collider!=null){

            IHittable hitObject = hit.collider.GetComponent<IHittable>();
            if(hitObject!=null){
                transform.position = transform.position + velocity.normalized * hit.distance;
                transform.position += new Vector3(hit.normal.x, hit.normal.y, 0f) * 0.05f;
                velocity = hitObject.GetHitVelocity(hit, velocity);

                hitObject.UpdateOnHit();
            }

        }else{
             transform.position += velocity  * Time.fixedDeltaTime;

        }
    }

}
