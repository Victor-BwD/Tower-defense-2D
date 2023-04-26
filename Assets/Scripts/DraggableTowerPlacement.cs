using UnityEngine;

public class DraggableTowerPlacement : MonoBehaviour
{
    [SerializeField] private LayerMask towerSpotLayer;
    [SerializeField] private LayerMask placedTowerLayer;
    [SerializeField] private float snapDistance = 0.1f;
    
    private Color invalidPlacementColor = Color.red;
    private Color validPlacementColor = Color.green;
    private BoxCollider2D _collider2D;
    private bool _isDragging;
    private Vector3 _startPosition;
    private Vector3 _mouseOffset;
    private SpriteRenderer _spriteRenderer;
    private bool _canPlaceTurret;
    private Vector2 _maxPosition;
    private bool _isMoved = false;
    
    public bool IsDragging => _isDragging;

    private void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _canPlaceTurret = false;
    }

    private void Update()
    {
        if (_isDragging)
        {
            // Atualiza a posição da torre enquanto arrasta
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _mouseOffset;
            transform.position = new Vector3(newPosition.x, newPosition.y, _startPosition.z);
            
            _canPlaceTurret = CheckValidPlacement();

            if (_canPlaceTurret)
            {
                _spriteRenderer.color = validPlacementColor;
            }
            else
            {
                _spriteRenderer.color = invalidPlacementColor;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_canPlaceTurret)
                {
                    transform.position = SnapToPosition(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                else
                {
                    transform.position = _startPosition;
                }
                _isDragging = false;
             
            }
        }
        else
        {
            _spriteRenderer.color = Color.white;
        }
    }

    private bool CheckValidPlacement()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, _collider2D.size, 0, towerSpotLayer);
        
        _isMoved = true;
        
        return hitColliders.Length > 0;
    }

    private Vector3 SnapToPosition(Vector3 position, Vector3 mousePosition)
    {
        // Pega o ponto de torre mais próximo que colide com o collider da torre e retorna sua posição
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, _collider2D.size, 0f, towerSpotLayer);

        Collider2D closestCollider = null;
        float closestDistance = float.MaxValue;

        foreach (Collider2D col in colliders)
        {
            if (col.OverlapPoint(position))
            {
                float distance = Vector2.Distance(position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCollider = col;
                }
            }
        }

        if (!ReferenceEquals(closestCollider, null))
        {
            float distanceToMouse = Vector3.Distance(mousePosition, closestCollider.transform.position);
            if (distanceToMouse <= snapDistance)
            {
                return closestCollider.transform.position;
            }
        }

        // Retorna a posição onde o botão do mouse foi solto
        return position;
    }

    public void HandleMouseDown()
    {
        if (_isMoved) return;
        
        _isDragging = true;
        _startPosition = transform.position;
        _mouseOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    public void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;
    }
}
