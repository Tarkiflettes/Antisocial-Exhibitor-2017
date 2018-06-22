using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

	private GameObject _target;

    private int _damage;

    public void SetDamage(int i)
    {
        _damage = i;
    }

	// Update is called once per frame
	void Update ()
	{
		if (_target != null) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (_target.transform.position - transform.position), 100 * Time.deltaTime);
			transform.position += transform.forward * 10 * Time.deltaTime;
		} else
			Destroy (gameObject);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Bot") {
            if(_target != null)
                _target.GetComponent<Bot>().Life -= _damage;
            Destroy (gameObject);
		}
	}

	public GameObject Target {
		set {
			_target = value;
		}
		get {
			return _target;
		}
	}

    public void SetScale(float i)
    {
        transform.localScale = new Vector3(i, i, i);
    }
}
