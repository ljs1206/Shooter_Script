using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Pool
{
  private Stack<PoolableMono> pool = new Stack<PoolableMono>();
  private PoolableMono prefab;
  private Transform parent;

  public Pool(PoolableMono _prefab, Transform _parent, int _cnt)
  {
    this.prefab = _prefab;
    this.parent = _parent;
    for (int index = 0; index < _cnt; ++index)
    {
      PoolableMono poolableMono = Object.Instantiate<PoolableMono>(this.prefab, this.parent);
      poolableMono.gameObject.name = poolableMono.gameObject.name.Replace("(Clone)", "");
      poolableMono.gameObject.SetActive(false);
      this.pool.Push(poolableMono);
    }
  }

  public PoolableMono Pop()
  {
    PoolableMono poolableMono;
    if (this.pool.Count <= 0)
    {
      poolableMono = Object.Instantiate<PoolableMono>(this.prefab, this.parent);
      poolableMono.gameObject.name = poolableMono.gameObject.name.Replace("(Clone)", "");
    }
    else
      poolableMono = this.pool.Pop();
    poolableMono.gameObject.SetActive(true);
    poolableMono.Init();
    return poolableMono;
  }

  public void Push(PoolableMono obj)
  {
    obj.gameObject.SetActive(false);
    this.pool.Push(obj);
  }
}
