using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Components.SceneManagement
{
    public class ReloadLevel : MonoBehaviour
    {
        public void Reload()
        {
            var scane = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scane.name);
        }
    }
}