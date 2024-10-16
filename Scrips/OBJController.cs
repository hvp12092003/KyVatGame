using System.ComponentModel;
using UnityEngine;
using UnityEngine.Video;

public class OBJController : MonoBehaviour
{
    public GameObject OBJ;
    public OBJController component;
    public BoxCollider2D boxCollider;
    public BoxCollider2D boxOther;
    public AudioController audioController;
    public VideoController videoController;
    public VideoPlayer videoPlayer;
    public delegate void PlayVideo(VideoPlayer video);
    public PlayVideo playVideo;
    public GameController gameController;
    Vector3 offset;
    private Vector3 posOrin;
    private void Start()
    {
        GetData();
    }

    public void GetData()
    {
        posOrin = this.transform.position;
        gameController = GameObject.FindAnyObjectByType<GameController>();
        OBJ = transform.parent.gameObject;
        component = OBJ.GetComponent<OBJController>();
        videoPlayer = OBJ.GetComponentInChildren<VideoPlayer>();
        videoController = GameObject.FindGameObjectWithTag("VideoPlay").GetComponent<VideoController>();
        playVideo = videoController.PlayVideo;
        component = this.GetComponent<OBJController>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>(); ;
    }
    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        if (boxCollider.enabled)
        {
            transform.position = MouseWorldPosition() + offset;
            Vector3 pos = transform.position;
            transform.position = pos;
        }
    }
    private void OnMouseUp()
    {
        if (boxCollider.enabled)  this.transform.position = posOrin;
    }
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.name == this.transform.parent.name)
        {
            GameController.holdOBJ = true;
            this.transform.position = other.transform.position;
            Handle();
            EnabledComponemts(other.gameObject);
        }
    }

    public virtual void EnabledComponemts(GameObject other)
    {
        boxOther = other.GetComponent<BoxCollider2D>();
        boxOther.enabled = false;
        boxCollider.enabled = false;
        component.enabled = false;
    }
    public virtual void Handle()
    {
        gameController.obj = null;
        if (GMNG.Instance.count == 0) videoController.TurnOffImage();// if is first handler
        playVideo(videoPlayer);
        audioController.PlayAudio();
        GMNG.Instance.count++;
    }
}
