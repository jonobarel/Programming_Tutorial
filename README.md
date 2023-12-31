# Programming_Tutorial

This Unity project is meant to serve as an introduction to programming concept by provided learners with a simple block of code, and an interactive view that they can easily associate with said code.

By looking at the contents of the main class (`IntroToProgramming`), learners can associate concepts like `int` and `float` with visible representations, as well as function calls and variables.

![Video demonstrating the unity project running](video_preview_2.gif)

While interacting with the game, the learner can follow along with the code:

```C#
public class IntroToProgramming : MonoBehaviour
{
        //These are the variables you see on screen.
        //They are "declared" in this section - that means we are announcing to the computer that it must allocate memory to store these values, and that they will be accessible by name.
        [SerializeField] 
        private int numberOfObjectsToCreate = 1;
        
        [SerializeField] 
        private float objectScale = 1;
        
        [SerializeField] 
        private Color modelColor = Color.white;

        [SerializeField] 
        private GameObject model;

        [SerializeField] 
        private int numberOfObjectsInScene = 0;

        [SerializeField] private Transform spawnPoint;

        //This is a method! It makes our class do something.
        //Can you tell what this method does?
        public void CreateButtonAction()
        {
                numberOfObjectsInScene = numberOfObjectsInScene + CreateObjects(numberOfObjectsToCreate, model, modelColor, objectScale);
        }


        //This is another method. It has a return type (int), meaning that after it runs, it will return a value to you. You'll need to decide if you want to do something with it.
        //This method also accepts parameters: can you tell what they're for?
        private int CreateObjects(int num, GameObject model, Color color, float scale)
        {
            for (int i = 0; i < num; i++)
            {
                GameObject item = Instantiate(model, spawnPoint.transform.position+Vector3.up*i, RandomQuaternion());
                SetColorAndScale(item, color, scale);
            }

            return num;
        }

        //Here's another method. It doesn't return a value. What does it do?
        private void SetColorAndScale(GameObject item, Color color, float scale)
        {
            ApplyColor(item, color);
            item.AddComponent<Rigidbody>();
            item.transform.localScale = Vector3.one * scale;
            ApplyLayer(item, "Default");
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
```

Licenses:

DOTWeen licensed under the [DOTween License](http://dotween.demigiant.com/license.php)

Chess set by [Esteban Lopez via OpenGameArt.org](https://opengameart.org/content/chess-set) licensed [CC-By](http://creativecommons.org/licenses/by/3.0/)

Car Kit and Food Kit by [Kenney](https://kenney.nl)

