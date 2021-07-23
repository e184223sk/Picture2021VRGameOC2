using UnityEngine;
using UnityEngine.UI;

public class HardWareSetScene_Console : MonoBehaviour
{  
    public void Write(string x)
    {
        Text text = transform.Find("Text").GetComponent<Text>(); 
        if (text.text.Length - text.text.Replace("\n", "").Length > 5)
            text.text = text.text.Substring(text.text.IndexOf("\n") + 1);
        text.text += x + "\n";
    }
}
