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
			particlesArray[i].position = 10.0f * Random.onUnitSphere;
			particlesArray[i].size = 1.0f;
		}
		particleSystem.SetParticles(particlesArray,particlesArray.Length);
	
	}

		


	void Update () 
	{
	
	}
}
