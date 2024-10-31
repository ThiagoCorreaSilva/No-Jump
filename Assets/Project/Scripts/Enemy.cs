using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : LifeController
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float iATime;
    [SerializeField] private float distanceToFollow;
    [SerializeField] private Transform playerPos;
    private bool canMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {
        base.Start();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb.freezeRotation = true;

        InvokeRepeating(nameof(IA), 1, iATime);
    }

    private void FixedUpdate()
    {
        if (canMove) transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.position.x, transform.position.y), speed);
    }

    private void IA()
    {
        if (playerPos.position.x - transform.position.x <= distanceToFollow)
        {
            canMove = true;
        }
        else
            canMove = false;
    }

    private float DistanceToPlayer()
    {
        return Vector2.Distance(transform.position, playerPos.position);
    }
}