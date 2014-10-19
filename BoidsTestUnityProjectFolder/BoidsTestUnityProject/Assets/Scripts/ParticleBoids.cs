using UnityEngine;
using System.Collections;

public class ParticleBoids : MonoBehaviour 
{
	ParticleSystem.Particle[] particlesArray;

	Vector3[] particlesPositionsArray;
	Vector3[] particlesVelocitiesArray;

	public int particlesCount = 100;
	public float minDistanceBetween = 10.0f;

	void Start () 
	{

		particlesArray = new ParticleSystem.Particle[particlesCount];
		for(int i = 0; i < particlesArray.Length; i++)
		{
			particlesArray[i].color = Color.white;
			particlesArray[i].position = 1.0f * Random.onUnitSphere;
			particlesArray[i].axisOfRotation = Quaternion.identity.eulerAngles.normalized; //Random.insideUnitSphere.normalized;
			particlesArray[i].rotation = Random.Range(0.0f,360.0f);
			particlesArray[i].size = 0.10f;
		}
		particleSystem.SetParticles(particlesArray,particlesArray.Length);

		particlesPositionsArray = new Vector3[particleSystem.particleCount];
		particlesVelocitiesArray = new Vector3[particleSystem.particleCount];
		for(int i = 0; i < particleSystem.particleCount; i++)
		{
			particlesPositionsArray[i] = particlesArray[i].position;
			particlesVelocitiesArray[i] = Vector3.zero; //new Vector3( Random.Range(-1.0f,1.0f) , Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
		}
	}

		


	void Update () 
	{

		for(int i = 0; i < particleSystem.particleCount; i++)
		{
			particlesVelocitiesArray[i] -= particlesVelocitiesArray[i] * Time.deltaTime;
		}

		// update internal models
		for(int i = 0; i < particleSystem.particleCount; i++)
		{

			// velocity update
			for(int j = 0; j < particleSystem.particleCount; j++)
			{
				if(i == j)
					continue;

				if(Vector3.Distance(particlesPositionsArray[i], particlesPositionsArray[j]) < minDistanceBetween)
				{
					particlesVelocitiesArray[i] = (particlesPositionsArray[i] - particlesPositionsArray[j]).normalized;
					break;
				}

			}


			// position set
			particlesPositionsArray[i] += particlesVelocitiesArray[i] * Time.deltaTime;
		}




		// set particle system to internal model values
		for(int i = 0; i < particleSystem.particleCount; i++)
		{
			particlesArray[i].position = particlesPositionsArray[i];
		}
		particleSystem.SetParticles(particlesArray, particlesArray.Length);


	}





}
