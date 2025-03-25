using UnityEngine;

#nullable disable
public class Bullet : PoolableMono
{
  [SerializeField]
  private float downSpeed = 5f;
  [SerializeField]
  private Transform attack1Pos;
  [SerializeField]
  private Transform attack2Pos;
  private BossAttack bossAttack;

  public override void Init()
  {
    this.bossAttack = GameObject.Find("Boss").GetComponent<BossAttack>();
    this.bossAttack = this.GetComponent<BossAttack>();
    Debug.Log((object) this);
    this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, this.bossAttack.RotatePoint);
    this.transform.position = this.attack1Pos.position;
  }

  private void Update() => this.transform.Translate(Vector3.down * this.downSpeed * Time.deltaTime);

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.gameObject.CompareTag("Player"))
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
