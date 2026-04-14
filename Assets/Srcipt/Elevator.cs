using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;
    public float activationDistance = 2f;

    public GameObject pressE_UI; // UI "Press E"

    private Transform target;
    private bool isMoving = false;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = pointB;

        if (pressE_UI != null)
            pressE_UI.SetActive(false);
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // แสดง UI เมื่อเข้าใกล้
        if (distance <= activationDistance && !isMoving)
        {
            if (pressE_UI != null)
                pressE_UI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                target = (Vector2.Distance(transform.position, pointA.position) < 0.1f) ? pointB : pointA;
                isMoving = true;

                if (pressE_UI != null)
                    pressE_UI.SetActive(false);
            }
        }
        else
        {
            if (pressE_UI != null)
                pressE_UI.SetActive(false);
        }

        // เคลื่อนที่
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target.position) < 0.05f)
            {
                isMoving = false;
            }
        }
    }

    // ให้ Player ติดไปกับลิฟต์
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
