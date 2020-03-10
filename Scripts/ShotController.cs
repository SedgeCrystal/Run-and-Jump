using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    float shotSpeed = 30;
    float lifeTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        lifeTime -= dt;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        Vector3 lastPos = transform.position;
        transform.position =lastPos + new Vector3(shotSpeed*dt, 0, 0);

    }
}
