using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour, ITower
{
    public virtual void FindTarget()
    {
        throw new System.NotImplementedException();
    }

    public virtual void TryShoot()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseAttackSpeed(float value)
    {
        throw new System.NotImplementedException();
    }
}
