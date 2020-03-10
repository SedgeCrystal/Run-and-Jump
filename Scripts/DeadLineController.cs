using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineController : MonoBehaviour
{
    GameObject mainCamera;

    float offSetX = -30.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = GameObject.FindWithTag("MainCamera");
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainCamera.transform.position + new Vector3(offSetX, 0, 0);
    }
}
