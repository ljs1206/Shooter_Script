using UnityEngine;

#nullable disable
public class LazerCheck : MonoBehaviour
{
  private bool UnHit;

  private void Start()
  {
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    this.UnHit = GameObject.FindWithTag("Player").GetComponent<PlayerSkill>().unHit;
    if (this.UnHit)
      return;
    if (collision.gameObject.CompareTag("Enemy"))
    {
      Object.Destroy((Object) collision.gameObject);
      PlayerLevel.instance.ExpUp(5);
    }
    else if (collision.gameObject.CompareTag("Boss"))
    {
      collision.gameObject.GetComponent<EnemyHp>().HpDown(GameMamager.instance.LazerDamage);
    }
    else
    {
      if (!collision.gameObject.CompareTag("Meteo"))
        return;
      Object.Destroy((Object) collision.gameObject);
    }
  }
}
