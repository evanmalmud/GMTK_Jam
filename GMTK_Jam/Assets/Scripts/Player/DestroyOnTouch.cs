using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DestroyOnTouch : MonoBehaviour
{

    [TagSelector] public string[] TagFilterArray;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (string tag in TagFilterArray)
        {
            if (other.gameObject.tag.Equals(tag))
            {
                // Destroy
                Destroy(other.gameObject);
            }
        }
    }
}
