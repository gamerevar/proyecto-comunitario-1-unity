using UnityEngine;

/// <summary>
/// Tipo de ataque mas simple, al esperar el tiempo de ejecucion, le hace daño al jugador sin importar que.
/// </summary>
[CreateAssetMenu(fileName = "New Target Attack Data", menuName = "ScriptableObjects/EnemyAttackData/TargetAttackData", order = 1)]
public class TargetAttack : EnemyAttackData
{
    public override void ExecuteAttack(EnemyAttack caster, PlayerHealth playerHealth)
    {
        playerHealth.Damage(damage);
    }
}

