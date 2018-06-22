using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Defense
{
	private GameObject _target;
	private GameObject _targetToProjectile;
	private GameObject _projectile;
	private bool _targetOk;
	private int _damage;
	private bool _frostTower;
	private float _attackTimer;
	private Player _player;

	// Use this for initialization
	void Start ()
	{
		Level = 1;
		Cost = 100;
		LevelUpCost = 100;
		_attackTimer = 0;
		_damage = 10;
		_frostTower = false;
		_targetOk = false;
		_player = (Player)GameObject.FindGameObjectWithTag ("MainCamera").GetComponent ("Player");
		_projectile = Resources.Load ("Prefabs/Projectile") as GameObject;
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (_target != null) {
			//transform.Rotate (Vector3.up * 10);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (_target.transform.position - transform.position), 10 * Time.deltaTime);
			if (_attackTimer > 0)
				_attackTimer -= Time.deltaTime;

			if (_attackTimer < 0)
				_attackTimer = 0;

			if (_attackTimer == 0) {
				Attack ();
				_attackTimer = 0.75f;
			}
		} else
        {
            _targetOk = false;
        }
	}


    public override void LevelUpDefense()
    {
        _damage += (8 * Level);
        if(Level <= 5)
            transform.localScale += new Vector3(0.1f,0.1f,0.1f);
        base.LevelUpDefense();
    }

    private void Attack ()
	{
		Vector3 MyPos = transform.position;
		//_target.GetComponent<Bot> ().Life -= _damage;

		_targetToProjectile = Instantiate (_projectile, MyPos, Quaternion.Euler (0, 0, 0));
        ProjectileMove projM= _targetToProjectile.GetComponent<ProjectileMove>();

        projM.SetScale(transform.localScale.x + 0.5f);
        projM.Target = _target;
        projM.SetDamage(_damage);

        if (_target.GetComponent<Bot> ().Life <= 0)
        {
            _player.Coin += _target.GetComponent<Bot>().GetDiff() * Random.Range(10, 13) + 30;
            _target.GetComponent<Bot> ().Die();
            _target = null;
            _targetOk = false;
		}
	}

	//void OnTriggerEnter (Collider coll)
	//{
	//	if (!_targetOk) {
	//		_targetOk = true;
	//		_target = coll.gameObject;
	//	}
	//}

	void OnTriggerStay (Collider coll)
	{
		if (!_targetOk) {
			_targetOk = true;
			_target = coll.gameObject;
            _target.GetComponent<Bot>().AddTower(this);
		}
	}

	void OnTriggerExit (Collider other)
	{
		_targetOk = false;
		_target = null;
	}

    public void HeyImDead()
    {
        _targetOk = false;
        _target = null;
    }

    public int Damage
    {
        set
        {
            _damage = value;
        }
        get
        {
            return _damage;
        }
    }

}
