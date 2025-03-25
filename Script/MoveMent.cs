using UnityEngine;

#nullable disable
public class MoveMent : MonoBehaviour
{
  [SerializeField]
  private Vector3 moveDir;
  [SerializeField]
  private float moveSpeed;

  public float MoveSpeed
  {
    get => this.moveSpeed;
    set
    {
      if ((double) value >= 20.0)
        this.moveSpeed = 20f;
      else
        this.moveSpeed = value;
    }
  }

  private void Update()
  {
    this.transform.position += this.moveDir * this.MoveSpeed * Time.deltaTime;
  }

  public void MoveTo(Vector3 dir) => this.moveDir = dir;
}
