using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{

    public int Level;
    public int Cost;
    public int LevelUpCost;

    public Sprite Sprite;

    // Use this for initialization
    void Start()
    {
        Level = 1;
        Cost = 100;
        LevelUpCost = 100;
    }

    public virtual void LevelUpDefense()
    {
        LevelUpCost += 300 * Level;
        Level += 1;
    }

}
