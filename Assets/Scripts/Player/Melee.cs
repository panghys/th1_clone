using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private CircleCollider2D leftBox;
    [SerializeField] private CircleCollider2D rightBox;
    [SerializeField] private CircleCollider2D middleBox;

    public void ChoqueMelee(Collider2D hit, Rigidbody2D rb)
    {
        if(hit == leftBox)
        {
            rb.linearVelocity = new Vector2(-10f,10f);
        }
        else if(hit == rightBox)
        {
            rb.linearVelocity = new Vector2(0,10f);
        }
        else
        {
            rb.linearVelocity = new Vector2(10f,10f);
        }
        gameObject.SetActive(false);
    }
}
