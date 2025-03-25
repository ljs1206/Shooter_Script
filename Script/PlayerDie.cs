using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class PlayerDie : MonoBehaviour
{
  private BoxCollider2D boxCollider2D;
  private Collider2D collision1;
  [SerializeField]
  private Vector2 boxSize;
  [SerializeField]
  private LayerMask layer;

  private void Awake() => this.boxCollider2D = this.GetComponent<BoxCollider2D>();

  private void Update()
  {
    if (!(bool) (Object) this.CheckEnemy())
      return;
    SceneManager.LoadScene("GameOver");
  }

  private Collider2D CheckEnemy()
  {
    return Physics2D.OverlapBox((Vector2) this.transform.position, this.boxSize, 0.0f, (int) this.layer);
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(this.transform.position, (Vector3) this.boxSize);
  }
}