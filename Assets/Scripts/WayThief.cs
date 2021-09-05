using UnityEngine;

public class WayThief : MonoBehaviour
{
    [SerializeField] Transform _way;
    [SerializeField] float _speed;

    private Transform[] _points;
    private SpriteRenderer _sprite;
    private int _currentPoint;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _points = new Transform[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
        {
            _points[i] = _way.GetChild(i);
        }    
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        ShowDirectionAnimation(target);
    }

    private void ShowDirectionAnimation(Transform target)
    {
        if (transform.position.x > target.position.x)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
    }
}
