using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#nullable disable
public class BossHit : MonoBehaviour
{
  private SpriteRenderer sp;

  private void Awake() => this.sp = this.GetComponent<SpriteRenderer>();

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.gameObject.CompareTag("Player"))
      return;
    this.sp.DOFade(0.0f, 0.05f).OnComplete<TweenerCore<Color, Color, ColorOptions>>((TweenCallback) (() => this.sp.DOFade(1f, 0.05f)));
  }
}