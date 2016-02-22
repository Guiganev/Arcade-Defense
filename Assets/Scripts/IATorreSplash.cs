using UnityEngine;
using System.Collections;

public class IATorreSplash : MonoBehaviour {

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
	public IATiroSplash AlteraTiro;
	
	public int Energia;
	public GameObject EnergiaIco;
	public GameObject AuxEnergia;
	public bool EnergiaAviso;

	// Use this for initialization
	void Start () 
	{
		Alcance = 2;
		Ataque = 15;
		Intervalo = 3;
		Energia = 5;
		EnergiaAviso = false;
	}
	
	// Update is called once per frame
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
				AlteraTiro = (IATiroSplash)AuxTiro.GetComponent("IATiroSplash");
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
