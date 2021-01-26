using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Data", menuName = "ScriptableObjects/EnemyAttackData", order = 1)]
public class EnemyAttackData : ScriptableObject
{
    public AttackType attackType =
        AttackType.Target;            //Tipo de ataque, determina el comportamiento de EnemyAttack.Attack()
    
    public float attackRange = 5f;   //Rango en el cual el enemigo se quedara quieto y empezara a ejecutar el ataque.
    public int damage = 10;          //Daño del ataque
    public float cooldown = 0.5f;    //Enfriamiento del ataque, contado a partir de que se termino de ejecutar el ataque.
    public float executeTime = 0.2f; //Tiempo que le toma realizar el ataque (para darle tiempo a una animacion)
}
/// <summary>
/// Tipos de ataques propuestos:
/// Target: una vez entra en rango, fija un objetivo y le hace daño sin importar que pase.
/// TargetRemainInRange: canaliza el ataque y solo le hace daño si se mantiene en rango.
/// MeleeArea: castea una zona en la que realiza daño. (instancia objeto)
/// Proyectile: castea un proyectil en direccion de su objetivo.
/// </summary>
public enum AttackType { Target, TargetRemainInRange, MeleeArea, Proyectile}

