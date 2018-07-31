using UnityEngine;

namespace Scripts.Game.ScreenWord
{
    class Capture_ts:MonoBehaviour
    {
        public Vector3 toward;
        float delay;
        public bool isDestory;
        private void Start()
        {
            isDestory = false;
            delay = Random.Range(2, 4);
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, toward, delay);
            if (isDestory)
            {
                delay = Random.Range(2, 4);
                Destroy(gameObject, delay);
                isDestory = false;
            }
        }

        
    }
}
