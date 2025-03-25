using System.Collections;
using UnityEngine;

#nullable disable
public class AttackEffect : MonoBehaviour
{
  [SerializeField]
  private GameObject PFEffect;
  private GameObject player;
  private ParticleSystem Ps;
  private GameObject _obj;

  private void Awake() => this.player = GameObject.FindWithTag("Player").gameObject;

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
    if (Input.GetButtonDown("Jump"))
    {
      this._obj.SetActive(true);
      this.StartCoroutine(this.FireStart());
    }
    if (!Input.GetButtonUp("Jump"))
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
