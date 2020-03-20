using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public float velocity = 10f;
    public Vector3 direction = Vector3.forward;

    void Die()
    {
        Destroy(this.gameObject);
    }
    void Move()
    {
        transform.Translate(direction * velocity * Time.deltaTime * 2);
    }

    void Update()
    {
        Move();
    }
}