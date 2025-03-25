using System.Collections;
using UnityEngine;

#nullable disable
public class FireEffect : MonoBehaviour
{
  [SerializeField]
  private GameObject PFEffect;
  private GameObject player;
  private ParticleSystem Ps;
  private GameObject _obj;

  private void Awake() => this.player = GameObject.Find("obj11111111111").gameObject;

  private void Start()
  {
    GameObject gameObject = Object.Instantiate<GameObject>(this.PFEffect, this.player.transform.GetChild(3));
    gameObject.SetActive(false);
    gameObject.transform.position = this.player.transform.GetChild(3).transform.position;
    this._obj = gameObject;
    this.Ps = gameObject.GetComponent<ParticleSystem>();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      this._obj.SetActive(true);
      this.StartCoroutine(this.FireStart());
    }
    if (!Input.GetKeyUp(KeyCode.Q))
      return;
    this.StopAllCoroutines();
    this.Ps.Stop();
  }

  private IEnumerator FireStart()
  {
    while (true)
    {
      this.Ps.Play();
      yield return (object) new WaitForSeconds(0.2f);
    }
  }
}