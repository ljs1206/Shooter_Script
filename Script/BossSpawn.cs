using UnityEngine;

#nullable disable
public class BossSpawn : MonoBehaviour
{
  public static BossSpawn instance;
  [SerializeField]
  private GameObject bossPrefab;
  [SerializeField]
  private Transform bossSpawnPoint;
  private BossMove bossMove;
  private bool isSpawn;
  private GameObject boss;
  private bool isClick;

  public GameObject Boss
  {
    get => this.boss;
    set => this.boss = value;
  }

  private void Awake()
  {
    if ((Object) BossSpawn.instance == (Object) null)
      BossSpawn.instance = this;
    else
      Object.Destroy((Object) this.gameObject);
  }

  private void Start()
  {
    this.isClick = false;
    this.isSpawn = false;
  }

  private void Update()
  {
    if ((double) GameMamager.instance.Score < 20000.0 || this.isClick)
      return;
    this.isClick = true;
    GameObject gameObject = Object.Instantiate<GameObject>(this.bossPrefab, this.bossSpawnPoint.position, Quaternion.identity);
    gameObject.gameObject.name = gameObject.gameObject.name.Replace("(Clone)", "");
    this.isSpawn = true;
    this.bossMove = gameObject.GetComponent<BossMove>();
    this.bossMove.Move();
    this.Boss = gameObject;
  }
}
