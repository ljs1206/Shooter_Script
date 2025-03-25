using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ExpSlider : MonoBehaviour
{
  [SerializeField]
  private Slider expSlider;
  private bool MaxLevelReal;

  private void Start() => this.MaxLevelReal = false;

  private void Update()
  {
    if (this.MaxLevelReal)
      return;
    this.valueChange();
  }

  private void valueChange()
  {
    if ((double) Time.timeScale == 0.0)
      return;
    if (PlayerLevel.instance.Levels[PlayerLevel.instance.Level] != 0)
    {
      this.expSlider.DOValue((float) PlayerLevel.instance.Exp / (float) PlayerLevel.instance.Levels[PlayerLevel.instance.Level], 0.6f);
    }
    else
    {
      if (PlayerLevel.instance.Levels[PlayerLevel.instance.Level] != 0)
        return;
      Debug.Log((object) "최대 레벨");
      this.MaxLevelReal = true;
      this.expSlider.DOValue(1f, 0.6f);
    }
  }
}