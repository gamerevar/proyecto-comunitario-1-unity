using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable Object base que derivan los distintos tipos de ataques
/// <para>
/// Tipos de ataques propuestos:
/// Target: una vez entra en rango, fija un objetivo y le hace daño sin importar que pase.
/// TargetRemainInRange: canaliza el ataque y solo le hace daño si se mantiene en rango.
/// MeleeArea: castea una zona en la que realiza daño. (Overlap Box)
/// Proyectile: castea un proyectil en direccion de su objetivo.</para>
/// </summary>
public class EnemyAttackData : ScriptableObject
{
    public float attackRange = 5f;   //Rango en el cual el enemigo se quedara quieto y empezara a ejecutar el ataque.
    public int damage = 10;          //Daño del ataque
    public float cooldown = 0.5f;    //Enfriamiento del ataque, contado a partir de que se termino de ejecutar el ataque.
    public float executeTime = 0.2f; //Tiempo que le toma realizar el ataque (para darle tiempo a una animacion)

    public virtual void ExecuteAttack(EnemyAttack caster, PlayerHealth playerHealth)
    {
        //Para ser reemplazado en clases derivadas
    }
    //Cosas pendientes: implementar hooks para animaciones, instanciar objetos y tal
}