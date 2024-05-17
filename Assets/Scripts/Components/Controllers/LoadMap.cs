using Scripts.Components.UI.Widgets;
using Scripts.Modeles.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Components.Controllers
{
    public class LoadMap : MonoBehaviour
    {
        [SerializeField] private NameFileSave _save;
        [SerializeField] private MapDefinition _mapDef;
        [SerializeField] private TagPrefab _tagPrefab;
        [SerializeField] private bool _isLoadChild;

        private void Awake()
        {
            var name = PlayerPrefs.GetString(_save.ToString());
            var map = string.IsNullOrEmpty(name) ? _mapDef.GetBaseElement() : _mapDef.GetElement(name);

            var prefab = map.GetPrefab(_tagPrefab);
            if (_isLoadChild)
            {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
            }
            else
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
