﻿using Luminara.SoundManager;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SkeletonAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator skeletonAnimator;

    [Header("Settings")]
    public float speed = 2f;
    public float patrolRange = 3f;
    public float detectionRange = 5f;

    private Transform playerTransform;
    private GameObject player;
    private bool isAttacking = false;
    private bool isPlayerInRange = false;

    private Vector2 startPosition;
    private Vector2 targetPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player?.transform;

        if (skeletonAnimator == null)
            Debug.LogWarning("Animator not assigned on " + gameObject.name);

        startPosition = transform.position;
        targetPosition = startPosition + Vector2.right * patrolRange;
    }

    void Update()
    {
        if (playerTransform == null || isAttacking)
            return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        isPlayerInRange = distanceToPlayer <= detectionRange;

        Patrol();

    }

    void Patrol()
    {
        skeletonAnimator.SetBool("IsWalking", true);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == (startPosition + Vector2.right * patrolRange)
                ? startPosition + Vector2.left * patrolRange
                : startPosition + Vector2.right * patrolRange;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isAttacking)
        {
            isAttacking = true;
            skeletonAnimator.SetTrigger("Attack");
            StartCoroutine(HandleAttackSequence());
            SoundManager.PlaySound(SoundType.Skeleton);
        }
    }

    IEnumerator HandleAttackSequence()
    {
        yield return new WaitForSeconds(1f);

        if (player != null)
        {
            Destroy(player);
            ShowGameOverScreen();
        }

    }

    private void ShowGameOverScreen()
    {
        GameOverManager gameOverManager = FindAnyObjectByType<GameOverManager>();

        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOverScreen();
        }
        else
        {
            Debug.LogError("GameOverManager not found!");
        }
    }
}
