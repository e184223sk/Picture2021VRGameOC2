using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shougou : MonoBehaviour
{
    //定義
    Text shougou;

    //称号テキストの取得
    void Start()
    {
        shougou = GameObject.Find("Shougou").GetComponent<Text>();
        if (BreakData.BreakingPercentage < 10) shougou.text = ("見習いの破壊者");
        else if (BreakData.BreakingPercentage < 20) shougou.text = ("さすらいの破壊者");
        else if (BreakData.BreakingPercentage < 30) shougou.text = ("一人前の破壊者");
        else if (BreakData.BreakingPercentage < 40) shougou.text = ("破壊の達人");
        else if (BreakData.BreakingPercentage < 50) shougou.text = ("破壊を極めし者");
        else if (BreakData.BreakingPercentage < 60) shougou.text = ("破壊の創造者");
        else if (BreakData.BreakingPercentage < 70) shougou.text = ("天下に轟く破壊者");
        else if (BreakData.BreakingPercentage < 80) shougou.text = ("伝説の破壊者");
        else if (BreakData.BreakingPercentage < 90) shougou.text = ("破壊王");
        else if (BreakData.BreakingPercentage < 100) shougou.text = ("破壊神");
        else shougou.text = ("究極の破壊神");
    }
     
}
