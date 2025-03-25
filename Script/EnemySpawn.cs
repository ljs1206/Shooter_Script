using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class EnemySpawn : MonoBehaviour
{
  [SerializeField]
  private StageData stageData;

  private void OnEnable() => this.StartCoroutine(this.Spawn());

  private void Start()
  {
  }

  private void Update()
  {
    if ((double) GameMamager.instance.Score < 20000.0)
      return;
    this.StopAllCoroutines();
  }

  private IEnumerator Spawn()
  {
    while (true)
    {
      yield return (object) new WaitUntil((Func<bool>) (() => (UnityEngine.Object) GameMamager.instance != (UnityEngine.Object) null && GameMamager.instance.IsStart));
      PoolManager.instance.Pop("Enemy1").transform.position = new Vector3(UnityEngine.Random.Range(this.stageData.LimitMin.x, this.stageData.LimitMax.x), this.stageData.LimitMax.y + 1.5f, 0.0f);
      yield return (object) new WaitForSeconds(0.5f);
      PoolableMono poolableMono1 = PoolManager.instance.Pop("Enemy2");
      float x = UnityEngine.Random.Range(this.stageData.LimitMin.x, this.stageData.LimitMax.x);
      poolableMono1.transform.position = new Vector3(x, this.stageData.LimitMax.y + 1.5f, poolableMono1.transform.position.z);
      PoolableMono poolableMono2 = PoolManager.instance.Pop("Enemy2");
      poolableMono2.transform.position = new Vector3(x + 2f, this.stageData.LimitMax.y + 1.5f, poolableMono2.transform.position.z);
      PoolableMono poolableMono3 = PoolManager.instance.Pop("Enemy2");
      poolableMono3.transform.position = new Vector3(x - 2f, this.stageData.LimitMax.y + 1.5f, poolableMono3.transform.position.z);
      yield return (object) new WaitForSeconds(0.5f);
      PoolManager.instance.Pop("Enemy3").transform.position = new Vector3(UnityEngine.Random.Range(this.stageData.LimitMin.x, this.stageData.LimitMax.x), this.stageData.LimitMax.y + 1.5f, 0.0f);
    }
  }
}
