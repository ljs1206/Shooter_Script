using System.Collections;
using UnityEngine;

#nullable disable
public class PlayerSkill : MonoBehaviour
{
  [SerializeField]
  private GameObject LazerPF;
  [SerializeField]
  private GameObject Charing;
  [SerializeField]
  private LayerMask layer;
  private BoxCollider2D box;
  private ParticleSystem PS;
  private GameObject player;
  private GameObject CharingC;
  private GameObject LazerPFC;
  private GameObject ExplosionEffectC;
  public bool unHit;
  private bool isEnd;
  private bool TryAttack;
  private float count;

  private void Awake()
  {
    this.player = GameObject.Find("Player").gameObject;
    this.PS = this.LazerPF.GetComponent<ParticleSystem>();
    this.box = this.LazerPF.GetComponent<BoxCollider2D>();
  }

  private void Start()
  {
    this.TryAttack = true;
    this.unHit = true;
    this.isEnd = false;
    GameObject gameObject1 = Object.Instantiate<GameObject>(this.LazerPF, this.player.transform.GetChild(0));
    gameObject1.transform.position = this.player.transform.GetChild(0).transform.position;
    GameObject gameObject2 = Object.Instantiate<GameObject>(this.Charing, this.player.transform.GetChild(1));
    gameObject2.transform.position = this.player.transform.GetChild(1).transform.position;
    gameObject1.SetActive(false);
    gameObject2.SetActive(false);
    this.CharingC = gameObject2;
    this.LazerPFC = gameObject1;
  }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Z) || !this.TryAttack)
      return;
    this.StartCoroutine(this.Lazer());
  }

  private IEnumerator Lazer()
  {
    this.TryAttack = false;
    this.count = 0.0f;
    this.CharingC.SetActive(true);
    while (true)
    {
      if (this.CharingC.GetComponent<ParticleSystem>().isPlaying)
      {
        ++this.count;
        if ((double) this.count < 3.0)
          yield return (object) null;
        else
          break;
      }
      yield return (object) new WaitForSeconds(1f);
    }
    this.PS.Stop();
    this.CharingC.SetActive(false);
    this.unHit = false;
    this.LazerPFC.SetActive(true);
    this.isEnd = true;
    yield return (object) new WaitForSeconds(0.4f);
    this.unHit = true;
    yield return (object) new WaitForSeconds(5f);
    this.TryAttack = true;
  }
}
