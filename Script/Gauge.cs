using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#nullable disable
public class Gauge : MonoBehaviour
{
  private UnityEngine.UI.Slider loadingSlider;
  private bool isAction;

  private void Awake() => this.loadingSlider = this.GetComponent<UnityEngine.UI.Slider>();

  private void Start()
  {
    this.isAction = true;
    this.loadingSlider.value = 0.0f;
  }

  private void Update()
  {
    if (PlayerPrefs.GetInt("1") != 1 || !this.isAction)
      return;
    this.Slider();
  }

  public void Slider()
  {
    this.isAction = false;
    this.loadingSlider.DOValue(this.loadingSlider.maxValue, 12f).OnComplete<TweenerCore<float, float, FloatOptions>>((TweenCallback) (() =>
    {
      this.loadingSlider.value = 0.0f;
      this.isAction = true;
    }));
  }
}
