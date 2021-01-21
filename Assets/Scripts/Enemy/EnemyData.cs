using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int maxHealth = 100;
    public float movementSpeed = 5f;
    public float attackRange = 5f;
    public float aggroRange = 5;
}
