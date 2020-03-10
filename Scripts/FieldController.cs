using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{

    GameObject mainCamera;
    float width;
    float offSetX = 20f;
    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        this.width = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCamera.transform.position.x  > transform.position.x +offSetX + this.width)
        {
            Destroy(gameObject);
        }
    }
}
