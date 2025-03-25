using UnityEngine;

#nullable disable
public class GameObjectFind : MonoBehaviour
{
  private GameObject obj1;
  private GameObject obj2;
  private GameObject obj3;
  private GameObject obj4;

  private void Awake()
  {
    GameObject.Find("obj");
    this.obj1 = GameObject.Find("obj");
    this.obj2 = GameObject.Find("/obj");
    this.obj3 = GameObject.Find("Circle/obj");
    this.obj4 = GameObject.Find("/Circle/obj");
  }

  private void Start()
  {
    Debug.Log((object) this.obj1);
    Debug.Log((object) this.obj2);
    Debug.Log((object) this.obj3);
    Debug.Log((object) this.obj4);
  }
}
