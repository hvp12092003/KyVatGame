using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class UIController : MonoBehaviour
{
    public GameObject buttonBack, buttonNext, menu;
    public AudioSource audioSource;
    public void Start()
    {
        if (obj_mng.Instance.countScene == 0) return;
        if (obj_mng.Instance.countScene == 1) buttonBack.SetActive(false);
        if (obj_mng.Instance.countScene == obj_mng.Instance.numOfScene) buttonNext.SetActive(false);
        menu.SetActive(false);
    }
    public void ButtonStart()
    {
        audioSource.Play();
        obj_mng.Instance.GetData();
        obj_mng.Instance.countScene++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ButtonBack()
    {
        audioSource.Play();
        obj_mng.Instance.countScene--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ButtonMenu()
    {
        audioSource.Play();
        obj_mng.Instance.countScene = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ButtonNext()
    {
        audioSource.Play();
        obj_mng.Instance.countScene++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
