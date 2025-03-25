using UnityEngine;

#nullable disable
public class AnimatorManager : MonoBehaviour
{
  public static AnimatorManager instance;

  private void Awake()
  {
    if ((Object) AnimatorManager.instance == (Object) null)
    {
      AnimatorManager.instance = this;
    }
    else
    {
      Debug.LogError((object) "이미 존재");
      Object.Destroy((Object) this.gameObject);
    }
  }

  public void ChangeBoolAnimation(Animator animator, bool TAndF)
  {
    animator.SetBool("isAction", TAndF);
  }

  public void ChangeTriggerAnimation(Animator animator) => animator.SetTrigger("isAction");

  public void SpeedChange(Animator animator, float speed) => animator.speed = speed;
}