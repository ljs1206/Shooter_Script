using Cinemachine;
using System.Collections;
using UnityEngine;

#nullable disable
public class CameraManager : MonoBehaviour
{
  public static CameraManager instance;
  private CinemachineVirtualCamera vCam;
  private CinemachineBasicMultiChannelPerlin perlin;
  private bool isEnd;

  public bool IsEnd
  {
    get => this.isEnd;
    set => this.isEnd = value;
  }

  private void Awake()
  {
    if ((Object) CameraManager.instance == (Object) null)
    {
      CameraManager.instance = this;
    }
    else
    {
      Debug.LogError((object) "이미 존재");
      Object.Destroy((Object) this.gameObject);
    }
    this.vCam = this.transform.Find("PlayerVCam").GetComponent<CinemachineVirtualCamera>();
    this.perlin = this.vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
  }

  private void Start()
  {
    this.isEnd = false;
    this.perlin.m_FrequencyGain = 0.0f;
  }

  public IEnumerator ShakeCam(float amplitude, float time)
  {
    float currentTime = 0.0f;
    this.perlin.m_FrequencyGain = 6f;
    while ((double) currentTime < (double) time)
    {
      currentTime += Time.deltaTime;
      float num = (float) (1.0 - (double) currentTime / (double) time);
      this.perlin.m_AmplitudeGain = amplitude * num;
      yield return (object) null;
    }
    this.perlin.m_AmplitudeGain = 0.0f;
    this.perlin.m_FrequencyGain = 0.0f;
    this.IsEnd = true;
  }
}
