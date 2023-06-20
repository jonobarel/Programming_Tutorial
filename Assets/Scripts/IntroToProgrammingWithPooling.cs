using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace DefaultNamespace
{
    public class IntroToProgrammingWithPooling : IntroToProgramming
    {
        private ObjectPool<ModelSelector> _pool;
        private GameObject _poolContainer;
        [SerializeField] private int defaultPoolSize = 10;
        [SerializeField] private int maxPoolSize = 20;
        
        protected override GameObject RequestInstance(Vector3 position, Quaternion rotation)
        {
            ModelSelector instance =  _pool.Get();
            ResetPhysics(instance.Rigidbody, position, rotation);
            return instance.gameObject;
        }

        void Start()
        {
            _poolContainer = new GameObject
            {
                name = "PoolContainer",
                transform =
                {
                    parent = gameObject.transform
                }
            };
            _pool = new ObjectPool<ModelSelector>(CreateInstance, GetInstance, ReleaseInstance, OnDestroyInstance, true,
                defaultPoolSize, maxPoolSize);
        }

        private void ResetPhysics(Rigidbody rb, Vector3 position, Quaternion rotation)
        {
            rb.MovePosition(position);
            rb.MoveRotation(rotation);
            rb.velocity = Vector3.zero;
        }

        private void OnDestroyInstance(ModelSelector instance)
        {
            Destroy(instance.gameObject);        
        }

        private void ReleaseInstance(ModelSelector instance)
        {
            instance.Rigidbody.velocity = Vector3.zero;
            instance.gameObject.SetActive(false);
        }

        ModelSelector CreateInstance()
        {
            GameObject instance = Instantiate(Model.gameObject, _poolContainer.transform);
            instance.GetComponent<PooledObject>().Pool = _pool;
            return instance.GetComponent<ModelSelector>();
        }

        void GetInstance(ModelSelector instance)
        {
            instance.gameObject.SetActive(true);
        }
        
        
        
        
    }
}