using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{

    Text resultText;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        this.score = player.transform.position.x;
        Destroy(player);
        this.resultText = GameObject.Find("ResultText").GetComponent<Text>();
        this.resultText.text = "Your Score:" + this.score.ToString("F1") + "m";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
