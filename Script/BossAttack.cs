using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class BossAttack : MonoBehaviour
{
  [SerializeField]
  private Transform OnRushPos;
  [SerializeField]
  private float rotateSpeed;
  private bool isOnRush;
  private GameObject iCon;
  private Animator animator;
  private float rotatePoint = 45f;
  private bool isattackEnd;
  private int count;
  private int spawnCount;
  private BossSpawn bossSpawn;
  private bool isDolJin;
  private Transform movePos;

  public float RotatePoint
  {
    get => this.rotatePoint;
    set
    {
      this.rotatePoint = value;
      if ((double) this.rotatePoint > -45.0)
        return;
      this.rotatePoint = 45f;
    }
  }

  private bool IsAttackEnd
  {
    get => this.isattackEnd;
    set => this.isattackEnd = value;
  }

  public int Count
  {
    get => this.count;
    set
    {
      if (value > 1)
        this.count = 0;
      else
        this.count = value;
    }
  }

  public int SpawnCount
  {
    get => this.spawnCount;
    set
    {
      if (this.spawnCount > 10)
        this.spawnCount = 0;
      else
        this.spawnCount = value;
    }
  }

  private void Awake()
  {
    this.animator = this.GetComponent<Animator>();
    this.iCon = this.transform.Find("icon").gameObject;
    this.bossSpawn = GameObject.Find("SpawnManager").GetComponent<BossSpawn>();
    this.movePos = GameObject.Find("SpawnPositions/BossMovePos").transform;
  }

  private void Start() => this.isOnRush = false;

  private void OnRush()
  {
    this.isOnRush = true;
    this.EndRush();
  }

  private void EndRush()
  {
    this.bossSpawn.Boss.transform.DOMove(this.OnRushPos.position, 1f).OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>((TweenCallback) (() =>
    {
      this.bossSpawn.Boss.transform.DOMove(this.movePos.position, 1f).OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>((TweenCallback) (() => this.isOnRush = false));
      this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }));
  }

  public IEnumerator AttackPaten()
  {
    BossAttack bossAttack = this;
    while (true)
    {
      // ISSUE: reference to a compiler-generated method
      yield return (object) new WaitUntil(new Func<bool>(bossAttack.\u003CAttackPaten\u003Eb__28_0));
      PoolManager.instance.Pop("Enemy");
      ++bossAttack.Count;
      ++bossAttack.SpawnCount;
      if (bossAttack.SpawnCount >= 10)
      {
        if (UnityEngine.Random.Range(1, 101) <= 30)
        {
          bossAttack.isDolJin = true;
          bossAttack.iCon.gameObject.SetActive(true);
          Debug.Log((object) bossAttack.iCon);
          Vector2 vector2 = (Vector2) GameMamager.instance.player.transform.position - (Vector2) bossAttack.transform.position;
          float num = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
          // ISSUE: reference to a compiler-generated method
          bossAttack.transform.DORotateQuaternion(Quaternion.AngleAxis(num + 90f, Vector3.forward), 1f).OnComplete<TweenerCore<Quaternion, Quaternion, NoOptions>>(new TweenCallback(bossAttack.\u003CAttackPaten\u003Eb__28_1));
        }
        if (UnityEngine.Random.Range(1, 101) <= 100 && !bossAttack.isDolJin)
        {
          Debug.Log((object) 1);
          bossAttack.animator.SetBool("isAction", true);
        }
      }
      yield return (object) new WaitForSeconds(0.7f);
    }
  }

  public IEnumerator Play()
  {
    for (int i = 0; i <= 20; ++i)
    {
      Debug.Log((object) 1);
      PoolManager.instance.Pop("Meteo");
      yield return (object) new WaitForSeconds(0.3f);
    }
  }
}