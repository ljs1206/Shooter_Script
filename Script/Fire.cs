using System.Collections;
using UnityEngine;

#nullable disable
public class Fire : MonoBehaviour
{
  [SerializeField]
  private GameObject PF;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
      this.StartCoroutine(this._Fire());
    if (!Input.GetKeyUp(KeyCode.Q))
      return;
    this.StopAllCoroutines();
  }

  private IEnumerator _Fire()
  {
    Fire fire = this;
    while (true)
    {
      Object.Instantiate<GameObject>(fire.PF, fire.transform.position, Quaternion.identity);
      yield return (object) new WaitForSeconds(0.2f);
    }
  }
}
