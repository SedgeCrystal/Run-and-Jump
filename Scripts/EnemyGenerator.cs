using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
