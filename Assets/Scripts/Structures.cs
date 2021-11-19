using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Structures : MonoBehaviour
{
    public float health;

    public GameObject scoreUpdate;
    TextMeshProUGUI levelScore;

    private void Start()
    {
        scoreUpdate = GameObject.FindGameObjectWithTag("score");

        levelScore = scoreUpdate.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(health <= 0)
        {
            score();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "birds")
        {
            health -= 1;
        }

        if (collision.relativeVelocity.magnitude > health)
        {
            //health -= 1;
        }
    }

    public void score()
    {
        int x = 500;
        int.TryParse(levelScore.text, out int y);
        int z = x + y;
        levelScore.text = z.ToString();
    }
}
