using UnityEngine;
using Lean.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _cubeSpeed = 5f;
    private float _spawnDelay = 5f;
    private float _moveRange = 30f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnDelay)
        {
            _timer = 0;

            Cube newCube = LeanPool.Spawn(_cubePrefab, transform.position, transform.rotation);
            newCube.TakeValues(_cubeSpeed, _moveRange);
        }
    }


    public void SetCubeSpeed(string value)
    {
        float speed;
        float defaultSpeed = 5;
        try
        {
            speed = float.Parse(value);
        }
        catch (System.Exception)
        {
            speed = defaultSpeed;
            Debug.LogWarning("”становленна скорость по умолчанию");
        }

        _cubeSpeed = speed;
    }
    public void SetMoveRange(string value)
    {
        float range;
        float defaultRange = 30f;

        try
        {
            range = float.Parse(value);
        }
        catch (System.Exception)
        {
            range = defaultRange;
            Debug.LogWarning("–ассто€ние установленно по умолчанию");
        }

        _moveRange = range;
    }
    public void SetSpownDelay(string value)
    {
        float delay;
        float defaultDelay = 5f;

        try
        {
            delay = float.Parse(value);
        }
        catch (System.Exception)
        {
            delay = defaultDelay;
            Debug.LogWarning("¬рем€ задержки установленно по умолчанию");
        }

        _spawnDelay = delay;
    }

    //врем€ спавна и рассто€ние, которое должен пройти куб.скорость куба тоже в текстовом поле
    //использовать пул обьектов
}
