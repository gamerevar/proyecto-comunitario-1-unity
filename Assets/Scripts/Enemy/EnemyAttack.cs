using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LayerMask onlyPlayerLayer;
    EnemyAttackData data;
    float cd;            //cooldown counter.
    bool cdReady;        //true when ready to attack.
    bool executeReady;   //true when able to move. (not executing an attack)
    PlayerHealth currentTarget;

    public Transform Pivot { get; private set; }

    private void Awake()
    {
        data = GetComponent<Enemy>().data.attackData;
        Pivot = GetComponentInChildren<EnemyPivot>().transform;
        cd = 0;
        cdReady = true;
        executeReady = true;
    }
    private void Update()
    {
        if(executeReady && Time.time > cd)
        {
            cdReady = true;
        }
    }
    public void Attack(PlayerHealth target)
    {        
        //Cooldown related
        executeReady = false;
        cdReady = false;

        currentTarget = target;
        Invoke(nameof(ReadyUpExecute), data.executeTime); //Execute the attack when windup ends
    }
    public bool MovementRestrained()
    {
        return !executeReady;
    }
    public bool AttackReady()
    {
        return cdReady;
    }
    void ReadyUpExecute()
    {
        cd = Time.time + data.cooldown;
        executeReady = true;
        data.ExecuteAttack(this, currentTarget); //Execute the attack
        //DeriveAttackBehaviour(); 
    }
    /*void DeriveAttackBehaviour() //Obsoleto
    {
        switch (data.attackType)
        {
            case AttackType.Target:
                currentTarget.Damage(data.damage);
                break;
            case AttackType.TargetRemainInRange:
                Debug.LogError("Not implemented yet");
                break;
            case AttackType.MeleeArea:
                Debug.LogError("Not implemented yet");
                break;
            case AttackType.Proyectile:
                Debug.LogError("Not implemented yet");
                break;
        }
    }*/
}
