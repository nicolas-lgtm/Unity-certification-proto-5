﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	Transform camTransform;

	// How long the object should shake for.
	[SerializeField] float memorizeShakeDuration;
	float shakeDuration;

	// Amplitude of the shake. A larger value shakes the camera harder.
	[SerializeField] float shakeAmount = 0.7f;
	[SerializeField] float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent<Transform>();
		}
	}

	void OnEnable()
	{
		shakeDuration = memorizeShakeDuration;

		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			enabled = false;//Deactivate this script
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}