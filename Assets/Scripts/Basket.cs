using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text ScoreGT;
    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        ScoreGT= scoreGO.GetComponent<Text>();
        ScoreGT.text = "0";
    }
    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject collidedWith = other.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            int score = int.Parse(ScoreGT.text);
            score += 100;
            ScoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }          
        }
    }
}
