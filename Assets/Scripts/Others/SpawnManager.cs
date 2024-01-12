using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _object; // Обьекты которые входят в спавнер
    [HideInInspector] private float RandX; // рандомное расположение по Х спавнер
    [SerializeField] float RandX1; // рандомное расположение по Х спавнер для ввода 1
    [SerializeField] float RandX2; // рандомное расположение по Х спавнер для ввода 2
    [HideInInspector] private float YPos; // расположение по Y спавнер
    [SerializeField] float YPos1;
    [SerializeField] float YPos2;
    [HideInInspector] private Vector3 _whereToSpawn; // Где спавнить(пока я сам не выяснил что это такое)
    public float spawnRate = 2f; // раз в какое время спавнить
    [SerializeField] private float nextSpawn = 0.0f; // показывает просто время когда обновится спавн
    [SerializeField] bool isGameStarted = false;

    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    private void Update()
    {
        if (Time.time > nextSpawn && isGameStarted == true)// && StarTime < 10f)
        {
            nextSpawn = Time.time + spawnRate;
            RandX = Random.Range(RandX1, RandX2);
            YPos = Random.Range(YPos1, YPos2);
            _whereToSpawn = new Vector3(RandX, YPos, 0);
            Instantiate(_object[Random.Range(0, _object.Length)], _whereToSpawn, Quaternion.identity);
        }
    }
    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3);

        isGameStarted = true;
    }
}
