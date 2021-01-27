using UnityEngine;

[CreateAssetMenu(fileName = "New Target Attack Data", menuName = "ScriptableObjects/EnemyAttackData/TargetAttackData", order = 1)]
public class TargetAttack : EnemyAttackData
{
    public override void ExecuteAttack(EnemyAttack caster, PlayerHealth playerHealth)
    {
        playerHealth.Damage(damage);
    }
}

