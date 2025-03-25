using UnityEngine;

#nullable disable
public class GameMamager : MonoBehaviour
{
  public static GameMamager instance;
  public GameObject player;
  [SerializeField]
  private Transform playerspawnTrm;
  [SerializeField]
  private GameObject settingPanel;
  [SerializeField]
  private float maxScore;
  private GameObject Boss;
  private float lazerDamage;
  public float attackLevel;
  private float lazerLevel;
  private float speedLevel;
  private bool BTNClick;
  private bool isStart;
  private float score;

  public float LazerDamage
  {
    get => this.lazerDamage;
    set => this.lazerDamage = value;
  }

  public float AttackLevel
  {
    get => this.attackLevel;
    set
    {
      if ((double) this.attackLevel++ >= 99.0)
        this.attackLevel = 99f;
      else
        this.attackLevel = value;
    }
  }

  public float LazerLevel
  {
    get => this.lazerLevel;
    set
    {
      if ((double) this.lazerLevel++ >= 99.0)
        this.lazerLevel = 99f;
      else
        this.lazerLevel = value;
    }
  }

  public float SpeedLevel
  {
    get => this.speedLevel;
    set
    {
      if ((double) this.speedLevel++ >= 99.0)
        this.speedLevel = 99f;
      else
        this.speedLevel = value;
    }
  }

  public bool BTNClickP
  {
    get => this.BTNClick;
    set => this.BTNClick = value;
  }

  public bool IsStart { get; set; }

  public float Score
  {
    get => this.score;
    set
    {
      if ((double) this.score > (double) this.maxScore)
        this.score = this.maxScore;
      else
        this.score = value;
    }
  }

  private void Awake()
  {
    if ((Object) GameMamager.instance == (Object) null)
    {
      GameMamager.instance = this;
    }
    else
    {
      Debug.LogError((object) "이미 존재");
      Object.Destroy((Object) this.gameObject);
    }
    this.player.transform.position = this.playerspawnTrm.position;
  }

  private void Start()
  {
    this.AttackLevel = 0.0f;
    this.LazerLevel = 0.0f;
    this.SpeedLevel = 0.0f;
    this.LazerDamage = 5f;
    this.IsStart = false;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape) && !this.BTNClick && this.IsStart)
    {
      this.settingPanel.SetActive(true);
      Time.timeScale = 0.0f;
    }
    if (!Input.GetKeyDown(KeyCode.G))
      return;
    this.Score += 20000f;
  }
}