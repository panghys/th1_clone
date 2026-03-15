using Unity.VisualScripting;
using UnityEngine;
using PrimeTween;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.linearVelocity = new Vector2(0,15);
        Tween.Delay(0.7f,() => {Destroy(gameObject);});
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
