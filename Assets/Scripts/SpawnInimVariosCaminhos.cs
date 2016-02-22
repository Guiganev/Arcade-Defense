using UnityEngine;
using System.Collections;

public class SpawnInimVariosCaminhos : MonoBehaviour 
{

	public GameObject AuxInimigo;
	public GameObject Inimigo;
	
	public Transform CaminhoInimigo;
	
	public MovInimVariosCaminhos AlteraInimigo;
	
	public float Tempo;
	
	public int Horda;
	public int numInimigos;
	public int InimigosGerados = 0;

	// Use this for initialization
	void Start () 
	{
		numInimigos = 10;
		Tempo = 0;
		Horda = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Tempo = Tempo + Time.deltaTime;
		
		if (Tempo > 1) 
		{
			if (InimigosGerados < numInimigos)
			{
				AuxInimigo = Instantiate(Inimigo);
				AlteraInimigo = (MovInimVariosCaminhos)AuxInimigo.GetComponent("MovInimVariosCaminhos");
				AlteraInimigo.Caminho = CaminhoInimigo;
				InimigosGerados = InimigosGerados + 1;
				Tempo = 0;
			}
		}
	}
}
