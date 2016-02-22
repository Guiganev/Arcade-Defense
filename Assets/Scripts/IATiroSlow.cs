using UnityEngine;
using System.Collections;

public class IATiroSlow : MonoBehaviour {

	public GameObject Inimigo;
	public MovimentacaoInimigo AuxInimigo;
	
	public float Velocidade;
	public float Distancia;
	public int Ataque;

	public float Intervalo;
	public float Tempo;

	public bool Hit;

	// Use this for initialization
	void Start () 
	{
		Intervalo = 3;
		Tempo = 0;
		Hit = false;
		Velocidade = 6;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Hit == true)
			Tempo += Time.deltaTime;

		if (gameObject != null && Inimigo != null) 
		{
			Distancia = Vector3.Distance (transform.position, Inimigo.transform.position);
			
			transform.LookAt (Inimigo.transform);
			transform.Translate (transform.forward * Velocidade * Time.deltaTime);
			
			if(Distancia < 0.15)
			{ 
				Velocidade = 1;
				AuxInimigo = (MovimentacaoInimigo)Inimigo.GetComponent("MovimentacaoInimigo");
				if (AuxInimigo.Lento == false)
				{
					AuxInimigo.Velocidade = AuxInimigo.Velocidade - Ataque;
					AuxInimigo.vida -= Ataque;
					AuxInimigo.TempoLento = Intervalo;
					Hit = true;
				}
				else
				{
					if (Hit == false)
					{
						DestroyObject (gameObject);
						AuxInimigo.TempoLento = Intervalo;
						Tempo = 0;
					}
				}
				AuxInimigo.Lento = true;
			}
		}
		else
			DestroyObject (gameObject);

		if (Tempo > Intervalo)
			DestroyObject (gameObject);
	}
}
