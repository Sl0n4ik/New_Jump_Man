using UnityEngine;

namespace Scripts.Components.Movements.RandomMove
{
    public class RandomPositionAcisX : MonoBehaviour
    {
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;

        public void MoveForX(GameObject target)
        {

            var newPositionX = Random.Range(_left.position.x, _right.position.x);
            target.transform.position = new Vector3(newPositionX, target.transform.position.y, target.transform.position.z);
        }
    }
}