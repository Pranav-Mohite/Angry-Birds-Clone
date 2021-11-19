using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pigs : MonoBehaviour
{
    public float health;

    public GameObject scoreUpdate;
    TextMeshProUGUI levelScore;

    private void Start()
    {
        scoreUpdate = GameObject.FindGameObjectWithTag("score");

        levelScore = scoreUpdate.GetComponent<TextMeshProUGUI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "birds" || collision.relativeVelocity.magnitude > health)
        {
            score();
            Destroy(gameObject);
        }

    }

    public void score()
    {
        int x = 5000;
        int.TryParse(levelScore.text,out int y);
        int z = x + y;
        levelScore.text = z.ToString();
    }
}
