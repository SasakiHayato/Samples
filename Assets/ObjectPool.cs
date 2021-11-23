using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public interface IPool
    {
        void Create();
        void Use();
        void Delete();
    }

    public class ObjectPool<T> : MonoBehaviour where T : IPool
    {
        T GetT;

        private void Awake()
        {
            GetT.Create();
        }

        public void Use()
        {
            GetT.Use();
        }
    }
}
