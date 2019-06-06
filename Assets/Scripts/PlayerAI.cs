using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public Player player;
    
    public void Init(){

      

    }
    public void UpdateStep(){

       
         if(Input.GetKey(KeyCode.A)){
            player.MoveLeft();
        }
        if(Input.GetKey(KeyCode.D)){
            player.MoveRight();
        }
    }

   
   
}
