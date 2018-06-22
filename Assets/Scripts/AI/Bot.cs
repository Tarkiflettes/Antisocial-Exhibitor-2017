using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    
	public float Speed = 3;
    public List<AttackTower> Towers;

	private bool _isAlive = true;
	public int _life = 50;
	private Route _route;
	private int _currentPoint;
	private int _nbPoint;
	private GameObject _currentPathPoint;
	private Transform _modelTransform;
    private WaveManager _waveManager;
    private Animator _anim;
	private int _dirX;
	private int _dirZ;
    private int _difficulty;


    // Use this for initialization
    private void Start()
	{
        _dirX = 0;
        _dirZ = 0;
        _currentPoint = 0;
        _modelTransform = transform.Find("Model");
        _currentPathPoint = gameObject;

        _anim = GetComponent<Animator>();

        _waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        Speed = _waveManager.GetSpeed();
        if(Speed >= 6)
        {
            _anim.SetBool("isRunning", true);
        }
        _difficulty = _waveManager.GetDifficulty();
        _life += _difficulty * 15;

        _modelTransform.localScale = new Vector3(((float) _difficulty) / 20 + 1, ((float) _difficulty) / 20 + 1, ((float) _difficulty) / 20 + 1);
        //_modelTransform.localScale *= 1.5f;
        foreach(GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            if (spawner.transform.position == transform.position)
            {
                _route = spawner.GetComponent<Spawner>().GetRoute();
                break;
            }
        }
        _nbPoint = _route.GetNbPoints();

        GoToPoint(_route.GetPathPoint(_currentPoint));
	}
    
    public int GetDiff()
    {
        return _difficulty;
    }

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (_dirX * Time.deltaTime * Speed, 0, _dirZ * Time.deltaTime * Speed);
    }


	private void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PathPoint") {
			StartCoroutine (GoWithDelay (0));
		} else if (other.gameObject.tag == "BasePoint") {
			_isAlive = false;
            GameObject.Find("Player").GetComponent<Player>().VisitorEnterInOurSpace();
			Destroy (gameObject);
		} else if (other.gameObject.tag == "Case")
        {
            Destroy(gameObject);
        }
	}

	IEnumerator GoWithDelay (float delay)
	{
		yield return new WaitForSeconds (delay);
		_currentPoint++;
		GoToPoint (_route.GetPathPoint (_currentPoint));
	}

	void GoToPoint (GameObject pathPoint)
	{
		if (_currentPathPoint.transform.position.x > pathPoint.transform.position.x)
			_dirX = -1;
		else if (_currentPathPoint.transform.position.x < pathPoint.transform.position.x)
			_dirX = 1;
		else
			_dirX = 0;

		if (_currentPathPoint.transform.position.z > pathPoint.transform.position.z)
			_dirZ = -1;
		else if (_currentPathPoint.transform.position.z < pathPoint.transform.position.z)
			_dirZ = 1;
		else
			_dirZ = 0;

		switch (_dirX) {
		case -1:
			switch (_dirZ) {
			case -1:
				_modelTransform.rotation = Quaternion.Euler (0, 225, 0);
				break;
			case 1:
				_modelTransform.rotation = Quaternion.Euler (0, 315, 0);
				break;
			case 0:
				_modelTransform.rotation = Quaternion.Euler (0, 270, 0);
				break;
			}
			break;
		case 1:
			switch (_dirZ) {
			case -1:
				_modelTransform.rotation = Quaternion.Euler (0, 135, 0);
				break;
			case 1:
				_modelTransform.rotation = Quaternion.Euler (0, 45, 0);
				break;
			case 0:
				_modelTransform.rotation = Quaternion.Euler (0, 90, 0);
				break;
			}
			break;
		case 0:
			switch (_dirZ) {
			case -1:
				_modelTransform.rotation = Quaternion.Euler (0, 180, 0);
				break;
			case 1:
				_modelTransform.rotation = Quaternion.Euler (0, 0, 0);
				break;
			}
			break;
		}
		_currentPathPoint = pathPoint;
	}

	public void Die ()
	{
		_isAlive = false;
        foreach(AttackTower t in Towers)
        {
            t.HeyImDead();
        }
		Destroy (gameObject);
	}

    public void AddTower(AttackTower tower)
    {
        Towers.Add(tower);
    }

	public bool IsDead {
		set { 
			_isAlive = value;
		}
		get {
			return _isAlive;
		}
	}

	public int Life {
		set { 
			_life = value;
		}
		get {
			return _life;
		}
	}
}

