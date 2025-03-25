using UnityEngine;

#nullable disable
public class PFDesroyer : MonoBehaviour
{
  [SerializeField]
  private float CheckY;

  private void Update()
  {
    if ((double) this.transform.position.y >= (double) this.CheckY)
      return;
    this.gameObject.SetActive(false);
  }
}