using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject[] obstaclePatterns;
    public Transform[] targetPositions;

    #region Singleton
    
    static public ObstacleManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    void Start() {
        GenerateObstacles();
    }

    public void GenerateObstacles() {
        foreach (Transform child in transform.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform target in targetPositions)
        {
            GameObject randomPattern = obstaclePatterns[Random.Range(0, obstaclePatterns.Length)];
            Instantiate(randomPattern, target.position, Quaternion.identity, transform);
        }
    }

}
