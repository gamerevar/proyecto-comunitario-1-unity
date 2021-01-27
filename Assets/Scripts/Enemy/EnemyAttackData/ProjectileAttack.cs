using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Attack Data", menuName = "ScriptableObjects/EnemyAttackData/NewProjectileAttackData", order = 1)]
public class ProjectileAttack : EnemyAttackData
{
    public GameObject projectile;
    //damage no se usa. (pasarlo al proyectil?) TODO ver.

    public override void ExecuteAttack(EnemyAttack caster, PlayerHealth playerHealth)
    {
        Instantiate(projectile, caster.Pivot.position, caster.Pivot.rotation);
    }
}

