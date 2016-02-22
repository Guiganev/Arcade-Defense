using UnityEngine;
using System.Collections;

public class MovInimVariosCaminhos : MonoBehaviour 
{

	public Transform Caminho;
	
	public Vector3 Dist;
	
	public float Velocidade;
	public float Distancia;

	public int numCaminhos = 2;
	public int divisaoCaminho = 1;
	public int contCaminho;

	// Use this for initialization
	void Start () 
	{
		contCaminho = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		int r;

		Dist = transform.position - Caminho.position;
		
		Distancia = Vector3.Distance (transform.position, Caminho.position);
		
		if (Distancia < 0.1) 
		{
			if (Caminho.childCount > 0)
			{
				if (contCaminho == divisaoCaminho)
				{
					r = Random.Range(0, 2);
					Caminho = Caminho.GetChild (r);
				}
				else
					Caminho = Caminho.GetChild (0);
				contCaminho = contCaminho + 1;
			}
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
