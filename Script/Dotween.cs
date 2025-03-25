using DG.Tweening;
using UnityEngine;

#nullable disable
public class Dotween : MonoBehaviour
{
  [SerializeField]
  private Transform targetTrm1;
  [SerializeField]
  private Transform targetTrm2;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Q))
      return;
    this.transform.DOMove(this.targetTrm1.position, 3f).ChangeValues(this.transform.position, this.targetTrm2.position);
  }