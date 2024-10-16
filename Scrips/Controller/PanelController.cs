using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Image imageCanvas1;
    public Image imageCanvas2;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        ChangePanel();
    }
    public void ChangePanel()
    {
        switch (obj_mng.Instance.language)
        {
            case ObjManager.Language.Viet:
                imageCanvas2.sprite = sprites[0];
                break;
            case ObjManager.Language.English:
                imageCanvas2.sprite = sprites[1];
                break;
            case ObjManager.Language.France:
                break;
        }
    }
}
