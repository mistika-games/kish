using UnityEngine;

public class CameraFollower : MonoBehaviour {

	public GameObject obj_Player;

	public float xMargin = 2f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 2f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 2f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 2f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.

    public float cameraModeFov = 80;
    public float playModeFov = 60;


    private Transform player;

	float targetX;
	float targetY;


	void Awake ()
	{
		//.....Setting up the reference.
		player = obj_Player.transform;

		targetX = transform.position.x;
		targetY = transform.position.y;
	}

	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.

       
						return Mathf.Abs (transform.position.x - player.position.x) > xMargin;
				
	}
		
	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}


    void LateUpdate()
    {

	    if (Input.GetKey(KeyCode.LeftShift) && player != null)
        {

            TrackMouseView();

        }
        else
        {
            TrackPlayer();
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && player != null)
        {
            
        }
        else
        {
            foreach (var item in GetComponentsInChildren<Camera>())
            {
                item.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 8.52f, 0.09f);
                item.fieldOfView = Mathf.Lerp(item.fieldOfView, playModeFov, 0.09f);
            }
            //Camera.
            
        }
    }

	void TrackPlayer ()
	{


        


		// If the player has moved beyond the x margin...
        if (player != null)
        {
            if (CheckXMargin())
                // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
                targetX = Mathf.Lerp(transform.position.x, player.position.x + xMargin*Mathf.Sign(transform.position.x - player.position.x), xSmooth * Time.deltaTime);

            // If the player has moved beyond thes y margin...
            if (CheckYMargin())
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
                targetY = Mathf.Lerp(transform.position.y, player.position.y + yMargin * Mathf.Sign(transform.position.y - player.position.y), ySmooth * Time.deltaTime);

            // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
            //targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            //targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            // Set the camera's position to the target position with the same z component.
            transform.position = new Vector3(targetX, targetY, transform.position.z);
           // transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, targetY, transform.position.z), 0.8f);
        }
        
	}

    void TrackMouseView()
    {
        
        foreach (var item in GetComponentsInChildren<Camera>())
        {
           item.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 12, 0.09f);
           item.fieldOfView = Mathf.Lerp(item.fieldOfView, cameraModeFov, 0.09f);
        }

        targetX = Mathf.Lerp(transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).x, xSmooth * Time.deltaTime);
        targetY = Mathf.Lerp(transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, xSmooth * Time.deltaTime);
        if (Mathf.Abs(targetX - player.position.x) > 5)
        {
            targetX = Mathf.Sign(targetX - player.position.x) * 5 + player.position.x;
        }

        if (Mathf.Abs(targetY - player.position.y) > 5)
        {
            targetY = Mathf.Sign(targetY - player.position.y) * 5 + player.position.y;
        }


        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }


    public void Load()
    {

        transform.position = new Vector3(PlayerPrefs.GetFloat("CameraX"), PlayerPrefs.GetFloat("CameraY"),transform.position.z);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("CameraX", transform.position.x);
        PlayerPrefs.SetFloat("CameraY", transform.position.y);

    }


}
