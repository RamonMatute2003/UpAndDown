using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour{
    [SerializeField] GameObject obstacle_prefab;
    [SerializeField] float time_spawn;
    [SerializeField] GameObject spawn_game_object;
    private List<GameObject> obstacles;
    
    private void Awake(){
        obstacles=new List<GameObject>();
        print("a");
    }

    private void Start() {
        InvokeRepeating(nameof(spawn),0.5f,time_spawn);
    }

    private void Update(){
        disable_spawn();
    }

    private void disable_spawn(){
        foreach(GameObject obstacle in obstacles) {
            if(obstacle.transform.position.x >= -spawn_game_object.transform.position.x) {
                gameObject.SetActive(false);
            }
        }
    }

    private void spawn(){
        GameObject obstacle=get_list();
        obstacle.SetActive(true);
    }

    private GameObject get_list(){
        foreach(GameObject obstacle in obstacles){
            if(obstacle.activeInHierarchy){
                return obstacle;
            }
        }

        return crete_obstacle();
    }

    private GameObject crete_obstacle() {
        GameObject gameObject=Instantiate(obstacle_prefab,transform);
        gameObject.name=obstacle_prefab.name+"_"+obstacles.Count;
        gameObject.SetActive(false);
        obstacles.Add(gameObject);

        return gameObject; 
    }
}
