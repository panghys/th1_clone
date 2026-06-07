using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject exit;
    private bool touched = false;
    [SerializeField] private float freezeTime = 2f;
    private GameObject ball;
    void Update()
    {
        if (touched)
        {
            freezeTime -= Time.deltaTime;
            ball.transform.position = transform.position;
            if(freezeTime <= 0)
            {
                ball.transform.position = exit.transform.position;
                freezeTime = 2f;
                touched = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("funciono el collision");
            ball = collision.gameObject;
            touched = true;
        }
        
    }
}
