using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{
    public FoodSpawner foodSpawner;
    private bool hasEaten = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (GameManager.Instance != null && GameManager.Instance.isGamePaused)
        {
            return;
        }

        Debug.Log("Çarpışan: " + other.name + " | Tag: " + other.tag);

        
        if (other.CompareTag("Food") && !hasEaten)
        {
            hasEaten = true;
            Debug.Log("Yiyecek yendi!");
            Destroy(other.transform.root.gameObject);
            ScoreManager.Instance.IncreaseScore();

            SnakeBodyManager bodyManager = FindObjectOfType<SnakeBodyManager>();
            if (bodyManager != null)
            {
                bodyManager.AddBodyPart();
            }

            StartCoroutine(SpawnFoodAfterDelay());
        }

        
        else if (other.CompareTag("RedZone") && !hasEaten)
        {
            Debug.Log("RedZone'a çarpıldı!");
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator SpawnFoodAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        foodSpawner.SpawnFood();
        hasEaten = false;
    }
}
