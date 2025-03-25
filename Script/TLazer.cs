using System.Collections;
using UnityEngine;

#nullable disable
public class TLazer : MonoBehaviour
{
  [SerializeField]
  private GameObject LazerPF;
  [SerializeField]
  private GameObject Charing;
  [SerializeField]
  private LayerMask layer;
  [SerializeField]
  private GameObject ExplosionEffect;
  private BoxCollider2D box;
  private ParticleSystem PS;
  private GameObject player;
  private GameObject CharingC;
  private GameObject LazerPFC;
  private GameObject ExplosionEffectC;
  private bool isEnd;
  private bool unHit;
  private Vector3 _charing;
  private Vector3 _explosion;
  private Vector3 _lazer;
  private float count;

  public bool UnHit
  {
    get => this.unHit;
    set => this.unHit = value;
  }

  private void Awake()
  {
    this.player = GameObject.Find("obj11111111111").gameObject;
    this.PS = this.LazerPF.GetComponent<ParticleSystem>();
    this.box = this.LazerPF.GetComponent<BoxCollider2D>();
  }

  private void Start()
  {
    this.UnHit = true;
    this.isEnd = false;
    GameObject gameObject1 = Object.Instantiate<GameObject>(this.LazerPF, this.player.transform, false);
    GameObject gameObject2 = Object.Instantiate<GameObject>(this.Charing, this.player.transform, false);
    GameObject gameObject3 = Object.Instantiate<GameObject>(this.ExplosionEffect, this.player.transform, false);
    gameObject1.SetActive(false);
    gameObject2.SetActive(false);
    this.CharingC = gameObject2;
    this.LazerPFC = gameObject1;
    this.ExplosionEffectC = gameObject3;
  }

  private void Update()
  {
    this.CharingC.transform.position = this._charing;
    this.LazerPFC.transform.position = this._lazer;
    this.ExplosionEffectC.transform.position = this._explosion;
    if (!Input.GetKeyDown(KeyCode.Z))
      return;
    this.StartCoroutine(this.Lazer());
  }

  private IEnumerator Lazer()
  {
    Debug.Log((object) 1);
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
    this.LazerPFC.SetActive(true);
    this.ExplosionEffectC.SetActive(true);
    this.isEnd = true;
    this.UnHit = false;
    yield return (object) new WaitForSeconds(0.5f);
    this.UnHit = true;
  }
}
