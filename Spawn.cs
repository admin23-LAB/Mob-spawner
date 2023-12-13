using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject entityPrefab; // ������ ��������, ������� �� ������ ����������
    public ParticleSystem particleSystemPrefab; // ������ ������� ������
    public float spawnDistance = 5f; // ����������, ��� ������� �������� �����
    public Transform player; // ������ �� ������ ������

    private ParticleSystem particleSystemInstance;

    void Start()
    {
        // ������� ��������� ������� ������
        particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
        particleSystemInstance.Stop(); // ������������� ������� ������ ��� ������
    }

    void Update()
    {
        if (player != null)
        {
            // ��������� ���������� ����� ���� �������� � �������
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // ���� ����� ������, ������� �������� � �������� �������
            if (distanceToPlayer < spawnDistance)
            {
                SpawnEntity();
                ActivateParticles();
            }
            else
            {
                // ���� ����� ������, ��������� �������
                DeactivateParticles();
            }
        }
    }

    void SpawnEntity()
    {
        // ������� �������� �� ������� ������� �������
        Instantiate(entityPrefab, transform.position, Quaternion.identity);

        // ����������� ����� �������� �������������� �������� ����� ������
    }

    void ActivateParticles()
    {
        // �������� �������
        if (!particleSystemInstance.isPlaying)
        {
            particleSystemInstance.Play();
        }
    }

    void DeactivateParticles()
    {
        // ��������� �������
        if (particleSystemInstance.isPlaying)
        {
            particleSystemInstance.Stop();
        }
    }
}