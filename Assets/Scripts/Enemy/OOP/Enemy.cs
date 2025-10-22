using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float health = 100f;
    public Transform player;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
}