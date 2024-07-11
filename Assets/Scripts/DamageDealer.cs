using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] bool HasExplosion = true;

    public int GetDemage(){
        return damage;
    }
    public bool GetHasExplosion(){
        return HasExplosion;
    }

    public void Hit(){
        Destroy(gameObject);
    }
}
