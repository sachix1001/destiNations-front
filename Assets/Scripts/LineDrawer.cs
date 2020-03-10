using UnityEngine;
using Vectrosity;

public class LineDrawer : MonoBehaviour
{
    void Start()
    {
        VectorLine.SetLine3D(Color.white, transform.position, transform.forward * 5.0f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
