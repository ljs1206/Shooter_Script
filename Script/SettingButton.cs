using UnityEngine;

#nullable disable
public class SettingButton : MonoBehaviour
{
  [SerializeField]
  private GameObject Panel;

  private void Start() => this.Panel.SetActive(false);

  public void Setting()
  {
    if (GameMamager.instance.BTNClickP || !GameMamager.instance.IsStart)
      return;
    this.Panel.SetActive(true);
    Time.timeScale = 0.0f;
    GameMamager.instance.BTNClickP = true;
  }
}