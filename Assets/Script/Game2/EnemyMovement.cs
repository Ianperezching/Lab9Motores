using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] pivotPoints;
    [SerializeField] private Rigidbody rb;

    private int currentPivotIndex = 0;
    private float speed = 5f;
    private float pivotSwitchThreshold = 1f;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (pivotPoints.Length == 0) return;

        Transform targetPivot = pivotPoints[currentPivotIndex];
        Vector3 direction = (targetPivot.position - transform.position).normalized;

        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPivot.position) < pivotSwitchThreshold)
        {
            UpdatePivot();
        }
    }

    private void UpdatePivot()
    {
        currentPivotIndex++;
        if (currentPivotIndex >= pivotPoints.Length)
        {
            currentPivotIndex = 0;
        }
    }
}
