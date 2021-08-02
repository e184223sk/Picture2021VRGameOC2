using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public GameObject[] _Buildings;

    public float _countdown = 0f;

    public int _L_Count = 0;

    public float _buildingCount;

    public static bool _GameStart = false;

    public GameObject _player;

    public GameObject _mainCam;

    public float _spawnCount;

    public GameObject _100gokan;

    // Start is called before the first frame update
    void Start()
    {

        _Buildings = GameObject.FindGameObjectsWithTag("Building");
        if (!IsDebug)
        {

            //_Buildings = FindObjectsOfType<AutoGetCompornennt>().

            _mainCam = GameObject.Find("Main Camera");

            _player = GameObject.Find("Player");
            _player.SetActive(false);

            _buildingCount = _Buildings.Length - 1;
            foreach (var b in _Buildings)
            {
                if (b.name == "100gokan") 
                    _100gokan = b;
                b.SetActive(false);
            }
        }
        else
        {
            foreach (var g in _Buildings)
                g.SetActive(false);
        }

    }

    public bool IsDebug = false;


    // Update is called once per frame
    void Update()
    {
        if (!IsDebug)
        {
            _countdown += Time.deltaTime;

            if (_L_Count != (int)_countdown && _Buildings.Length > _L_Count)
            {

                if (_Buildings[_L_Count].name == "100gokan")
                {
                    _L_Count++;
                    return;
                }
                _Buildings[_L_Count].SetActive(true);
                _L_Count++;

            }


            if (_buildingCount == _L_Count)
            {
                _mainCam.SetActive(false);
                _player.SetActive(true);
                _GameStart = true;
            }

            if(_spawnCount < _countdown)
            {
                _100gokan.SetActive(true);
            }

        }
    }
}

