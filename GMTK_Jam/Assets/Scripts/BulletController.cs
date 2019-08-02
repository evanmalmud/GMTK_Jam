using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    public float InitialSpeed;

    public float FocusMaxDuration = 2;

    private Vector2 AxisSpeed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetAxisSpeed(Vector3 mousePosition) {
        Vector3 difference = mousePosition - transform.position;
        AxisSpeed = difference.normalized * InitialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sideSpeed = Vector2.zero;

        if(!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow)) {
            if(Input.GetKey(KeyCode.LeftArrow)) {
                sideSpeed = Vector2.Perpendicular(AxisSpeed);
            } else if(Input.GetKey(KeyCode.RightArrow)) {
                sideSpeed = -Vector2.Perpendicular(AxisSpeed);
            }

            if(!sideSpeed.Equals(Vector2.zero) && AxisSpeed.y < 0) {
                sideSpeed = Vector2.Perpendicular(Vector2.Perpendicular(sideSpeed));
            }
        }
        
        rb.velocity = AxisSpeed + sideSpeed;
    }
}
