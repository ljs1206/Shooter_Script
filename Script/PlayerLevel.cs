using UnityEngine;

#nullable disable
public class PlayerLevel : MonoBehaviour
{
  public static PlayerLevel instance;
  [SerializeField]
  private GameObject Panel;
  public int[] Levels;
  public int Level;
  public int Exp;

  private void Awake()
  {
    if ((Object) PlayerLevel.instance == (Object) null)
      PlayerLevel.instance = this;
    else
      Object.Destroy((Object) this.gameObject);
  }

  private void Start()
  {
    this.Panel.SetActive(false);
    this.Level = 0;
  }

  public void ExpUp(int value)
  {
    this.Exp += value;
    if (this.Exp < this.Levels[this.Level] || this.Levels[this.Level] == 0)
      return;
    ++this.Level;
    this.Exp = 0;
    this.LevelUp();
  }

  public void LevelUp()
  {
    this.Panel.SetActive(true);
    Time.timeScale = 0.0f;
  }
}