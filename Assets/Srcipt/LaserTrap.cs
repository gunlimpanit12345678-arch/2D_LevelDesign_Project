using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public float onTime = 2f;
    public float offTime = 2f;
    public float startDelay = 0f; // ดีเลย์ก่อนเริ่ม

    private float timer;
    private bool isOn = false;
    private bool started = false;

    private LineRenderer lr;
    private Collider2D col;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        col = GetComponent<Collider2D>();

        Invoke(nameof(StartLaser), startDelay);
    }

    void StartLaser()
    {
        started = true;
        SetLaser(true);
    }

    void Update()
    {
        if (!started) return;

        timer += Time.deltaTime;

        if (isOn && timer >= onTime)
        {
            SetLaser(false);
        }
        else if (!isOn && timer >= offTime)
        {
            SetLaser(true);
        }
    }

    void SetLaser(bool state)
    {
        isOn = state;
        timer = 0f;

        if (lr != null)
        {
            lr.enabled = true;

            if (state)
            {
                lr.startColor = Color.red;
                lr.endColor = Color.red;
            }
            else
            {
                lr.startColor = Color.gray;
                lr.endColor = Color.gray;
            }
        }

        if (col != null)
            col.enabled = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOn) return;

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Die();
        }
    }


}
