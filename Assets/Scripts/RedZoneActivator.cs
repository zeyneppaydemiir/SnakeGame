using UnityEngine;

public class RedZoneActivator : MonoBehaviour
{
    private Collider2D redZoneCollider;

    void Start()
    {
        redZoneCollider = GetComponent<Collider2D>();
        redZoneCollider.enabled = false;
        Invoke("ActivateCollider", 1.5f); 
    }

    void ActivateCollider()
    {
        redZoneCollider.enabled = true;
    }
}
