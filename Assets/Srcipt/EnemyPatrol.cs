using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;

    public Transform pointA; // จุดซ้าย
    public Transform pointB; // จุดขวา

    private Transform target;
    private bool facingRight = true;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // เดินไปยังเป้าหมาย
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // ถ้าถึงเป้าหมายแล้ว
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            if (target == pointA)
            {
                target = pointB;
                Flip();
            }
            else
            {
                target = pointA;
                Flip();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
