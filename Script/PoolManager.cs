using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class PoolManager : MonoBehaviour
{
  public static PoolManager instance;
  public List<PoolableMono> poolingObjs = new List<PoolableMono>();
  private Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

  private void Awake()
  {
    if ((Object) PoolManager.instance == (Object) null)
    {
      PoolManager.instance = this;
    }
    else
    {
      Debug.LogError((object) "multiply PoolManager Instance");
      Object.Destroy((Object) this);
    }
    this.CreatePool();
  }

  private void CreatePool()
  {
    for (int index = 0; index < this.poolingObjs.Count; ++index)
    {
      Pool pool = new Pool(this.poolingObjs[index], this.transform, 10);
      this.pools.Add(this.poolingObjs[index].name, pool);
    }
  }

  public PoolableMono Pop(string name) => this.pools[name].Pop();

  public void Push(PoolableMono obj) => this.pools[obj.name].Push(obj);
}