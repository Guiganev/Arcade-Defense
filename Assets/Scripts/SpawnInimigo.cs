using UnityEngine;
using System.Collections;

public class SpawnInimigo : MonoBehaviour 
{
	public GameObject AuxInimigo;
	public GameObject Inimigo;

	public Transform CaminhoInimigo;

	public MovimentacaoInimigo AlteraInimigo;

	public float Tempo;

	public int Horda;
	public int numInimigos;
	public int InimigosGerados = 0;

	public bool StartButton;
	
	// Use this for initialization
	void Start () 
	{
		numInimigos = 10;
		Tempo = 0;
		Horda = 0;
		StartButton = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (StartButton == true)
		{
			Tempo = Tempo + Time.deltaTime;
			
			if (Tempo > 1) 
			{
				if (InimigosGerados < numInimigos)
				{
					AuxInimigo = Instantiate(Inimigo);
					AlteraInimigo = (MovimentacaoInimigo)AuxInimigo.GetComponent("MovimentacaoInimigo");
					AlteraInimigo.Caminho = CaminhoInimigo;
					InimigosGerados = InimigosGerados + 1;
					Tempo = 0;
				}
			}
		}
	}

	public void StartButtonClick ()
	{
		StartButton = true;
	}
}
