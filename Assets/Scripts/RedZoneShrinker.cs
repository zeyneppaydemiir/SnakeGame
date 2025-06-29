using UnityEngine;

public class RedZoneShrinker : MonoBehaviour
{
    public float shrinkRate = 0.2f;
    public float minSize = 2f;

    void Update()
    {
        if (transform.localScale.x > minSize && transform.localScale.y > minSize)
        {
            float shrinkAmount = shrinkRate * Time.deltaTime;
            transform.localScale -= new Vector3(shrinkAmount, shrinkAmount, 0);
        }
    }
}
