using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public static GameManager Instance;

    public bool isGamePaused = false; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;


        Time.timeScale = isGamePaused ? 0f : 1f;
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Can azaldı. Kalan: " + lives);

        if (lives <= 0)
        {
            Time.timeScale = 1f; 
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainScene");
        }
    }

    public void RestartGame()
    {
        lives = 3;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}
