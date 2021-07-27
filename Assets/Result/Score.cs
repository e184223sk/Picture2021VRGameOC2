using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //定義
    Text score;

    //スコアテキストの取得
    //スコア表示
    void Start()
    {
        score = GameObject.Find("score").GetComponent<Text>();
        score.text = ("Score:" + BreakData.BreakingPercentage.ToString() + "%");
    }
     
}
