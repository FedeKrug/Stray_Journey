using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttacks : MonoBehaviour
{
    [Header("Parameters: ")]
    [SerializeField] private float superInUse;
    [SerializeField] private float superUsed;
    [SerializeField] private bool isSuper;
    [Header("References: ")]
    [SerializeField] private BulletGenerator pointOfShooting;
    [SerializeField] private List<GameObject> specialBullets; //0 = dispersion, 1 = explosion, 2 = Special Ray
    [SerializeField] private List<GameObject> superObject; //0 = dispersion, 1 = explosion, 2 = Special Ray

    void Awake()
    {
        
    }

   
    void Update()
    {
        
    }
}
