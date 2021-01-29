using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable Objecto con la informacion sobre un de enemigo.
/// </summary>
[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int maxHealth = 100;
    public float movementSpeed = 5f;
    public float aggroRange = 5;
    public EnemyAttackData attackData; //Por ahora solo existe la posibilidad de un ataque.
}
