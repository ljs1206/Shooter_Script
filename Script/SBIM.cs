using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class SBIM : MonoBehaviour
{
  private GameObject player;
  private PlayerDie playerDie;
  [SerializeField]
  private GameObject Panel;
  private Image image;

  private void Awake()
  {
    this.player = GameObject.FindWithTag("Player").gameObject;
    this.playerDie = this.player.GetComponent<PlayerDie>();
    this.image = this.GetComponent<Image>();
  }

  private void Start() => this.playerDie.enabled = true;

  public void IMBTN()
  {
    if (this.playerDie.enabled)
    {
      this.playerDie.enabled = false;
      this.image.color = Color.red;
    }
    else
    {
      this.playerDie.enabled = true;
      this.image.color = new Color(173f, 173f, 173f, 1f);
    }
    GameMamager.instance.BTNClickP = false;
  }
}
