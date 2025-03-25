using UnityEngine;

#nullable disable
public class Enemy2 : PoolableMono
{
  public override void Init()
  {
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.gameObject.CompareTag("Player"))
      return;
    Object.Destroy((Object) this.gameObject);
  }
}