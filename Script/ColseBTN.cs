using UnityEngine;

#nullable disable
public class ColseBTN : MonoBehaviour
{
  [SerializeField]
  private GameObject panel;

  public void CBTN()
  {
    this.panel.SetActive(false);
    GameMamager.instance.BTNClickP = false;
    Time.timeScale = 1f;
  }
}