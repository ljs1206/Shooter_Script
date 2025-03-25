using System.Collections;
using UnityEngine;

#nullable disable
public class PlayerAttack : MonoBehaviour
{
  private Coroutine AttackCR;
  private bool attackTrue;
  [SerializeField]
  private float levelUpAttackAngle = 60f;
  [SerializeField]
  private float _luABulletCount;
  private AudioSource audioSource;
  private Coroutine attack;
  private float cRAttackCount;
  private float playerLevel;
  private bool isKeyDown;

  public float CRAttackCount
  {
    get => this.cRAttackCount;
    set
    {
      if ((double) value < (double) this._luABulletCount)
        this.cRAttackCount = 0.0f;
      else
        this.cRAttackCount = value;
    }
  }

  public float PlayerLevel
  {
    get => this.playerLevel;
    set => this.playerLevel = value;
  }

  public bool AttackTrue
  {
    get => this.attackTrue;
    set => this.attackTrue = value;
  }

  private void Awake()
  {
    this.attackTrue = false;
    this.audioSource = this.GetComponent<AudioSource>();
  }

  private void Start() => this.isKeyDown = false;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && GameMamager.instance.IsStart)
    {
      this.isKeyDown = true;
      float playerLevel = this.PlayerLevel;
      if ((double) playerLevel != 0.0)
      {
        if ((double) playerLevel != 1.0)
        {
          if ((double) playerLevel == 2.0)
            this.StartCoroutine(this.Level2Attack(3f));
          else
            this.StartCoroutine(this.Level2Attack(3f));
        }
        else
          this.StartCoroutine(this.LevelAttack(2f));
      }
      else
        this.StartCoroutine(this.Attack());
    }
    if (!Input.GetKeyUp(KeyCode.Space) || !GameMamager.instance.IsStart)
      return;
    this.isKeyDown = false;
    this.StopAllCoroutines();
  }

  public IEnumerator Attack()
  {
    PlayerAttack playerAttack = this;
    while (true)
    {
      playerAttack.audioSource.Play();
      PoolManager.instance.Pop("PlayerBullet").transform.position = playerAttack.transform.position;
      if ((double) playerAttack.PlayerLevel > 0.0)
      {
        playerAttack.StopAllCoroutines();
        playerAttack.StartCoroutine(playerAttack.LevelAttack(2f));
      }
      yield return (object) new WaitForSeconds(0.2f);
    }
  }

  public IEnumerator Level2Attack(float luABulletCount)
  {
    PlayerAttack playerAttack = this;
    float angle = playerAttack.levelUpAttackAngle / (luABulletCount - 1f);
    while (playerAttack.isKeyDown)
    {
      for (int index = 0; (double) index < (double) luABulletCount; ++index)
      {
        playerAttack.audioSource.Play();
        PoolableMono poolableMono = PoolManager.instance.Pop("PlayerBullet");
        Vector2 vector2 = (Vector2) (Quaternion.Euler(0.0f, 0.0f, (float) ((double) playerAttack.levelUpAttackAngle / 2.0 - (double) angle * (double) index)) * playerAttack.transform.up);
        poolableMono.transform.position = (Vector3) (vector2.normalized + (Vector2) playerAttack.transform.position);
        poolableMono.transform.up = (Vector3) vector2;
      }
      yield return (object) new WaitForSeconds(0.2f);
    }
  }

  public IEnumerator LevelAttack(float luABulletCount)
  {
    PlayerAttack playerAttack = this;
    float angle = playerAttack.levelUpAttackAngle / (luABulletCount - 1f);
    while (playerAttack.isKeyDown)
    {
      for (int index = 0; (double) index < (double) luABulletCount; ++index)
      {
        playerAttack.audioSource.Play();
        PoolableMono poolableMono = PoolManager.instance.Pop("PlayerBullet");
        Vector2 vector2 = (Vector2) (Quaternion.Euler(0.0f, 0.0f, (float) ((double) playerAttack.levelUpAttackAngle / 2.0 - (double) angle * (double) index)) * playerAttack.transform.up);
        poolableMono.transform.position = (Vector3) (vector2.normalized + (Vector2) playerAttack.transform.position);
        poolableMono.transform.up = (Vector3) vector2;
      }
      if ((double) playerAttack.PlayerLevel > 1.0)
      {
        playerAttack.StopAllCoroutines();
        playerAttack.StartCoroutine(playerAttack.Level2Attack(3f));
      }
      yield return (object) new WaitForSeconds(0.2f);
    }
  }
}
