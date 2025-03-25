using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#nullable disable
public class EnemyHp : MonoBehaviour
{
  [SerializeField]
  private float hp;
  [SerializeField]
  private GameObject DestroyEffect;
  private SpriteRenderer sp;

  public float Hp
  {
    get => this.hp;
    set
    {
      this.hp = value;
      if ((double) this.hp >= 0.0)
        return;
      PlayerLevel.instance.ExpUp(5);
      PoolManager.instance.Pop("DestroyEffect").transform.position = this.transform.position;
      GameMamager.instance.Score += 100f;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Awake() => this.sp = this.GetComponent<SpriteRenderer>();

  public void HpDown(float damage)
  {
    this.Hp -= damage;
    this.sp.DOFade(0.0f, 0.1f).OnComplete<TweenerCore<Color, Color, ColorOptions>>((TweenCallback) (() => this.sp.DOFade(1f, 0.1f)));
  }
}
