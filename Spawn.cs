using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject entityPrefab; // Префаб сущности, которую вы хотите заспаунить
    public ParticleSystem particleSystemPrefab; // Префаб системы частиц
    public float spawnDistance = 5f; // Расстояние, при котором начнется спаун
    public Transform player; // Ссылка на объект игрока

    private ParticleSystem particleSystemInstance;

    void Start()
    {
        // Создаем экземпляр системы частиц
        particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
        particleSystemInstance.Stop(); // Останавливаем систему частиц при старте
    }

    void Update()
    {
        if (player != null)
        {
            // Вычисляем расстояние между этим объектом и игроком
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Если игрок близко, спауним сущность и включаем частицы
            if (distanceToPlayer < spawnDistance)
            {
                SpawnEntity();
                ActivateParticles();
            }
            else
            {
                // Если игрок далеко, выключаем частицы
                DeactivateParticles();
            }
        }
    }

    void SpawnEntity()
    {
        // Спауним сущность на текущей позиции объекта
        Instantiate(entityPrefab, transform.position, Quaternion.identity);

        // Опционально можно добавить дополнительные действия после спауна
    }

    void ActivateParticles()
    {
        // Включаем частицы
        if (!particleSystemInstance.isPlaying)
        {
            particleSystemInstance.Play();
        }
    }

    void DeactivateParticles()
    {
        // Выключаем частицы
        if (particleSystemInstance.isPlaying)
        {
            particleSystemInstance.Stop();
        }
    }
}