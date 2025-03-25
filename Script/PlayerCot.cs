using UnityEngine;

#nullable disable
public class PlayerCot : MonoBehaviour
{
  [SerializeField]
  private StageData stageData;
  private MoveMent moveMent;

  private void Awake() => this.moveMent = this.GetComponent<MoveMent>();

  private void Update()
  {
    if (!GameMamager.instance.IsStart)
      return;
    this._Move();
  }

  private void LateUpdate() => this.Limit();

  private void _Move()
  {
    this.moveMent.MoveTo(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized);
  }

  private void Limit()
  {
    this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.stageData.LimitMin.x, this.stageData.LimitMax.x), Mathf.Clamp(this.transform.position.y, this.stageData.LimitMin.y, this.stageData.LimitMax.y));
  }
}
