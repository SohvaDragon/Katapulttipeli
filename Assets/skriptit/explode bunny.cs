using UnityEngine;
using UnityEngine.UI;
public class explodebunny : MonoBehaviour
{
    public float explosionRadius = 80f;
    public float explosionforce = 65f;
    public ParticleSystem particleSystem;

    public Button explodeButton;
    public bool hasExploded = false;
   public void Explode()
   {
        if (hasExploded) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb == null || rb.isKinematic) continue;

            Vector3 direction = transform.position - rb.transform.position;
            rb.AddForce(direction.normalized * explosionforce, ForceMode.Impulse);
        }
        particleSystem.Play();

        hasExploded = true;
        UpdateButton();
   }
   public void UpdateButton()
   {
        explodeButton.interactable = !hasExploded;
   }
}