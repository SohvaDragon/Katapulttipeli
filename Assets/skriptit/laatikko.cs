using UnityEngine;

public class laatikko : MonoBehaviour
{
    private bool hasScored = false;
    private int score = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasScored && collision.gameObject.CompareTag("ground"))
        {
            hasScored = true;
            scoremanager.Instance.AddScore(10);
          
        }
    }
}