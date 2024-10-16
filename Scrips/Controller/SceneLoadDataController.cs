using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoadDataController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
