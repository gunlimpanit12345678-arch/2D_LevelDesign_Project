using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;
    public GameObject pauseUI;

    private bool isPaused = false;

    void Start()
    {
        if (winUI != null) winUI.SetActive(false);
        if (pauseUI != null) pauseUI.SetActive(false);
    }

    void Update()
    {
        // กด ESC เพื่อหยุด/เล่นต่อ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void WinGame()
    {
        if (winUI != null)
            winUI.SetActive(true);

        Time.timeScale = 0f; // หยุดเกม
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    public void PauseGame()
    {
        isPaused = true;
        if (pauseUI != null) pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        if (pauseUI != null) pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
