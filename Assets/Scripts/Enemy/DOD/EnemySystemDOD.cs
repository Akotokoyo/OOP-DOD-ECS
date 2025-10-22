using UnityEngine;
using UnityEngine.UIElements;

public class EnemySystemDOD
{
    void UpdateAll(ref EnemyDataDOD data, Vector3 playerPos, float deltaTime, int dataIndex)
    {
        for (int i = 0; i < data.healths.Length; i++)
        {
            if (!data.areActive[i])
                continue;


            if (data.healths[i] <= 0)
            {
                data.areActive[i] = false;
                continue;
            }
        }

        Vector3 dir = (playerPos - data.positions[dataIndex]).normalized;
        data.positions[dataIndex] += data.speeds[dataIndex] * deltaTime * dir;
    }
}
