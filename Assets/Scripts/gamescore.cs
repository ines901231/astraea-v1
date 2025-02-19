using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamescore : MonoBehaviour
{
    Text scorecount;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            Updatescorecount();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scorecount = GetComponent<Text>();
    }

    void Updatescorecount()
    {
        string scoreStr = string.Format("{0:000000}", score);
        scorecount.text = scoreStr;
    }

}
