using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private float _originalSpeed;
    private float _slowDuration = 5f;
    private float _slowStartTime;
    private bool _isSlowed;
    
    private Transform target;
    private int wavePointIndex = 0;
    
    private void Start()
    {
        target = Waypoints.points[0];
        _originalSpeed = speed;
    }

    private void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextPosition();
        }        
        
        if (_slowStartTime != 0 && Time.time - _slowStartTime >= _slowDuration) // Verifica se o tempo do slow expirou
        {
            speed = _originalSpeed; // Restaura a velocidade original do inimigo
            _slowStartTime = 0; // Reseta o tempo de início do slow
        }
    }
    
    private void GetNextPosition()
    {
        if (wavePointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        
        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }
    
    public void ApplySlow(float value)
    {
        if (_isSlowed) return;
        
        _slowStartTime = Time.time;
        speed /= value;
        _isSlowed = true;
    }
}
