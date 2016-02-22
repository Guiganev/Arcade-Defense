using UnityEngine;
using System.Collections;

public class IATiroSplash : MonoBehaviour {

	public GameObject Inimigo;
	public MovimentacaoInimigo Auxvida;
	
	public float Velocidade;
	public float Distancia;
	public int Ataque;

	public GameObject AOE;
	public GameObject AuxAOE;
	public GameObject[] Inimigos;
	public GameObject InimigoMarcado;
	public float AreaAtk;

	// Use this for initialization
	void Start () 
	{
		Velocidade = 7;
		AreaAtk = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject != null && Inimigo != null) 
		{
			Distancia = Vector3.Distance (transform.position, Inimigo.transform.position);
			
			transform.LookAt (Inimigo.transform);
			transform.Translate (transform.forward * Velocidade * Time.deltaTime);
			
			if(Distancia < 0.15)
			{
				AuxAOE = (GameObject) Instantiate(AOE, transform.position, Quaternion.identity);

				Inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");

				foreach (GameObject InimigoMarcado in Inimigos)
				{
					Distancia = Vector3.Distance (InimigoMarcado.transform.position, transform.position);
					if (Distancia < AreaAtk)
					{
						Auxvida = (MovimentacaoInimigo)InimigoMarcado.GetComponent("MovimentacaoInimigo");
						Auxvida.vida -= Ataque; 
					}
				}
				DestroyObject (gameObject);
			}
		}
	}
}
