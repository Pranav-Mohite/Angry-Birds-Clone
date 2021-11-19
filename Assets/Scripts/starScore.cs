using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starScore : MonoBehaviour
{
    public GameObject star1, star2, star3;

    public int maxScore;
    public int currentScore;

    public TextMeshProUGUI score;

    void Update()
    {
        int.TryParse(score.text, out currentScore);

        if(currentScore >= (maxScore / 2))
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }

        if (currentScore < (maxScore / 2))
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }

        if(currentScore < (maxScore/ 4))
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }
}
