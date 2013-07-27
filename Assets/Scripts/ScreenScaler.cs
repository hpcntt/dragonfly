using UnityEngine;
using System.Collections;
 
public class ScreenScaler : MonoBehaviour
{
    public float baseWidth = 640f;
	public float baseHeight = 960f;
    public bool aspectFit = false;
	
	private Vector3 originPos;
	
	private void Awake()
	{
		originPos = transform.localPosition;
		transform.localPosition = new Vector3(4000, 0, 0);
	}
     
    private void Update()
	{
        Vector3 ratio = new Vector3(
            Screen.width / baseWidth,
            Screen.height / baseHeight,
            1.0f
        );
         
        if(aspectFit){
            if(ratio.x > ratio.y){ ratio.x = ratio.y; }
            else if(ratio.y > ratio.x){ ratio.y = ratio.x; }
        }
         
        transform.localScale = ratio;	
		transform.localPosition = originPos;
		
		enabled = false;
    }
}