using UnityEngine;
using System.Collections;

public class IATorre : MonoBehaviour {

	public int Alcance;
	public int Ataque;
	public float Distancia;
	public float Intervalo;
	public float Tempo;
	public GameObject[] Inimigos;
	public GameObject InimigoMarcado;
	public GameObject AuxInimigo;
	public bool AchouInimigo;

	public GameObject Tiro;
	public GameObject AuxTiro;
	public IATiro AlteraTiro;

	public int Energia;
	public GameObject EnergiaIco;
	public GameObject AuxEnergia;
	public bool EnergiaAviso;

	void Start ()
	{
		Alcance = 2;
		Ataque = 10;
		Intervalo = 1;
		Energia = 10;
		EnergiaAviso = false;
	}


	void Update () 
	{
		Tempo += Time.deltaTime;

		if (Energia <= 0 && EnergiaAviso == false) 
		{
			AuxEnergia = (GameObject)Instantiate (EnergiaIco, transform.position, Quaternion.identity);
			EnergiaAviso = true;
		}
	
		Inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");

		foreach (GameObject InimigoMarcado in Inimigos) 
		{
			Distancia = Vector3.Distance (InimigoMarcado.transform.position, transform.position);
			if (Distancia < Alcance) 
			{
				AuxInimigo = InimigoMarcado;
				AchouInimigo = true;
				break;
			}
		}

		if (Tempo > Intervalo && AchouInimigo == true && Energia > 0) 
		{
			AchouInimigo = false;

			if (AuxInimigo != null)
			{
				AuxTiro = (GameObject) Instantiate(Tiro, transform.position, Quaternion.identity);
				AlteraTiro = (IATiro)AuxTiro.GetComponent("IATiro");
				AlteraTiro.Inimigo = AuxInimigo;
				AlteraTiro.Ataque = Ataque;

				Energia -= 1;

				Tempo = 0;
			}
		}
	}	

	void DeletaTorre()
	{
		DestroyObject (gameObject);
	}
}
