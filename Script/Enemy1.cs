using UnityEngine;

#nullable disable
public class Enemy1 : PoolableMono
{
  private float time;
  private GameObject player;
  private MoveMent moveMent;

  public override void Init()
  {
    this.moveMent = this.GetComponent<MoveMent>();
    this.player = GameObject.FindWithTag("Player").gameObject;
    this.Follow();
  }

  private void Follow()
  {
    this.time = 0.0f;
    for (float num = 4f; (double) this.time < (double) num; this.time += Time.deltaTime)
      this.moveMent.MoveTo(this.player.transform.position - this.transform.position.normalized);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.gameObject.CompareTag("Player"))
      return;
    Object.Destroy((Object) this.gameObject);
  }
}