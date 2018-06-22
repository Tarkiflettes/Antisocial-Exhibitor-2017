using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public Text WaveDisplayText;

    private GameObject[] _spawnersObjects;
    private Spawner[] _spawners;

    private int _counter = 0;
    private int _maxCounter = 800;
    private int _difficulty = 1;
    private int _speedMin = 4;
    private int _speedMax = 4;
    private int _nbBots = 3;

    // Use this for initialization
    void Start ()
    {
        WaveDisplayText.text = "Wave " + (_difficulty - 1).ToString();
        _spawnersObjects = GameObject.FindGameObjectsWithTag("Spawner");
        _spawners = new Spawner[_spawnersObjects.Length];
        for(int i = 0; i < _spawnersObjects.Length; i++)
        {
            _spawners[i] = _spawnersObjects[i].GetComponent<Spawner>();
        }
        _counter = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if(_counter >= 0)
        {
            _counter--;
        }
        else
        {

            foreach(Spawner s in _spawners)
            {
                StartCoroutine(s.SpawnVague(_nbBots / 2, s.transform.localPosition));
            }
            _counter = _maxCounter - _difficulty * 4;
            _difficulty++;
            WaveDisplayText.text = "Wave " + (_difficulty - 1).ToString();
            if (_nbBots < 50)
            {
                _nbBots += _difficulty / 2;
            }
            if(_difficulty % 3 == 0)
            {
                if(_speedMax < 15)
                    _speedMax++;
            }
            if (_difficulty % 5 == 0)
            {
                if (_speedMin < 9)
                    _speedMin++;
            }
            //Debug.Log(_difficulty + " s " + _speedMax + " sm " + _speedMin);
        }
	}

    public int GetSpeed()
    {
        return Random.Range(_speedMin, _speedMax);
    }

    public int GetDifficulty()
    {
        return Random.Range(_difficulty >= 3 ? _difficulty - 2 : 1, _difficulty);
    }

    public int GetRealDifficulty()
    {
        return _difficulty;
    }
}
