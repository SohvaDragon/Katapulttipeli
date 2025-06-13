using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class katapultti : MonoBehaviour
{
    // ammu pupu
    public Transform launchPosition;
    // ammu pupu
    public Rigidbody characterRb;

    public explodebunny Explodebunny;
    
    public Animator armAnimator;

    public Transform turret;

    public float launchForce = 15f;
    public float verticalLift = 0.5f;
    public float rotationSpeed;
    public int bunniesleft = 10;

    public Slider Slider;
    public TextMeshProUGUI forcetext;
    public Slider Slider1;
    public TextMeshProUGUI forcetext1;
    public TextMeshProUGUI bunnies;

    private Quaternion intialBunnyRotation;

    // ammu pupu
    void Start()
    {
       intialBunnyRotation = characterRb.transform.rotation;
    }

    // ammu pupu
    void Update()
    {
        UpdateUI();
         if (Input.GetKeyDown(KeyCode.Escape))
         {
            SceneManager.LoadScene("mainmenu");
         }
         if  (Input.GetKeyDown(KeyCode.Space))
        {
            launch();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetcatapult();
        }
        HandleRotation();
    }
    void UpdateUI()
    {
        launchForce = Slider.value;
        verticalLift = Slider1.value;
        forcetext.text = "Force: " + Mathf.RoundToInt(launchForce);
        forcetext1.text = "Lift: " + verticalLift.ToString("n2");
        bunnies.text = "bunnies: " + bunniesleft;
    }
     //ammu pupu
    void launch()
    {
        characterRb.isKinematic = false;
        characterRb.transform.parent = null;
        Vector3 launchDirection = turret.forward + Vector3.up * verticalLift;
        characterRb.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
        armAnimator.SetTrigger("Launch");
       
    }

    void resetcatapult()
    {
        if (bunniesleft == 0) return;
        bunniesleft -= 1;
        characterRb.isKinematic = true;
        characterRb.transform.parent = launchPosition;
        characterRb.transform.position = launchPosition.position;
        characterRb.transform.rotation = intialBunnyRotation;

        Explodebunny.hasExploded = false;
        Explodebunny.UpdateButton();
    }

    void HandleRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        turret.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);
        if (characterRb.isKinematic)
        {
            characterRb.transform.position = launchPosition.position;
            characterRb.transform.rotation = launchPosition.rotation * intialBunnyRotation;

        }
    }
}