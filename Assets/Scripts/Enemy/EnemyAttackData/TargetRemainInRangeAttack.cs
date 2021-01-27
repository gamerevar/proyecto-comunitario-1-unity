using UnityEngine;

[CreateAssetMenu(fileName = "New Target Remain In Range Attack Data", menuName = "ScriptableObjects/EnemyAttackData/TargetRemainInRangeAttackData", order = 1)]
public class TargetRemainInRangeAttack : EnemyAttackData
{
    public float maximumRange = 7f;

    public override void ExecuteAttack(EnemyAttack caster, PlayerHealth playerHealth)
    {
        if(Vector2.Distance(caster.transform.position,playerHealth.transform.position) <= maximumRange)
        {
            playerHealth.Damage(damage);
        }
        else
        {
            Debug.Log("el jugador se le fue de rango a " + caster.name);
        }
    }
}

