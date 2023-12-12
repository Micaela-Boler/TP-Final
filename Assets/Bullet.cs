using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _bulletRB;
    [SerializeField] float speed;



    void Awake()
    {
        _bulletRB = GetComponent<Rigidbody2D>();
    }

    

    public void LaunchBullet(Vector2 direction)
    {
        _bulletRB.velocity = direction * speed;

        Destroy(gameObject, 3f);
    }



    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
