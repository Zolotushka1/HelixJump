using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private StartPlatform _spawnPlatform;
    [SerializeField] private Platform[] _mainPlatforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionalScale = 0.5f;

    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;
    

    public void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;
        
        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform.parent);
        
        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_mainPlatforms[UnityEngine.Random.Range(0, _mainPlatforms.Length)], ref spawnPosition, beam.transform.parent);
        }
        
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform.parent);
        
        var cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BallTracking>();
        cam.Check();
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360),0), parent);
        spawnPosition.y -= 1;
    }

    public void LevelCounter()
    {
        _levelCount += 1;
    }
}
