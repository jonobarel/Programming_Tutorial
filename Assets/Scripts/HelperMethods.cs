using UnityEngine;

    public static class HelperMethods
    {
        /// <summary>
        /// Recursively set object and all its children's layer to layerName
        /// </summary>
        /// <param name="item">GameObject to apply layer to</param>
        /// <param name="layerName">name identifier of layer to apply to GameObject</param>
        public static void ApplyLayer(GameObject item, string layerName)
        {
            
            item.layer = LayerMask.NameToLayer(layerName);
            foreach (Transform child in item.transform)
            {
                if (child.childCount > 0)
                {
                    ApplyLayer(child.gameObject, layerName);
                }
                else
                {
                    child.gameObject.layer = LayerMask.NameToLayer(layerName);
                }
                
            }
        }        
        
        public static Quaternion RandomQuaternion()
        {
            return new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f),1);
        }
    }