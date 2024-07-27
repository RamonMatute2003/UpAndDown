using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float timeSpawn = 0f;
    [SerializeField] Transform gameZone;
    private List<GameObject> _obstacles;
    private float _lastSpawnTime = 0f;

    private void Awake() {
        _obstacles = new List<GameObject>();
    }

    private void Start() {
        _lastSpawnTime = Time.time;
    }

    private void Update() {
        if(GameManager.Instance.isGameOver) {
            return; 
        }

        if(Time.time - _lastSpawnTime > timeSpawn) {
            SpawnObstacle();
            _lastSpawnTime = Time.time;
        }

        DisableSpawn();
    }

    private void DisableSpawn() {
        foreach(GameObject obstacle in _obstacles) {
            if(obstacle.transform.position.x < transform.position.x) {
                obstacle.SetActive(true);
            }
        }
    }

    private void SpawnObstacle() {
        GameObject obstacle = GetList();
        obstacle.GetComponent<Move>().ChangeObstacleSize(gameZone.localScale.y * 0.1f, gameZone.localScale.y * 0.6f);

        int randomPosition = UnityEngine.Random.Range(0, 2);

        if(randomPosition == 0) {
            obstacle.transform.localRotation = Quaternion.Euler(0, 0, 0);
            obstacle.transform.position = new Vector2(transform.position.x, -gameZone.localScale.y / 2);
        } else {
            obstacle.transform.localRotation = Quaternion.Euler(0, 0, 180);
            obstacle.transform.position = new Vector2(transform.position.x, gameZone.localScale.y / 2);
        }

        obstacle.SetActive(true);
    }

    private GameObject GetList() {
        foreach(GameObject obstacle in _obstacles) {
            if(!obstacle.activeInHierarchy) {
                return obstacle;
            }
        }

        return CreateObstacle();
    }

    private GameObject CreateObstacle() {
        GameObject gameObject = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        gameObject.name = obstaclePrefab.name + "_" + _obstacles.Count;
        gameObject.SetActive(false);
        gameObject.transform.parent = transform;
        _obstacles.Add(gameObject);

        return gameObject;
    }
}
