using UnityEngine;

public class UIShake : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;
    [SerializeField] private float _speed = 5f;

    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.localPosition;
    }

    private void Update()
    {
        float x = Mathf.Cos(Time.time * _speed) * _radius;
        float y = Mathf.Cos(Time.time * _speed) + _radius;

        transform.localPosition = _initialPosition + new Vector3(x, y, 0);

    }
}
