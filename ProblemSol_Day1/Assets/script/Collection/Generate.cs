using UnityEngine;
using UnityEngine.Pool;

public class Generate : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject StartObj;
    public int Capacity = 10;
    public Queue<GameObject> Ammo = new Queue<GameObject>();

    private int activeBullet;
    private Transform spawnPoint;


    void Start()
    {
        spawnPoint = StartObj.transform;

        for (int i = 0; i < Capacity; i++)
        {
            // 오브젝트 10개 미리 생성 후 비활성화
            GameObject bullet = Instantiate(BulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.SetActive(false); 
            Ammo.Enqueue(bullet); 
        }
    }

    void Update()
    {
        if (activeBullet <= Capacity)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // 마우스를 클릭했을때 오브젝트 활성화
                GameObject bullet = Ammo.Dequeue();
                bullet.SetActive(true);
                activeBullet++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        // 총알을 다시 큐에 넣음
        GameObject bullet = Instantiate(BulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.SetActive(false);
        Ammo.Enqueue(bullet);
    }
}
