using UnityEngine;

public class RedZoneController : MonoBehaviour
{
    public float countdown = 60f;
    public Vector3 minScale;

    private float initialTime;
    private Vector3 originalScale;

    void Start()
    {
        initialTime = countdown;
        originalScale = transform.localScale;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        float t = countdown / initialTime;
        transform.localScale = Vector3.Lerp(minScale, originalScale, t);
    }
}
