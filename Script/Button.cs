using UnityEngine;

#nullable disable
public class Button : MonoBehaviour
{
  private PlayerAttack playerAttack;
  private GameObject player;
  private MoveMent moveMent;
  [SerializeField]
  private GameObject Panel;
  [SerializeField]
  private TMP text;

  private void Awake()
  {
    this.playerAttack = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    this.player = GameObject.FindWithTag("Player").gameObject;
    this.moveMent = this.player.GetComponent<MoveMent>();
  }

  public void AttackUp()
  {
    this.playerAttack = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    if ((double) this.playerAttack.PlayerLevel >= 2.0)
    {
      this.text.Click();
    }
    else
    {
      ++GameMamager.instance.AttackLevel;
      ++this.playerAttack.PlayerLevel;
      this.Panel.SetActive(false);
      Time.timeScale = 1f;
    }
  }

  public void LazerUp()
  {
    if ((double) GameMamager.instance.LazerDamage >= 20.0)
    {
      this.text.Click();
    }
    else
    {
      ++GameMamager.instance.LazerLevel;
      GameMamager.instance.LazerDamage += 5f;
      this.Panel.SetActive(false);
      Time.timeScale = 1f;
    }
  }

  public void SpeedUp()
  {
    if ((double) this.moveMent.MoveSpeed >= 25.0)
    {
      this.text.Click();
    }
    else
    {
      ++GameMamager.instance.SpeedLevel;
      this.moveMent.MoveSpeed += 2.5f;
      this.Panel.SetActive(false);
      Time.timeScale = 1f;
    }
  }

  public void Skip()
  {
    this.Panel.SetActive(false);
    Time.timeScale = 1f;
  }
}