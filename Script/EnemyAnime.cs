using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class EnemyAnime : MonoBehaviour
{
  private Animator animator;
  private bool isEnd;

  private bool IsEnd
  {
    get => this.isEnd;
    set => this.isEnd = value;
  }

  private void Awake() => this.animator = this.GetComponent<Animator>();

  private void Start() => this.IsEnd = true;

  public void AnimeStart(Action action)
  {
    AnimatorManager.instance.ChangeBoolAnimation(this.animator, true);
    if (action == null)
      return;
    action();
  }

  public IEnumerator SPAnime(Action action)
  {
    EnemyAnime enemyAnime = this;
    enemyAnime.animator.StopPlayback();
    Action action1 = action;
    if (action1 != null)
      action1();
    // ISSUE: reference to a compiler-generated method
    yield return (object) new WaitUntil(new Func<bool>(enemyAnime.\u003CSPAnime\u003Eb__8_0));
    enemyAnime.animator.StartPlayback();
    enemyAnime.isEnd = false;
  }

  public void AnimeEnd(Action action)
  {
    AnimatorManager.instance.ChangeBoolAnimation(this.animator, false);
    if (action == null)
      return;
    action();
  }
}