using UnityEngine;
using System.Collections;

public class ParticleBoids : MonoBehaviour 
{
	ParticleSystem.Particle[] particlesArray;
	public int particlesCount = 100;

	void Start () 
	{

		particlesArray = new ParticleSystem.Particle[particlesCount];
		for(int i = 0; i < particlesArray.Length; i++)
		{
			particlesArray[i].color = Color.white;
			particlesArray[i].position = 4.0f * Random.onUnitSphere;
			particlesArray[i].axisOfRotation = Random.insideUnitSphere.normalized;
			particlesArray[i].rotation = Random.Range(0.0f,360.0f);
			particlesArray[i].size = 0.10f;
		}
		particleSystem.SetParticles(particlesArray,particlesArray.Length);
	
	}

		


	void Update () 
	{
	
	}
}
