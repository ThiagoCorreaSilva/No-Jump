using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [Header("Life Controller")]
    [SerializeField] protected float currentLife;
    [SerializeField] protected float maxLife;
    protected bool isDeath;

    protected virtual void Start()
    {
        currentLife = maxLife;
    }

    public virtual void TakeDamage(float _dmg)
    {
        currentLife = Mathf.Max(currentLife - _dmg, 0f);

        if (currentLife == 0f) Death();
    }

    protected virtual void Death()
    {
        isDeath = true;
    }
}
