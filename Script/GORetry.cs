using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class GORetry : MonoBehaviour
{
  public void Retry()
  {
    PlayerPrefs.SetInt("1", 1);
    SceneManager.LoadScene("GameScene");
  }
}