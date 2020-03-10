using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public GameObject fieldPrefab;
    public GameObject enemyPrefab;
    GameObject player;
    float lastY;
    float lastX;
    float offSetY = -5;
    float offSetX = 20;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        
        /*for(int i = 0; i < 10; i++)
        {
            GameObject field = Instantiate(fieldPrefab) as GameObject;
            field.transform.position = new Vector3(2*i, -3, 0);
            field.transform.localScale = new Vector3(2, 5, 1);
        }
        */
        this.lastX = 10;
        this.lastY = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float playerX = this.player.transform.position.x;
        //Debug.Log(playerX);
        if(playerX > lastX-offSetX)
        {
            float nextY = Random.Range(-1, 4) + offSetY;
            float nextX = Random.Range(1, (3 - (nextY-lastY))) + playerX + offSetX;
            float width = Random.Range(9, 14);
            nextX += width / 2;
            GenetateField(nextX,nextY,width);


            if(Random.Range(-2,5) > 0)
            {
                GameObject enemy = Instantiate(enemyPrefab) as GameObject;

                enemy.transform.position = new Vector3(nextX +Random.Range(-1,2), nextY + Random.Range(4,7), 0);
            }
        }
     }

    void GenetateField(float nextX,float nextY,float width)
    {
        float playerX = this.player.transform.position.x;
        GameObject field = Instantiate(fieldPrefab) as GameObject;

        field.transform.position = new Vector3(nextX  , nextY, 0);
        field.transform.localScale = new Vector3(width, 5, 1);
        this.lastX = nextX+(width-width/2);
        this.lastY = nextY;
        
    }
}
