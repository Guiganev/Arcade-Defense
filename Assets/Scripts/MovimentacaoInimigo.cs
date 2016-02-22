using UnityEngine;
using System.Collections;

public class MovimentacaoInimigo : MonoBehaviour {

	public Transform Caminho;

	public Vector3 Dist;

	public float Velocidade;
	public float VelocidadeNatural;
	public	float Distancia;
	public int vida;

	public bool Lento;
	public float TempoLento;
	

	// Use this for initialization
	void Start () 
	{
		vida = 20;
		Velocidade = 2;
		VelocidadeNatural = 2;
		Lento = false;
		TempoLento = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (vida <= 0) 
			Destroy (gameObject);

		if (TempoLento <= 0) 
		{
			Velocidade = VelocidadeNatural;
			Lento = false;
		}	
		if (TempoLento > 0)
			TempoLento -= Time.deltaTime;

		Dist = transform.position - Caminho.position;

		Distancia = Vector3.Distance (transform.position, Caminho.position);

		if (Distancia < 0.1) 
		{
			if (Caminho.childCount > 0)
				Caminho = Caminho.GetChild (0);
		} 
		else 
		{
			if (Dist.x > 0.1 || Dist.x < -0.1)
			{
				if (Dist.x > 0)
					transform.Translate (Velocidade * Time.deltaTime * -1, 0, 0);
				else
					transform.Translate (Velocidade * Time.deltaTime, 0, 0);
			}
			else
			{
				if (Dist.y > 0)
					transform.Translate (0, Velocidade * Time.deltaTime * -1, 0);
				else
					transform.Translate (0, Velocidade * Time.deltaTime, 0);
			}
		}
	}
}
