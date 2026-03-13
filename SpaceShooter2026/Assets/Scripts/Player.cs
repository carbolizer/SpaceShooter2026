using UnityEngine;

public class Player : MonoBehaviour {
    // set in inspector
    public float speed = 0.1f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private SpaceShooterInputActions inputActions;
    private const float Y_LIMIT = 4.6f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        inputActions = new();
        inputActions.Enable();
        inputActions.Standard.Enable();
    }

    // Update is called once per frame
    void Update() {

        if (inputActions.Standard.Fire.WasPressedThisFrame())
        {
            GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }

        if (inputActions.Standard.MoveUp.WasPressedThisFrame()) {
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        else if (inputActions.Standard.MoveDown.IsPressed()) {
            this.transform.Translate(Vector3.down * speed * Time.deltaTime);
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
