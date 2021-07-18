using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoGetCompornennt))] // 拡張するクラスを指定

public class AutoGetComp : Editor { 
    public override void OnInspectorGUI()
    {
        // 元のインスペクター部分を表示
        base.OnInspectorGUI();

        // targetを変換して対象を取得
        AutoGetCompornennt autoGetCompornennt = target as AutoGetCompornennt;
    
        // publicなメソッドを実行するボタン
        if (GUILayout.Button("GetGameObject"))
        {
            autoGetCompornennt.DataSet_GameObject();
        }

        // privateなメソッドを実行するボタン
        if (GUILayout.Button("GetRigidbody"))
        {
            autoGetCompornennt.SendMessage("DataSet_Rigidbody", null, SendMessageOptions.DontRequireReceiver);
        }
    }
}
