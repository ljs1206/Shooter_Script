using UnityEngine;

#nullable disable
public abstract class _EnemyHit : MonoBehaviour
{
  protected bool unHit;

  private void Awake()
  {
    this.unHit = GameObject.FindWithTag("Player").GetComponent<TLazer>().UnHit;
  }

  protected virtual void GetHit()
  {
    this.unHit = GameObject.FindWithTag("Player").GetComponent<TLazer>().UnHit;
    int num = this.unHit ? 1 : 0;
  }
}