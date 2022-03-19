using System.Collections;
using UnityEngine;
using Lean.Pool;

public class Cube : MonoBehaviour
{
    private float _speed;
    
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
    }

    public void TakeValues(float speed, float range)
    {
        _speed = speed;
        float destroyTime = range / speed;
        StartCoroutine(DeactivateCube(destroyTime));
    }

    private IEnumerator DeactivateCube( float delay)
    {
        yield return new WaitForSeconds(delay);
        LeanPool.Despawn(this);
    }
}
