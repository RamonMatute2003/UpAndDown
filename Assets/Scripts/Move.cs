using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject point;
    private float _startPos;

    private void Start() {
        _startPos = transform.position.x;
    }

    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

        if(transform.position.x <= -_startPos) {
            gameObject.SetActive(false);
        }
    }

    public void ChangeObstacleSize(float minSize, float maxSize) {
        float randomSize = Random.Range(minSize, maxSize);
        obstacle.transform.localScale = new Vector3(1, randomSize, 1);
        obstacle.transform.localPosition = new Vector3(obstacle.transform.localPosition.x, randomSize / 2, obstacle.transform.localPosition.z);

        float pointPosY = obstacle.transform.localPosition.y + randomSize / 2 + point.transform.localScale.y * 0.75f;
        point.transform.localPosition = new Vector3(point.transform.localPosition.x, pointPosY, point.transform.localPosition.z);
        point.SetActive(true);
    }
}
