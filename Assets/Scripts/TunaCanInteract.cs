using UnityEngine;

public class TunaCanInteract : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddTrust(0.5f);
            Destroy(gameObject); // Destroy the tuna can after interaction
            // Here you would trigger the dialogue or interaction logic for the tuna can
        }
    }
}
