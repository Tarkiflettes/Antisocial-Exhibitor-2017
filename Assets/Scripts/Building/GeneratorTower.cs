using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTower : Defense
{

	private int _generatePerTime;
	private float _generateTimer;
    private int _timeMax = 2;
	private Player _player;


	// Use this for initialization
	void Start ()
	{
		Level = 1;
		Cost = 50;
		LevelUpCost = 100;
		_generateTimer = _timeMax;
		_generatePerTime = 10;
		_player = (Player)GameObject.FindGameObjectWithTag ("MainCamera").GetComponent ("Player");


	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_generateTimer > 0)
			_generateTimer -= Time.deltaTime;

		if (_generateTimer < 0)
			_generateTimer = 0;

		if (_generateTimer == 0) {
			generate ();
			_generateTimer = _timeMax;
		}
	}

	private void generate ()
	{
		_player.Coin += _generatePerTime;
	}

    public override void LevelUpDefense()
    {
        _generatePerTime += 7 * Level;
        if (Level <= 5)
            transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
        base.LevelUpDefense();
    }


}
