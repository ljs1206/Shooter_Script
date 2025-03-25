using TMPro;
using UnityEngine;

#nullable disable
public class LevelText : MonoBehaviour
{
  [SerializeField]
  protected TextMeshProUGUI text;

  protected void TextSetting(float index) => this.text.text = "Lv." + index.ToString();
}