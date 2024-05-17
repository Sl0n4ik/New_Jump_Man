using Scripts.Attributes;
using Scripts.Modeles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Components.SceneManagement
{
    public class ExitNextLevel : MonoBehaviour
    {
        [SerializeField] [SceneName] private string _sceneName;

        public void ExitLevel()
        {
            var session = FindObjectOfType<GameSession>();
            session?.Save();
            SceneManager.LoadScene(_sceneName);
        }
    }
}