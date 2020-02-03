using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Config/Create EnemysData")]
public class EnemysData : ScriptableObject
{
    public List<Enemys> enemys;
    
}

[System.Serializable]
public class Enemys
{
    public GameObject enemy;
}