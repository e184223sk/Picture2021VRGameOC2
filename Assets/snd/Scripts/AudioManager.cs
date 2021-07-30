using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource[] _sources = new AudioSource[4];

    public AudioClip _BREAK;

    public static AudioClip _breakSE;


    public float _base_Dis_set;

    public static float _baseDis;


    public static GameObject Player;

    //game = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    // Start is called before the first frame update
    void Awake()
    {

        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            _sources[i] = this.gameObject.transform.GetChild(i).GetComponent<AudioSource>();
        }
        _breakSE = _BREAK;
        _baseDis = _base_Dis_set;

        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
  /*  void Update()
    {
        for (int i = 0; i < _objs.Length; i++)
        {
            if (_L_objs[i] == null) continue;

            //壊れた瞬間
            if (_objs[i] == null && _L_objs[i] != null)
            {
                Debug.Log(_objs[i].transform.name);
                float[] d = new float[4];
                for (int j = 0; j < d.Length; j++)
                {
                    Vector3 tmp_pos = _objs[i].transform.position;
                    d[j] = Vector3.Distance(_sources[j].transform.position, tmp_pos) / _baseDis;

                }

                //再生
                for (int k = 0; k < _sources.Length; k++)
                {
                    //距離の割合で音量調整
                    _sources[k].PlayOneShot(_breakSE, d[k]);
                }
            }
            _L_objs[i] = null;
        }
    }*/

    public static void Play(Vector3 position)
    {
        float[] d = new float[4];
        float PtoO = 1 - Vector3.Distance(position, Player.transform.position) / _baseDis; 
            
        //AudioとOBJの位置
        for (int j = 0; j < _sources.Length; j++)
        {
            d[j] = Vector3.Distance(_sources[j].transform.position, position) ;
        }

        float mostnear = 10000f;
        int index = -1;

        //オーディオの再生
        for(int i =0; i <d.Length; i++)
        {
            if (i < mostnear) 
            {
                mostnear = d[i];
                index = i;
            }
        }
        _sources[index].PlayOneShot(_breakSE, PtoO);


    }
}
