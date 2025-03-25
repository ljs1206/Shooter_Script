using UnityEngine;

#nullable disable
public abstract class EnemyHit : MonoBehaviour
{
  protected bool _unHit;

  protected virtual void _GetHit()
  {
    this._unHit = GameObject.FindWithTag("Player").GetComponent<PlayerSkill>().unHit;
    if (this._unHit)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}