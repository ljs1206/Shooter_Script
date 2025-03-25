using UnityEngine;

#nullable disable
public class Move : MonoBehaviour
{
  [SerializeField]
  private float moveSpeed;

  private void Update() => this.ObjMove();

  private void ObjMove()
  {
    this.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * this.moveSpeed * Time.deltaTime;
  }
}
