using Scripts.Components.Controllers;
using Scripts.Components.UI.Widgets;
using Scripts.Modeles.Definitions;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Spawners
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField] private Transform _highiest;
        [SerializeField] private float _distance;
        [SerializeField] private int _countForStart;
        [SerializeField] private NameFileSave _save;
        [SerializeField] private TagPrefab _tagPrefab;
        [SerializeField] private MapDefinition _mapDefinition;
        [SerializeField] private GameObject _prefabForStartSpawn;
        [SerializeField] private bool _isLoaderMap;
        [SerializeField] private UnityEvent<GameObject> _actionForNewObject;

        private void Awake()
        {
            if (_isLoaderMap) LoadMap();
            
            for(int i = 0; i < _countForStart; i++)
            {
                var newObject = Instantiate(_prefabForStartSpawn);
                Respawn(newObject);
                _actionForNewObject?.Invoke(newObject);
            }
        }

        private void LoadMap()
        {
            var save = _save.ToString();
            if (PlayerPrefs.HasKey(save))
            {
                var nameMap = PlayerPrefs.GetString(save);
                var map = _mapDefinition.GetElement(nameMap);
                _prefabForStartSpawn = map.GetPrefab(_tagPrefab);
            }
            else
            {
                var map = _mapDefinition.GetBaseElement();
                _prefabForStartSpawn = map.GetPrefab(_tagPrefab);
            }
        }

        public void Respawn(GameObject target)
        {
            if(target.TryGetComponent(out SwitchActivate activator))
            {
                activator.Switch();
            }
            else
            {
                return;
            }

            var newPositionY = _highiest.position.y + _distance;
            target.transform.position = new Vector3(_highiest.position.x, newPositionY, target.transform.position.z);
            _highiest = target.transform;
        }
    }
}