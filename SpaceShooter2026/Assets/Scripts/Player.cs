using UnityEngine;

public class Player : MonoBehaviour {   
    private SpaceShooterInputActions inputActions;
    public float speed = 0.1f;
    private const float Y_LIMIT = 4.6f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        inputActions = new();
        inputActions.Enable();
        inputActions.Standard.Enable();
    }

    // Update is called once per frame
    void Update() {
        if (inputActions.Standard.MoveUp.WasPressedThisFrame()) {
            this.transform.Translate(new Vector3(0, 0.1f));
            this.transform.Translate(Vector3.up * speed);
        }

        else if (inputActions.Standard.MoveDown.IsPressed()) {
            this.transform.Translate(Vector3.down * speed);
        }
        if (this.transform.position.y > Y_LIMIT)
        {
            this.transform.position = new Vector3(transform.position.x, Y_LIMIT);
        }
        else if (this.transform.position.y < -Y_LIMIT) {
            this.transform.position = new Vector3(transform.position.x, -Y_LIMIT);
        }
    }
}
