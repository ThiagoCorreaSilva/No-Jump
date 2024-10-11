using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LifeController
{
    private Animator anim;

    [Header("Movement")]
    [SerializeField] private float speed;
    private bool facingLeft;
    private bool canMove;
    private Vector2 dir;
    private Rigidbody2D rb;

    [Header("Combat")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPos;
    [SerializeField] private float attackRate;
    [SerializeField] private float attackRange;
    private float nextAttack;
    public float attackDamage;

    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        canMove = true;
    }

    private void Update()
    {
        PlayerInputs();

        if (dir.x > 0 && !facingLeft && canMove || dir.x < 0 && facingLeft && canMove) Flip();

        if (dir.x > 0 || dir.x < 0) anim.SetFloat("Velocity_X", 1);
        else anim.SetFloat("Velocity_X", 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInputs()
    {
        if (isDeath || !canMove) return;

        dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

        if (Input.GetButtonDown("Fire1") && Time.time >= nextAttack) anim.SetTrigger("Attack");
    }

    private void Move()
    {
        rb.velocity = dir * speed;
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(Vector3.up * 180);
    }

    public void Attack()
    {
        canMove = false;
        dir.x = 0f;

        nextAttack = Time.time + 1f / attackRange;

        var _enemys = Physics2D.OverlapCircleAll(

            attackPos.position,
            attackRange,
            enemyLayer
            );

        if (_enemys != null)
            foreach (var _enemy in _enemys)
            {
                _enemy.GetComponent<LifeController>().TakeDamage(attackDamage);
                Debug.Log($"O inimigo {_enemy.name} levou dano");
            }

        Invoke(nameof(ReturnToMove), 0.2f);
    }

    private void ReturnToMove()
    {
        canMove = true;
    }
}