using UnityEngine;

#nullable disable
[CreateAssetMenu]
public class StageData : ScriptableObject
{
  [SerializeField]
  private Vector2 limitMax;
  [SerializeField]
  private Vector2 limitMin;

  public Vector2 LimitMax => this.limitMax;

  public Vector2 LimitMin => this.limitMin;
}
