using UnityEngine;

#nullable disable
public class Destoryer : MonoBehaviour
{
  [SerializeField]
  private StageData stageData;

  private void Update()
  {
    if ((double) this.transform.position.x >= (double) this.stageData.LimitMin.x - 1.0 && (double) this.transform.position.x <= (double) this.stageData.LimitMax.x + 1.0 && (double) this.transform.position.y >= (double) this.stageData.LimitMin.y - 1.0 && (double) this.transform.position.y <= (double) this.stageData.LimitMax.y + 1.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}