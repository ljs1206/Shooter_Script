using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Collections;
using UnityEngine;

#nullable disable
public class BossIn : MonoBehaviour
{
  [SerializeField]
  private RectTransform panelRect;
  [SerializeField]
  private RectTransform MoveTrm;
  [SerializeField]
  private GameObject PanelBackground;
  private Animator animator;

  private void Start() => this.PanelBackground.SetActive(false);

  public IEnumerator PanelMove()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    BossIn bossIn = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      Debug.Log((object) "실행");
      // ISSUE: reference to a compiler-generated method
      bossIn.panelRect.DOLocalMoveX(bossIn.panelRect.rect.width * 1.5f, 1.5f).SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(Ease.InOutBack).OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>(new TweenCallback(bossIn.\u003CPanelMove\u003Eb__5_0));
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    bossIn.animator = GameObject.FindWithTag("Boss").GetComponent<Animator>();
    bossIn.PanelBackground.SetActive(true);
    bossIn.panelRect.DOMove(bossIn.MoveTrm.position, 1f).SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(Ease.OutBack);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) new WaitForSeconds(3.5f);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }
}