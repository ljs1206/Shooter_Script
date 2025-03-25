using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

#nullable disable
public class TMP : MonoBehaviour
{
  private TextMeshProUGUI text;
  [SerializeField]
  private RectTransform rectTrm;
  [SerializeField]
  private RectTransform originPos;
  private bool isAction;

  private void Awake() => this.text = this.GetComponent<TextMeshProUGUI>();

  private void Start()
  {
    this.gameObject.SetActive(false);
    this.isAction = false;
  }

  public void Click()
  {
    if (this.isAction)
      return;
    this.gameObject.SetActive(true);
    this.isAction = true;
    this.rectTrm.DOAnchorPosY(100f, 3f);
    this.text.DOFade(0.0f, 2f).OnComplete<TweenerCore<Color, Color, ColorOptions>>((TweenCallback) (() =>
    {
      this.gameObject.SetActive(false);
      this.text.color = new Color(this.text.color.r, this.text.color.g, this.text.color.b, 1f);
      this.rectTrm = this.originPos;
      DOTween.KillAll();
      this.isAction = false;
    }));
  }
}