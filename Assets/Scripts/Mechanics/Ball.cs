using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private List<Collider2D> hitboxesProyectile;
    [SerializeField] private List<Collider2D> hitboxesMelee;
    private LayerMask hitLayers;
    private LayerMask hitLayersMelee;
    [SerializeField] private float radio = 0.3f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        rb.linearVelocity = new Vector3(3f,3f);
    }

    private void FixedUpdate()
    {
        CalculateProyectileHitbox();
        CalculateMeleeHitbox();
    }

    private void CalculateProyectileHitbox()
    {
        Vector2 origen = transform.position;
        hitLayers = LayerMask.GetMask("PlayerProyectile");
        if (Physics2D.OverlapCircle(origen, radio, hitLayers))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(origen, radio, hitLayers);
            foreach (Collider2D hitbox in hits)
            {
                if (!hitboxesProyectile.Contains(hitbox))
                {
                    hitboxesProyectile.Add(hitbox);
                }
            }
            if (hitboxesProyectile.Count == 0) return;
            Collider2D mayor = hitboxesProyectile[0];
            float menordistancia = Mathf.Abs(mayor.transform.position.x - origen.x);
            foreach (Collider2D hitbox in hitboxesProyectile)
            {
                if (hitbox == mayor) { continue; }
                else
                {
                    if (Mathf.Abs(hitbox.transform.position.x - origen.x) < menordistancia)
                    {
                        menordistancia = Mathf.Abs(hitbox.transform.position.x - origen.x);
                        mayor = hitbox;
                    }
                }
            }
            Bullet ap = mayor.GetComponent<Bullet>();

            if (ap == null)
            {
                ap = mayor.GetComponentInParent<Bullet>();
            }

            if (ap != null)
            {
                ap.Choque(mayor, rb);
            }
            foreach (Collider2D hitbox in hitboxesProyectile)
            {
                Destroy(hitbox.gameObject);
            }
            hitboxesProyectile.Clear();

        }
    }

    private void CalculateMeleeHitbox()
    {
        Vector2 origen = transform.position;
        hitLayersMelee = LayerMask.GetMask("PlayerMelee");
        if (Physics2D.OverlapCircle(origen, radio, hitLayersMelee))
        {
            Debug.Log("pesco xd");
            Collider2D[] hitsMelee = Physics2D.OverlapCircleAll(origen, radio, hitLayersMelee);
            foreach (Collider2D hitbox in hitsMelee)
            {
                if (!hitboxesMelee.Contains(hitbox))
                {
                    hitboxesMelee.Add(hitbox);
                }
            }
            if (hitboxesMelee.Count == 0) return;
            Collider2D mayorM = hitboxesMelee[0];
            float menordistancia = Mathf.Abs(mayorM.transform.position.x - origen.x);
            foreach (Collider2D hitbox in hitboxesMelee)
            {
                if (hitbox == mayorM) { continue; }
                else
                {
                    if (Mathf.Abs(hitbox.transform.position.x - origen.x) < menordistancia)
                    {
                        menordistancia = Mathf.Abs(hitbox.transform.position.x - origen.x);
                        mayorM = hitbox;
                    }
                }
            }
            Melee ap = mayorM.GetComponent<Melee>();

            if (ap == null)
            {
                ap = mayorM.GetComponentInParent<Melee>();
            }

            if (ap != null)
            {
                ap.ChoqueMelee(mayorM, rb);
            }
            hitboxesMelee.Clear();

        }
    }
}
