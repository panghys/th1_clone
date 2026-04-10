using UnityEngine;

public class Plank : MonoBehaviour
{
    public bool wasActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            wasActivated = true;
            var sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = Color.red;
            Debug.Log("pego");
        }
    }
}
