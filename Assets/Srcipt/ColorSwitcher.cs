using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    private SpriteRenderer sr;

    public Color color1 = Color.green;
    public Color color2 = Color.red;

    public float switchTime = 3f;

    private float timer;
    private bool isColor1 = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = color1;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            timer = 0f;
            SwitchColor();
        }
    }

    void SwitchColor()
    {
        if (isColor1)
        {
            sr.color = color2;
        }
        else
        {
            sr.color = color1;
        }

        isColor1 = !isColor1;
    }
}
