using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour{
    [SerializeField] float time;

    void Update(){
        transform.Translate(Vector3.left*time*Time.deltaTime);
    }
}
