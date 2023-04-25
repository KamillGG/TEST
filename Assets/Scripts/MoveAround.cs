using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MoveAround : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float mouseSensitivity = 3.0f;
    private float rotationy;
    private float rotationx;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distanceFromTarget = 3.0f;
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Cursor.visible = false;
        float mousex = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationy +=mousex;
        rotationx -=mousey;
        rotationx = Mathf.Clamp(rotationx,5,40);
        transform.localEulerAngles = new Vector3(rotationx,rotationy,0);
        transform.position = target.position - transform.forward * distanceFromTarget;
        }
        else{
            Cursor.visible = true;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel") * mouseSensitivity;
        if(scroll != 0.0f){
            distanceFromTarget = Mathf.Clamp(distanceFromTarget,2f,10f);
            if(distanceFromTarget<1.4f){
                distanceFromTarget=1.4f;
            }
            distanceFromTarget -=scroll;
            transform.position = target.position - transform.forward *distanceFromTarget;
        }
    }
    
}
