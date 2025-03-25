using UnityEngine;

#nullable disable
public class SBCon : MonoBehaviour
{
  [SerializeField]
  private GameObject Panel;

  public void ConBTN()
  {
    this.Panel.SetActive(false);
    Time.timeScale = 1f;
    GameMamager.instance.BTNClickP = false;
  }
}