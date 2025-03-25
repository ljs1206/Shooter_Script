using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class BossMove : MonoBehaviour
{
  private Sequence seq;
  private BossAttack bossAttack;
  private BossIn bossIn;
  private Animator animator;
  private bool isMove;
  private PlayerAttack playerAttack;
  private Transform movePos;

  private void Awake()
  {
    this.playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
    this.animator = this.GetComponent<Animator>();
    this.bossIn = GameObject.Find("GameManager").GetComponent<BossIn>();
    this.bossAttack = this.GetComponent<BossAttack>();
    this.movePos = GameObject.Find("SpawnPositions/BossMovePos").transform;
    this.isMove = false;
  }

  public void Move()
  {
    this.isMove = true;
    this.seq = DOTween.Sequence();
    this.seq.Append((Tween) this.transform.DOMove(this.movePos.position, 3.5f));
    this.seq.OnComplete<Sequence>((TweenCallback) (() => this.StartCoroutine(this.bossIn.PanelMove())));
  }

  public void AnimeStop()
  {
    this.animator.speed = 0.0f;
    this.StartCoroutine(this.AnimationStop());
  }

  public IEnumerator AnimationStop()
  {
    BossMove bossMove = this;
    bossMove.StartCoroutine(CameraManager.instance.ShakeCam(5f, 3f));
    yield return (object) new WaitUntil((Func<bool>) (() => CameraManager.instance.IsEnd));
    bossMove.animator.speed = 1f;
    bossMove.animator.SetBool("isAction", false);
    if (bossMove.isMove)
    {
      bossMove.StartCoroutine(bossMove.bossAttack.AttackPaten());
      bossMove.playerAttack.AttackTrue = true;
      bossMove.isMove = false;
    }
    else
      bossMove.StartCoroutine(bossMove.bossAttack.Play());
  }
}