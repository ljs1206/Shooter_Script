using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class InStartBTN : MonoBehaviour
{
  public void OnClick()
  {
    PlayerPrefs.SetInt("1", 1);
    SceneManager.LoadScene("GameScene");
  }