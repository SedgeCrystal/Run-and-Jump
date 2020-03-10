using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

   


    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("triggerEnter");
        if(other.gameObject.tag == "Shot")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
