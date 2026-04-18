using UnityEngine;

public class ColorDamageBlock : MonoBehaviour
{
    private SpriteRenderer sr;

    public Color dangerColor = Color.red;
    public Color safeColor = Color.green;

    public float switchTime = 3f;

    private float timer;
    private bool isDanger = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetColor(true); // เริ่มเป็นอันตราย
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            timer = 0f;
            SetColor(!isDanger);
        }
    }

    void SetColor(bool danger)
    {
        isDanger = danger;

        if (isDanger)
        {
            sr.color = dangerColor;
        }
        else
        {
            sr.color = safeColor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDanger) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDanger) return;

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Die();
        }
    }
}
