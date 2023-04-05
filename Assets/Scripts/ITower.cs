using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    public void FindTarget();
    public void TryShoot();
    public void Shoot();
    public void IncreaseAttackSpeed(float value);
}
