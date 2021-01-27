using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Area Attack Data", menuName = "ScriptableObjects/EnemyAttackData/MeleeAreaAttackData", order = 1)]
public class MeleeAreaAttack : EnemyAttackData
{
    public Vector2 attackSize = new Vector2(2,1);

    public override void ExecuteAttack(EnemyAttack caster, PlayerHealth playerHealth)
    {
        //Not working
        Collider2D hits = Physics2D.OverlapBox(caster.Pivot.position,
            attackSize, caster.Pivot.rotation.eulerAngles.z, caster.onlyPlayerLayer);
        if(hits != null)
        {
            hits.GetComponent<PlayerHealth>().Damage(damage);
        }
    }
}

