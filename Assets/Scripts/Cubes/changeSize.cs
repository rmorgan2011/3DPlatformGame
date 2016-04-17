using UnityEngine;
using System.Collections;

public class changeSize : MonoBehaviour {
    public float scaleRate = .006f;
    public float minScale = .1f;
    public float maxScale =.9f;

    public bool scaleOrMove;

    void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate;
    }

    void main()
    {
         //if we exceed the defined range then correct the sign of scaleRate.
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate();
    }
    
    void Update()
    {
       
        main();
  
    }

}
