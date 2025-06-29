using UnityEngine;
using System.Collections.Generic;

public class SnakeBodyManager : MonoBehaviour
{
    public GameObject snakeHead;      
    public GameObject bodyPrefab;     
    public float followSpeed = 10f;   
    public float followDistance = 0.1f;  
    private List<Transform> bodyParts = new List<Transform>();

    void Update()
    {
        Vector3 previousPos = snakeHead.transform.position;
        Quaternion previousRot = snakeHead.transform.rotation;

        for (int i = 0; i < bodyParts.Count; i++)
        {
            Transform part = bodyParts[i];

            
            Vector3 targetPos = previousPos - previousRot * Vector3.up * followDistance;

           
            part.position = Vector3.Lerp(part.position, targetPos, followSpeed * Time.deltaTime);

            
            part.rotation = Quaternion.Lerp(part.rotation, previousRot, followSpeed * Time.deltaTime);

            previousPos = part.position;
            previousRot = part.rotation;
        }
    }

    public void AddBodyPart()
    {
        Vector3 spawnPos;

        if (bodyParts.Count == 0)
            spawnPos = snakeHead.transform.position - snakeHead.transform.up * followDistance;
        else
            spawnPos = bodyParts[bodyParts.Count - 1].position - bodyParts[bodyParts.Count - 1].up * followDistance;

        GameObject newPart = Instantiate(bodyPrefab, spawnPos, snakeHead.transform.rotation);
        bodyParts.Add(newPart.transform);
    }
}
