using HVPUnityBase.Base.DesignPattern;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public enum Language
    {
        Viet, English, France
    }
    public Language language;
    public List<Vector3> posObj;
    public List<float> posNameTagX;
    public List<float> posNameTagY;
    public List<GameObject> listObj;
    public int x;

    public int countScene = 0;

    public GameObject objTemp;
    public GameObject[] array1;// array to take obj from resources
    public GameObject[,] array2 = new GameObject[5, 6];
    public GameObject[] test1;
    public GameObject[] test2;
    public GameObject[] test3;
    public GameObject[] test4;
    public GameObject[] test5;
    public GameObject[] test6;
    public GameObject[] test7;
    public int numOfScene;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
           }
    public void GetData()
    {
        switch (language)
        {
            case Language.Viet:
                array1 = Resources.LoadAll<GameObject>("Prefabs/Viet");
                break;
            case Language.English:
                array1 = Resources.LoadAll<GameObject>("Prefabs/English");
                break;
            case Language.France:
                break;
        }
        numOfScene = (int)(array1.Length/5);
       listObj = array1.ToList();
        DividToArrays();
    }

    public void DividToArrays()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < numOfScene; j++)
            {
                x = Random.Range(0, listObj.Count);
                array2[i, j] = listObj[x];
                listObj.RemoveAt(x);
            }
        }
        test1 = new GameObject[5];
        test2 = new GameObject[5];
        test3 = new GameObject[5];
        test4 = new GameObject[5];
        test5 = new GameObject[5];
        test6 = new GameObject[5];
        test7 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            test1[i] = array2[i, 0];
            test2[i] = array2[i, 1];
            test3[i] = array2[i, 2];
            test4[i] = array2[i, 3];
            test5[i] = array2[i, 4];
            test6[i] = array2[i, 5];
           // test7[i] = array2[i, 6];
        }
    }
    public void CreatOBJ()
    {
        for (int i = 0; i < 5; i++)
        {
            objTemp = Instantiate(array2[i, countScene - 1], posObj[i], Quaternion.identity);
        }
        listObj = GameObject.FindGameObjectsWithTag("Obj").ToList();
        SetPositionNameTag();
    }
    public void SetPositionNameTag()
    {
        for (int i = 0; i < 5; i++)
        {
            x = Random.Range(0, posNameTagY.Count);
            listObj[i].transform.position = new Vector3(posNameTagX[i], posNameTagY[x]);
        }
    }
}
public class obj_mng : SingletonMonoBehaviour<ObjManager> { }
