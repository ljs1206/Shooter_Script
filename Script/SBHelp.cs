using UnityEngine;

#nullable disable
public class SBHelp : MonoBehaviour
{
  [SerializeField]
  private GameObject panel;
  [SerializeField]
  private GameObject panelHelp;
  private bool isClick;

  private void Awake() => this.isClick = false;

  public void HelpBTN()
  {
    if (this.isClick)
      return;
    this.panel.SetActive(false);
    this.panelHelp.SetActive(true);
  }
}
