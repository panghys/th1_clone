using UnityEngine;
using PrimeTween;
public class Pattern : MonoBehaviour
{
    void Awake()
    {
        Vector2 playerPos = Player.Instance.transform.position;
        Tween.Position(transform,new Vector2(playerPos.x,-8f),8).OnComplete(() => Destroy(gameObject));
    }
}
