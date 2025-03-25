using System.Collections;
using TMPro;
using UnityEngine;

#nullable disable
public class LoadingText : MonoBehaviour
{
  private TextMeshProUGUI text;
  private int PerScent;
  [SerializeField]
  private LoadingPanelMove loading;
  private bool isAction;

  private void Start() => this.isAction = true;

  private void Awake()
  {
    this.text = this.GetComponent<TextMeshProUGUI>();
    this.PerScent = 0;
  }

  private void Update()
  {
    if (PlayerPrefs.GetInt("1") == 1 && this.isAction)
      this.StartCoroutine(this.TextUpValue());
    else
      this.text.text = this.PerScent.ToString() + "%";
  }

  public IEnumerator TextUpValue()
  {
    this.isAction = false;
    while (this.PerScent < 100)
    {
      ++this.PerScent;
      yield return (object) new WaitForSeconds(0.1f);
    }
    yield return (object) new WaitForSeconds(1.5f);
    this.loading.MoveOrigin();
    this.PerScent = 0;
    this.isAction = true;
  }
}
