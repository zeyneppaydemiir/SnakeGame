using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    public SnakeMovement snakeMovement;
    public FoodSpawner foodSpawner;
    public int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("food"))
        {
            Destroy(collision.gameObject); 
            snakeMovement.AddBodyPart();   
            score += 10;                   
            foodSpawner.SpawnFood();       
        }
    }
}
