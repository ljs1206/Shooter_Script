using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#nullable disable
public class IconEffect : MonoBehaviour
{
  private SpriteRenderer sp;

  private void Awake() => this.sp = this.GetComponent<SpriteRenderer>();

  private void OnEnable() => this.IconCont();

  private void IconCont()
  {
    this.sp.DOFade(0.0f, 0.5f).OnComplete<TweenerCore<Color, Color, ColorOptions>>((TweenCallback) (() => this.sp.DOFade(1f, 0.5f).OnComplete<TweenerCore<Color, Color, ColorOptions>>((TweenCallback) (() => this.transform.gameObject.SetActive(false)))));
  }
}