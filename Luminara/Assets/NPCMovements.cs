using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public enum CHARACTER_STATE
{
    IDLE,
    MOVE, // when moving, change animation
    DETECT, // when detecting, change animation
    ATTACK // when attacking, change animation

}

public class NPCMovements : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveRange = 5f;
    private Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(RandomMove());
    }

    private IEnumerator RandomMove()
    {
        while (true)
        {
            targetPosition = new Vector3(Random.Range(-moveRange, moveRange), transform.position.y, Random.Range(-moveRange, moveRange));
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

}