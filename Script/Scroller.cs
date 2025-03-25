using UnityEngine;

#nullable disable
public class Scroller : MonoBehaviour
{
  [SerializeField]
  private Transform targetPos;
  [SerializeField]
  private float downSpeed;
  private float scrollPos = 20.4f;

  private void Update() => this.Scroll();

  private void Scroll()
  {
    this.transform.position += Vector3.down * this.downSpeed * Time.deltaTime;
    if ((double) this.transform.position.y > -(double) this.scrollPos)
      return;
    this.transform.position = new Vector3(0.0f, this.scrollPos);
  }
}
