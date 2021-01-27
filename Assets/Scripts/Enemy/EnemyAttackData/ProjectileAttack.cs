using UnityEngine;

/// <summary>
/// Instancia un objeto, con un script de <see cref="Projectile"/>
/// El objeto debe estar en la layer EnemyBullet.
/// Importante: la variable damage no se usa.
/// </summary>
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

