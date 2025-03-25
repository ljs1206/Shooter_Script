using UnityEngine;

#nullable disable
public class Lazer : MonoBehaviour
{
  private GameObject playerPos;
  private AudioSource audioSource;

  private void Awake()
  {
    this.playerPos = GameObject.FindWithTag("Player").gameObject;
    this.audioSource = this.GetComponent<AudioSource>();
  }

  private void Update()
  {
    this.transform.position = this.playerPos.transform.GetChild(0).position;
    if (!this.gameObject.activeSelf)
      return;
    this.audioSource.Play();
  }
}
