using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    [Header("Velocidad")]
    [SerializeField] float speed;
    [Header("Zona de juegos")]
    [SerializeField] Transform gameZone;
    private float _topLimitPos;
    private float _bottomLimitPos;
    private int _score = 0;

    private void Start() {
        float heightGameZone = gameZone.localScale.y;

        _topLimitPos = heightGameZone / 2 - 0.5f;
        _bottomLimitPos = -heightGameZone / 2 + 0.5f;
    }

    private void Update(){
        Movement();
    }

    private void Movement(){
        if(Input.GetMouseButtonDown(0)){
            speed = -speed;
        } 

        float newPosY = transform.position.y + speed + Time.deltaTime;
        float limitPosY = Mathf.Clamp(newPosY, _bottomLimitPos, _topLimitPos);
        transform.position = new Vector3(transform.position.x, limitPosY, transform.position.z);

        if(newPosY >= _topLimitPos || newPosY <= _bottomLimitPos){
            speed = -speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Obstacle")) {
            Debug.Log("Game over");
            GameManager.Instance.isGameOver = true;
            gameObject.SetActive(false);
        } else {
            if(collision.CompareTag("Point")) {
                _score++;
                collision.gameObject.SetActive(false);
                Debug.Log("Puntos: "+ _score);
            }
        }
    }
}
