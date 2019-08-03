using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    public float InitialSpeed;

    public float FocusMaxDuration;
    private float FocusLeft;

    private Vector2 AxisSpeed;
    private FocusTime ft;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ft = FindObjectOfType<FocusTime>();

        FocusLeft = FocusMaxDuration;
    }

    public void SetAxisSpeed(Vector3 mousePosition) {
        Vector3 difference = mousePosition - transform.position;
        AxisSpeed = difference.normalized * InitialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sideSpeed = Vector2.zero;

        // if there is some focus left and a key is pressed
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && FocusLeft > 0) {
            sideSpeed = Vector2.Perpendicular(AxisSpeed);
            
            // to to opposite if right arrow
            if(Input.GetKey(KeyCode.RightArrow))
                sideSpeed *= -1;

            FocusLeft = Mathf.Max(0, FocusLeft - Time.deltaTime);
            Debug.Log(FocusLeft);
        }

        // reverse when y axis down
        if(!sideSpeed.Equals(Vector2.zero) && AxisSpeed.y < 0) {
            sideSpeed = Vector2.Perpendicular(Vector2.Perpendicular(sideSpeed));
        }
        
        // set speed
        rb.velocity = AxisSpeed + sideSpeed;
        ft.UpdatePercent(FocusLeft / (FocusMaxDuration + 0.0000001f));
        Debug.Log(FocusLeft);
    }
}
