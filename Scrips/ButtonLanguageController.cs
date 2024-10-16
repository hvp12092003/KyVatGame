using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ButtonLanguageController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textStart;
    [SerializeField] Image canvas1;
    [SerializeField] Image canvas2;
    [SerializeField] string textViet;
    [SerializeField] string textEnglish;
    [SerializeField] string textFrance;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image[] btImage;//iamge of 3 button language
    [SerializeField] Color[] colorOfButtons;
    [SerializeField] AudioSource audioSource;
    public PanelController panelController;
    private void Start()
    {
        panelController = FindAnyObjectByType<PanelController>();
        HandlerUI();
    }
    public void ButtonViet()
    {
        audioSource.Play();
        //chage value
        obj_mng.Instance.language = ObjManager.Language.Viet;
        //handler 
        HandlerUI();
    }
    public void ButtonEnglish()
    {
        audioSource.Play();
        //chage value
        obj_mng.Instance.language = ObjManager.Language.English;
        //handler 
        HandlerUI();
    }
    public void ButtonFrance()
    {
        audioSource.Play();
        //chage value
        obj_mng.Instance.language = ObjManager.Language.France;
        //handler 
        HandlerUI();
    }
    public void HandlerUI()
    {
        switch (obj_mng.Instance.language)
        {
            case ObjManager.Language.Viet:
                // change panel 
                canvas1.sprite = sprites[0];
                canvas2.sprite = sprites[0];
                //  panelController.ChangePanel();
                // change text
                textStart.text = textViet;
                // change color button
                btImage[0].color = colorOfButtons[0];
                btImage[1].color = colorOfButtons[1];
                break;
            case ObjManager.Language.English:
                // change panel 
                canvas1.sprite = sprites[1];
                canvas2.sprite = sprites[1];
                // panelController.ChangePanel();
                // change text
                textStart.text = textEnglish;
                // change color button
                btImage[0].color = colorOfButtons[1];
                btImage[1].color = colorOfButtons[0];
                break;
            case ObjManager.Language.France:
                // change panel 
                // panelController.ChangePanel();
                // change text
                textStart.text = textFrance;
                // change color button
                break;
        }
    }
}
