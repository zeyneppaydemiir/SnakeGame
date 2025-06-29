using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene("Game");
    }
}