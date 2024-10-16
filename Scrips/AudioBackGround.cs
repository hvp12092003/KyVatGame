using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackGround : MonoBehaviour
{
    //public static AudioBackGround AuM;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Au");


        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //AuM = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
