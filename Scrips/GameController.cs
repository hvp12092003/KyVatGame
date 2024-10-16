using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HVPUnityBase.Base.DesignPattern;
public class GameController : MonoBehaviour
{
    public string sceneAfter_Name;
    public string sceneBefore_Name;
    public static bool holdMouse = false;
    public static bool holdOBJ = false;
    public Color rayColor = Color.red; // Màu của Raycast
    float SetcountTime = 300;
    public float count = 0, countTime;
    public Transform obj;
    public GameObject buttonsUI;// UI
    public GameObject buttonsNext;// UI
    public ObjManager objManagerScrip;

    private void Start()
    {
        countTime = SetcountTime;
        objManagerScrip = GameObject.FindAnyObjectByType<ObjManager>();
        objManagerScrip.CreatOBJ();
        if (objManagerScrip.countScene == 8) buttonsNext.SetActive(false);
    }

    void Update()
    {
        HandleActionMouse();
        if (count == 5) buttonsUI.gameObject.SetActive(true);
    }
    public void HandleActionMouse()
    {
        if (!Input.GetMouseButton(0))
        {
            countTime -= Time.deltaTime;
            if (countTime <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
        else countTime = SetcountTime;
    }
}
public class GMNG : SingletonMonoBehaviour<GameController> { }
