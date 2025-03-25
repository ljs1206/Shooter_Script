using UnityEngine;

#nullable disable
public class _PlayerBullet : PoolableMono
{
  public override void Init()
  {
  }

  private void Update() => this.transform.Translate(this.transform.up * Time.deltaTime);

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Enemy"))
    {
      collision.gameObject.GetComponent<EnemyHp>().HpDown(1f);
    }
    else
    {
      if (!collision.gameObject.CompareTag("Boss"))
        return;
      collision.gameObject.GetComponent<EnemyHp>().HpDown(1f);
    }
  }
}
