using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Blade : MonoBehaviour
{
    public Vector3 direction { get; private set; }

    private Camera mainCamera;

    private Collider sliceCollider;
    private TrailRenderer sliceTrail;

    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;

    private bool slicing;
    //Can edit
    public int BoxCount = 0;
    public int WatermelonCount = 0;
    public int BrownBoxCount = 0;
    public int KiwiCount = 0;
    public int LemonCount = 0;
    public int AppleCount = 0;
    public int OrangeCount = 0;
    public int OrangeBoxCount = 0;
    public int RedBoxCount = 0;
    public int YellowBoxCount = 0;
    public int CylinderCount = 0;
    //All shapes (fruits)

    private Text WinMsg;
    private Text LoseMsg;

    private void Awake()
    {
        mainCamera = Camera.main;
        sliceCollider = GetComponent<Collider>();
        sliceTrail = GetComponentInChildren<TrailRenderer>();
        WinMsg = GameObject.Find("WinMsg").GetComponent<Text>();
    }

    private void OnEnable()
    {
        StopSlice();
    }

    private void OnDisable()
    {
        StopSlice();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) {
            StartSlice();
        } else if (Input.GetMouseButtonUp(0)) {
            StopSlice();
        } else if (slicing) {
            ContinueSlice();
        }
    }

    private void StartSlice()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        transform.position = position;

        slicing = true;
        sliceCollider.enabled = true;
        sliceTrail.enabled = true;
        sliceTrail.Clear();
    }

    private void StopSlice()
    {
        slicing = false;
        sliceCollider.enabled = false;
        sliceTrail.enabled = false;
        Application.Quit();
    }

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        sliceCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoxFruit"){
            BoxCount++;
        }
        if(other.gameObject.tag == "WatermelonFruit"){
            WatermelonCount++;
        }
        if(other.gameObject.tag == "AppleFruit"){
            AppleCount++;
        }
        if(other.gameObject.tag == "CylinderFruit"){
            CylinderCount++;
        }
        if(other.gameObject.tag == "BrownBoxFruit"){
            BrownBoxCount++;
        }

        if(other.gameObject.tag == "KiwiFruit"){
            KiwiCount++;
        }
        if(other.gameObject.tag == "LemonFruit"){
            LemonCount++;
        }
        if(other.gameObject.tag == "OrangeFruit"){
            OrangeCount++;
        }
        if(other.gameObject.tag == "OrangeBoxFruit"){
            OrangeBoxCount++;
        }
        if(other.gameObject.tag == "RedBoxFruit"){
            RedBoxCount++;
        }
        if(other.gameObject.tag == "YellowBoxFruit"){
            YellowBoxCount++;
        }
        if(BoxCount + WatermelonCount> 49){
            WinMsg.text = "You Win!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(BoxCount + AppleCount + CylinderCount >59){
            WinMsg.text = "You Win!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(BoxCount + BrownBoxCount + OrangeBoxCount + RedBoxCount + YellowBoxCount + CylinderCount > 84){
            WinMsg.text = "You Win!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        if(YellowBoxCount + CylinderCount + KiwiCount > 74){
            WinMsg.text = "You Win!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(BoxCount + YellowBoxCount + BrownBoxCount + RedBoxCount + OrangeBoxCount + WatermelonCount 
        + KiwiCount + AppleCount + OrangeCount + LemonCount > 94){
            WinMsg.text = "Congraduations you've won the game!";
            SceneManager.LoadScene(5);
        }
        else if(other.gameObject.tag == "Bomb"){
            BoxCount = 0;
            WatermelonCount = 0;
            OrangeBoxCount = 0;
            OrangeCount= 0 ;
            BrownBoxCount =0;
            KiwiCount = 0;
            RedBoxCount = 0;
            YellowBoxCount = 0;
            CylinderCount = 0;
            AppleCount = 0;
            LemonCount = 0;

        }

    }

}
