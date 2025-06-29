using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 direction = Vector2.right;

    public GameObject bodyPartPrefab;
    public List<Transform> bodyParts = new List<Transform>();
    public float bodySpacing = 0.5f;

    private List<Vector3> positions = new List<Vector3>();
    private bool isMoving = true;

    void Start()
    {
       
        positions.Add(transform.position);

        
        AddBodyPart();
        AddBodyPart();
        AddBodyPart();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
            isMoving = !isMoving;

        if (!isMoving) return;

        
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector2.down)
            direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector2.up)
            direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector2.right)
            direction = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector2.left)
            direction = Vector2.right;
    }

    void FixedUpdate()
    {
        if (!isMoving) return;

        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);

        
        float distanceMoved = Vector3.Distance(transform.position, positions[0]);
        if (distanceMoved > bodySpacing)
        {
            positions.Insert(0, transform.position);
            positions.RemoveAt(positions.Count - 1);
        }

        
        for (int i = 0; i < bodyParts.Count; i++)
        {
            bodyParts[i].position = Vector3.Lerp(bodyParts[i].position, positions[i + 1], 0.5f);
        }
    }

    public void AddBodyPart()
    {
        GameObject newPart = Instantiate(bodyPartPrefab, positions[positions.Count - 1], Quaternion.identity);
        bodyParts.Add(newPart.transform);
        positions.Add(newPart.transform.position);
    }
}
