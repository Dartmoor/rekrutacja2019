using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
     void UpdateOnHit();
     Vector3 GetHitVelocity(RaycastHit2D hit, Vector3 velocity);
}
