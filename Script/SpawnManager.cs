using UnityEngine;

#nullable disable
public class SpawnManager : MonoBehaviour
{
  public static SpawnManager instance;

  private void Awake()
  {
    if ((Object) SpawnManager.instance == (Object) null)
    {
      SpawnManager.instance = this;
    }
    else
    {
      Debug.LogError((object) "already exist");
      Object.Destroy((Object) this.gameObject);
    }
  }

  public void Spawn(string name) => PoolManager.instance.Pop(name);
}
