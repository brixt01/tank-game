using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10;
    private Rigidbody2D rb;

    public void Setup(Vector3 shootDirection) {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);

        Destroy(gameObject, 5f);
    }
}
