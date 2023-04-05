using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject destination;
    private float _originalSpeed;
    private float _slowDuration = 5f;
    private float _slowStartTime;
    private bool _isSlowed;
    
    [SerializeField] private float speed;

    private void Start()
    {
        destination = GameObject.Find("Goal");
        _originalSpeed = speed;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);

        if (transform.position == destination.transform.position)
        {
            Destroy(gameObject, 1f);
        }
        
        if (_slowStartTime != 0 && Time.time - _slowStartTime >= _slowDuration) // Verifica se o tempo do slow expirou
        {
            speed = _originalSpeed; // Restaura a velocidade original do inimigo
            _slowStartTime = 0; // Reseta o tempo de início do slow
        }
    }
    
    public void ApplySlow(float value)
    {
        if (_isSlowed) return;
        
        _slowStartTime = Time.time;
        speed /= value;
        _isSlowed = true;
    }

    
}
