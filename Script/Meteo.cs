using System.Collections;
using UnityEngine;

#nullable disable
public class Meteo : PoolableMono
{
  [SerializeField]
  private StageData stageData;
  private MoveMent moveMent;

  public override void Init()
  {
    this.moveMent = this.GetComponent<MoveMent>();
    this.transform.position = new Vector3(Random.Range(this.stageData.LimitMin.x, this.stageData.LimitMax.x), this.stageData.LimitMax.y + 1.5f, 0.0f);
    this.moveMent.MoveSpeed = 0.0f;
    this.StartCoroutine(this.Delay());
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.gameObject.CompareTag("Player"))
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private IEnumerator Delay()
  {
    yield return (object) new WaitForSeconds(1f);
    this.moveMent.MoveSpeed = 10f;
  }
}
