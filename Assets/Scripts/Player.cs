using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] 序列化
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking = false;
    private void Start() {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        HandleInteraction();
    }

    private void Update()
    {        
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public bool IsWalking
    {
        get
        {
            return isWalking;
        }
    }

    private void HandleMovement()
    {
        Vector3 direction = gameInput.GetMovementDirectionNormalized();

        isWalking = direction != Vector3.zero;

        transform.position += direction * Time.deltaTime * moveSpeed;

        // 设置player朝向移动方向,插值平滑
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
    }
    private void HandleInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2.0f, counterLayerMask))
        {
            if (hitinfo.transform.TryGetComponent<ClearCounter>(out ClearCounter counter))
            {
                counter.Interact();
            }
        }

    }
}
