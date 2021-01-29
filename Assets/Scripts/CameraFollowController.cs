using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
	
	public Camera firstPersonCamera;
    public Camera overheadCamera;

	public void LookAtTarget()
	{
		Vector3 _lookDirection = objectToFollow.position - firstPersonCamera.transform.position;
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		firstPersonCamera.transform.rotation = Quaternion.Lerp(firstPersonCamera.transform.rotation, _rot, lookSpeed * Time.deltaTime);

		Vector3 _lookDirection2 = objectToFollow.position - overheadCamera.transform.position;
		Quaternion _rot2 = Quaternion.LookRotation(_lookDirection, Vector3.up);
		overheadCamera.transform.rotation = Quaternion.Lerp(overheadCamera.transform.rotation, _rot2, lookSpeed * Time.deltaTime);
	}

	public void MoveToTarget()
	{
		Vector3 _targetPos = objectToFollow.position +
							 objectToFollow.forward * offset.z +
							 objectToFollow.right * offset.x +
							 objectToFollow.up * offset.y;
		firstPersonCamera.transform.position = Vector3.Lerp(firstPersonCamera.transform.position, _targetPos, followSpeed * Time.deltaTime);

		Vector3 _targetPos2 = objectToFollow.position +
							 objectToFollow.forward * cam2offset.z +
							 objectToFollow.right * cam2offset.x +
							 objectToFollow.up * cam2offset.y;
		overheadCamera.transform.position = Vector3.Lerp(overheadCamera.transform.position, _targetPos2, followSpeed * Time.deltaTime);
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			firstPersonCamera.enabled = !firstPersonCamera.enabled;
			overheadCamera.enabled = !overheadCamera.enabled;
		}

		LookAtTarget();
		MoveToTarget();
	}

	// Call this function to disable FPS camera,
    // and enable overhead camera.
    public void ShowOverheadView() {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }
    
    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

	public Transform objectToFollow;
	public Vector3 offset;
	public Vector3 cam2offset;
	public float followSpeed = 10;
	public float lookSpeed = 10;
}