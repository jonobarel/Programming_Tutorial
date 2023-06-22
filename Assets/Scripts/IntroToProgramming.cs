using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;



public class IntroToProgramming : MonoBehaviour
{
        //These are the variables you see on screen.
        //They are "declared" in this section - that means we are announcing to the computer that it must allocate
        //memory to store these values, and that they will be accessible by name.
        [SerializeField] 
        private int numberOfInstancesToCreate = 1;
        
        [SerializeField] 
        private float instanceScale = 1;
        
        [SerializeField] 
        private Color modelColor = Color.white;

        [SerializeField] 
        private GameObject model;

        [SerializeField] 
        private int numberOfInstancesInScene = 0;

        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] public string selectedModel;
        
        /// <summary>
        /// This is a method! It makes our class do something.
        /// Can you tell what this method does? 
        /// </summary>
        public void CreateButtonAction()
        {
                numberOfInstancesInScene = numberOfInstancesInScene + CreateObjects(numberOfInstancesToCreate, selectedModel, modelColor, instanceScale);
        }

        /// <summary>
        ///This is another method. It has a return type (int), meaning that after it runs, it will return a value to you.
        ///You'll need to decide if you want to do something with it.
        ///This method also accepts parameters: can you tell what they're for? 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="modelName"></param>
        /// <param name="color"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
    
        private int CreateObjects(int num, string modelName, Color color, float scale)
        {
            for (int i = 0; i < num; i++)
            {
                GameObject item = RequestInstance(spawnPoint.transform.position+Vector3.up*i, HelperMethods.RandomQuaternion());
                item.GetComponent<ModelSelector>().SelectedModel = modelName;
                SetColorAndScale(item, color, scale);
            }
            return num;
        }

        protected virtual GameObject RequestInstance(Vector3 position, Quaternion rotation)
        {
            GameObject instance = Instantiate(Model, position, rotation);
            return instance;
        }

        
        /// <summary>
        /// Here's another method. It doesn't return a value. What does it do?
        /// </summary>
        /// <param name="item"></param>
        /// <param name="color"></param>
        /// <param name="scale"></param>
        private void SetColorAndScale(GameObject item, Color color, float scale)
        {
            ApplyColor(item, color);
            item.transform.localScale = Vector3.one * scale;
            HelperMethods.ApplyLayer(item, "Default");
        }

        void ApplyColor(GameObject obj, Color col)
        {
            MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mr in renderers)
            {
                foreach (Material mat in mr.materials)
                {
                    mat.color = col;
                }
            }
        }


        #region AccessorMethods
        public int NumberOfInstancesToCreate
        {
            set => numberOfInstancesToCreate = value;
            get => numberOfInstancesToCreate;
        }

        public Color ModelColor
        {
            get => modelColor;
            set => modelColor = value;
        }

        public float InstanceScale
        {
            get => instanceScale;
            set => instanceScale = value;
        }

        public GameObject Model
        {
            set => model = value;
            get => model;
        }
        
        #endregion

}
