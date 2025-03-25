using UnityEngine;

#nullable disable
public class Effect : MonoBehaviour
{
  private GameObject player;

  private void Awake() => this.player = GameObject.FindWithTag("Player").gameObject;

  private void Update() => this.transform.position = this.player.transform.GetChild(1).position;
}
