using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int Placement = 1;

    public int NbRoutes = 2;
    private Route[] _routes;
    private GameObject[] _bots;

	// Use this for initialization
	void Start ()
    {
        _bots = new GameObject[6];
        _bots[0] = Resources.Load("Prefabs/Bots/Aj") as GameObject;
        _bots[1] = Resources.Load("Prefabs/Bots/Big_Vegas") as GameObject;
        _bots[2] = Resources.Load("Prefabs/Bots/Claire") as GameObject;
        _bots[3] = Resources.Load("Prefabs/Bots/Kaya") as GameObject;
        _bots[4] = Resources.Load("Prefabs/Bots/Sporty_Granny") as GameObject;
        _bots[5] = Resources.Load("Prefabs/Bots/The_Boss") as GameObject;


        _routes = new Route[NbRoutes];
        switch (Placement)
        {
            case 1:
                _routes[0] = GameObject.Find("Route1").gameObject.GetComponent<Route>();
                _routes[1] = GameObject.Find("Route2").gameObject.GetComponent<Route>();
                break;
            case 2:
                _routes[0] = GameObject.Find("Route3").gameObject.GetComponent<Route>();
                break;
        }
	}

    public void SpawnBot(Vector3 pos)
    {
        GameObject bot = _bots[Random.Range(0, 5)];
        Instantiate(bot, pos, Quaternion.Euler(0, 0, 0));

    }

    public Route GetRoute()
    {
        return _routes[Random.Range(0, NbRoutes)];
    }

    public IEnumerator SpawnVague(int nbBots, Vector3 pos)
    {
        for(int i = 0; i < nbBots; i++)
        {
            SpawnBot(pos);
            yield return new WaitForSeconds(.5f);
        }
    }
}
