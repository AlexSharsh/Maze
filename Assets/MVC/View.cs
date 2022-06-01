using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class View : MonoBehaviour
    {
        [SerializeField] public Transform _transform;
        [SerializeField] public Collider _collider;
        [SerializeField] public Rigidbody _rb;

        public Action<Collider, int, Transform> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            Collider LevelObject = other;

            OnLevelObjectContact?.Invoke(LevelObject, 12, LevelObject.transform);
        }
    }
}
