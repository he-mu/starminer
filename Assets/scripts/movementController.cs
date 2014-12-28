/* 
 * Esse Script movimenta o GameObject quando você clica ou
 * mantém o botão esquerdo do mouse apertado.
 * 
 * Para usá-lo, adicione esse script ao gameObject que você quer mover
 * seja o Player ou outro
 * 
 * Autor: Vinicius Rezendrix - Brasil
 * Data: 11/08/2012
 * 
 * This script moves the GameObeject when you
 * click or click and hold the LeftMouseButton
 * 
 * Simply attach it to the gameObject you wanna move (player or not)
 * 
 * Autor: Vinicius Rezendrix - Brazil
 * Data: 11/08/2012 
 *
 */

/*using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {
	public Transform myTransform;				// this transform
	public Vector3 destinationPosition;		// The destination Point
	public float destinationDistance;			// The distance between myTransform and destinationPosition
		
	public float moveSpeed;						// The Speed the character will move
	
	
	
	void Start () {
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
	}
	
	void Update () {
		
		// keep track of the distance between this gameObject and destinationPosition
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		
		if(destinationDistance < 1.0f){		// To prevent shakin behavior when near destination
			moveSpeed = 0;
		}
		else if(destinationDistance > 1.0f){			// To Reset Speed to default
			moveSpeed = 3;
		}
		
		
		// Moves the Player if the Left Mouse Button was clicked
		if (Input.GetMouseButtonDown(0)&& GUIUtility.hotControl ==0) {
			
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
			
			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist);
				destinationPosition = ray.GetPoint(hitdist);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				//myTransform.rotation = targetRotation;

				myTransform.rotation = Quaternion.Slerp(myTransform.rotation, targetRotation, 2.0f); //moveSpeed * Time.deltaTime);
			
			}
		}
		
		// Moves the player if the mouse button is hold down
		else if (Input.GetMouseButton(0)&& GUIUtility.hotControl ==0) {
			
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
			
			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist);
				destinationPosition = ray.GetPoint(hitdist);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation, targetRotation, 2.0f ); //moveSpeed * Time.deltaTime);

				//myTransform.rotation = targetRotation;
			}
			//	myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
		
		// To prevent code from running if not needed
		if(destinationDistance > .5f){
			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
	}
} */


// perus moovi scripti

using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {
	public float speed = 5.0F;
	public float rotationSpeed = 30.0F;
	void Update() {
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
	}
}

/*


	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 0.0F;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

		//moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
} */




/*using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {

	//public values
	public float speed = 1.5f;
	public float normalSpeed = 1.5f;
	public float fastSpeed = 3.5f;

	//private values
	//privat float flyHeight = 0.0f;
	private Vector3 currentPosition;
	private float step;

	//smooth transform variables
	public Transform target;
	public float smoothTime = 4.0F;
	private Vector3 velocity = Vector3.up;
	public float baseRotation = 20.0F;
	private Vector3 moveDirection = Vector3.zero;


	void Update ()
	{
		currentPosition = transform.position;

		//speed vector update
		speed = normalSpeed;
		if (Input.GetKey(KeyCode.LeftShift)) { speed = fastSpeed; }
		float step = speed * Time.deltaTime;


		//check if position is out of bounds
		if (currentPosition.y <= -1 || currentPosition.y >= 1) {

			//transform.position = Vector3.MoveTowards( , step);
		}


		//Height handler
		if (Input.GetKey (KeyCode.A) && currentPosition.y <= 1 ) {
			//transform.position = currentPosition + Vector3.up; 
			//transform.position += Vector3.up * step;
			Vector3 targetPosition =  currentPosition + Vector3.up; //target.TransformPoint(new Vector3(0, 5, -10));
			transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);
		}

		if (Input.GetKey (KeyCode.Z) && currentPosition.y >= -1 ) {
			//transform.position = currentPosition + Vector3.down; 
			//transform.position += Vector3.down * speed * Time.deltaTime;
			Vector3 targetPosition =  currentPosition + Vector3.down; //target.TransformPoint(new Vector3(0, 5, -10));
			transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);
		}



		//movement buttons
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.down * Time.deltaTime * baseRotation);
			//transform.position += Vector3.left * step;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up * Time.deltaTime * baseRotation);
			//transform.position += Vector3.right * step;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.forward * step;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.back * step;
		}
	}
}*/
