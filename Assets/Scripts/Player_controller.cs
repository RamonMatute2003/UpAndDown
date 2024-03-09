using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] Transform space_game;

    void Update(){
        movement();
        print("a");
    }

    private void movement(){
        if(Input.GetMouseButtonDown(0)){
            speed=-speed;
        }

        float limit_top=space_game.localScale.y/2-0.75f;
        float limit_bottom=-space_game.localScale.y/2+0.75f;

        if(transform.position.y>=limit_top || transform.position.y<=limit_bottom){
            speed=-speed;
        }

        transform.Translate(Vector3.up*speed*Time.deltaTime);
    }
}
