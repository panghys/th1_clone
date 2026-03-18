using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float cooldown = 0.4f;
    [SerializeField] public bool canBeShot = true;
    private bool wasShot = false;

    public void ShootBullet()
    {
        if (canBeShot)
        {
            Instantiate(bullet,transform.position,transform.rotation);
            canBeShot = false;
            wasShot = true;
        }
    }
    void Update()
    {
        if (wasShot)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                canBeShot = true;
                cooldown = 0.15f;
                wasShot = false;
            }
            
        }
    }

}
