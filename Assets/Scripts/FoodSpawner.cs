using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public Collider2D redZone;

    private GameObject currentFood;

    public void SpawnFood()
    {

        if (currentFood != null)
            Destroy(currentFood);


        Bounds bounds = redZone.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x + 1f, bounds.max.x - 1f));
        float y = Mathf.Round(Random.Range(bounds.min.y + 1f, bounds.max.y - 1f));
        Vector2 spawnPos = new Vector2(x, y);


        currentFood = Instantiate(foodPrefab, spawnPos, Quaternion.identity);
        currentFood.tag = "Food"; 

        Debug.Log("Yeni yiyecek doğdu: " + currentFood.name + " | Tag: " + currentFood.tag);
    }

    private void Start()
    {
        SpawnFood();
    }
}
