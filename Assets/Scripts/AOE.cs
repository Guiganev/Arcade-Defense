using UnityEngine;
using System.Collections;

public class AOE : MonoBehaviour {

	public float Tempo;
	public double Intervalo;

	// Use this for initialization
	void Start () 
	{
		Tempo = 0;
		Intervalo = 0.4;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Tempo += Time.deltaTime;

		if (Tempo >= Intervalo)
			Destroy (gameObject);
	}
}
