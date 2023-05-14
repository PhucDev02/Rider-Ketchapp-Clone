using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        transform.DOMoveY(transform.position.y + 0.8f, 0.5f).SetEase(Ease.InOutSine);
        gameObject.GetComponent<SpriteRenderer>().DOFade(0,1f).OnComplete(()=> Destroy(gameObject));
        Wallet.AddGems(100);
    }
}
