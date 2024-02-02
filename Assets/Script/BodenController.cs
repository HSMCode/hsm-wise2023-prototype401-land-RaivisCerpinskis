using UnityEngine;

public class BodenController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Igel"))
        {
            IgelController igelController = collision.gameObject.GetComponent<IgelController>();

            
            if (igelController != null)
            {
                igelController.ResetJumps();
            }
        }
    }
}
