using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#nullable disable
public class LoadingPanelMove : MonoBehaviour
{
  [SerializeField]
  private Transform moveTrm;
  [SerializeField]
  private Transform origoinPos;
  private bool isAction;

  private void Start() => this.isAction = true;

  private void Update()
  {
    if (PlayerPrefs.GetInt("1") != 1 || !this.isAction)
      return;
    this.PanelMove();
  }

  public void PanelMove()
  {
    this.isAction = false;
    this.transform.DOMove(this.moveTrm.position, 0.5f);
  }

  public void MoveOrigin()
  {
    PlayerPrefs.SetInt("1", 0);
    this.transform.DOMove(this.origoinPos.position, 0.5f).OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>((TweenCallback) (() =>
    {
      GameMamager.instance.IsStart = true;
      this.isAction = true;
    }));
  }
}
