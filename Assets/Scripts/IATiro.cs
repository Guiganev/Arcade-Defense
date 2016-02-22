using UnityEngine;
using System.Collections;

public class IATiro : MonoBehaviour {

	public GameObject Inimigo;
	public MovimentacaoInimigo Auxvida;

	public float Velocidade;
	public float Distancia;
	public int Ataque;

	// Use this for initialization
	void Start () 
	{
		Velocidade = 10;
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
				Auxvida = (MovimentacaoInimigo)Inimigo.GetComponent("MovimentacaoInimigo");
				Auxvida.vida -= Ataque; 
				DestroyObject (gameObject);
			}
		}
	}
}
