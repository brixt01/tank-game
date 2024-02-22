using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private GameObject playerTurret;
    [SerializeField] private GameObject gunEndPoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float directionChangeSpeed = 15f;

    void Awake() {
        gameInput.OnFireAction += Fire;
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate() {
        HandleMovement();
    }

    void Update() {
        HandleRotation();
    }

    void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovement();
        rb.velocity = new Vector3(inputVector.x*movementSpeed, inputVector.y*movementSpeed, 0f);
    }

    void HandleRotation() {
        Vector2 inputVector = gameInput.GetMovement();
        Vector3 movementVector = new Vector3(inputVector.x, inputVector.y, 0f);
        if (movementVector != Vector3.zero) {
            transform.up = Vector3.Slerp(transform.up, movementVector, directionChangeSpeed * Time.deltaTime);
        }
    }

    void Fire(object sender, System.EventArgs e) {
        GameObject bullet = Instantiate(bulletPrefab, gunEndPoint.transform.position, playerTurret.transform.rotation);
        Vector3 shootDirection = (gunEndPoint.transform.position - new Vector3(transform.position.x, gunEndPoint.transform.position.y, transform.position.z)).normalized;
        bullet.GetComponent<Shell>().Setup(shootDirection);
    }
}