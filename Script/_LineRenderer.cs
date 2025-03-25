using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Collections;
using UnityEngine;

#nullable disable
public class _LineRenderer : MonoBehaviour
{
  [SerializeField]
  private GameObject obj2;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Q))
      return;
    this.StartCoroutine(this.OnRush(3f));
  }

  private IEnumerator OnRush(float time)
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    _LineRenderer lineRenderer = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      // ISSUE: reference to a compiler-generated method
      lineRenderer.transform.DOMove(lineRenderer.obj2.transform.position, 1f).OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>(new TweenCallback(lineRenderer.\u003COnRush\u003Eb__2_0));
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) new WaitForSeconds(time);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }
}
