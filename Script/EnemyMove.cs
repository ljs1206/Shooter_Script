using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class EnemyMove : PoolableMono
{
  private GameObject player;
  private MoveMent moveMent;
  private bool isDie;
  private Transform SpawnPos1;
  private Transform SpawnPos2;
  private BossAttack bossAttack;

  private void Awake()
  {
    this.player = GameObject.FindWithTag("Player").gameObject;
    this.moveMent = this.GetComponent<MoveMent>();
    this.isDie = false;
  }

  public override void Init()
  {
    this.bossAttack = GameObject.Find("Boss").GetComponent<BossAttack>();
    this.SpawnPos1 = GameObject.Find("Boss/EnemySpawnPoint1").transform;
    this.SpawnPos2 = GameObject.Find("Boss/EnemySpawnPoint2").transform;
    if (this.bossAttack.Count == 0)
      this.transform.position = this.SpawnPos1.position;
    else if (this.bossAttack.Count == 1)
    {
      Debug.Log((object) "생성");
      this.transform.position = this.SpawnPos2.position;
    }
    if (this.isDie)
      return;
    this.Move();
  }

  private void Move()
  {
    this.moveMent.MoveTo((this.player.transform.position - this.transform.position).normalized);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log((object) 1);
    if (collision.gameObject.CompareTag("Player"))
    {
      this.isDie = true;
      SceneManager.LoadScene("GameOver");
      Object.Destroy((Object) this.gameObject);
    }
    if (!collision.gameObject.CompareTag("Lazer"))
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
