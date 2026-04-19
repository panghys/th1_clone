using UnityEngine;

public class damageHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            GameManager.instance.playerHit(-1);
        }
    }
}
