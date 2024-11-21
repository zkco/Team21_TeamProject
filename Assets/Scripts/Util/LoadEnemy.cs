using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnemy : MonoBehaviour
{
    public int stage;
    private void Start()
    {
        Managers.PlayerManager.EnemyPool.DeSpawnAllEnemy();
        switch (SceneManager.GetActiveScene().ToString())
        {
            case "Stage1": stage = 1; break;
            case "Stage2": stage = 2; break;
            case "Stage3": stage = 3; break;
            default: return;
        }

        Managers.PlayerManager.EnemyPool.SpawnWithStagePosition(stage);
    }
}