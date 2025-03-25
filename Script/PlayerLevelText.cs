using TMPro;
using UnityEngine;

#nullable disable
public class PlayerLevelText : MonoBehaviour
{
  private TextMeshProUGUI _playerLevelText;

  private void Awake() => this._playerLevelText = this.GetComponent<TextMeshProUGUI>();

  private void Update()
  {
    if (PlayerLevel.instance.Levels[PlayerLevel.instance.Level] != 0)
      this._playerLevelText.text = "Lv." + PlayerLevel.instance.Level.ToString();
    else
      this._playerLevelText.text = "Lv.Max";
  }
}