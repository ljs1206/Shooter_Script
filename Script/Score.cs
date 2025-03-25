using TMPro;
using UnityEngine;

#nullable disable
public class Score : MonoBehaviour
{
  private TextMeshProUGUI ScoreText;

  private void Awake() => this.ScoreText = this.GetComponent<TextMeshProUGUI>();

  private void Update() => this.ScoreText.text = "Score: " + GameMamager.instance.Score.ToString();
}
