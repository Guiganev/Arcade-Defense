using UnityEngine;
using System.Collections;
using Homans.Console;

public class PlayerCommands : MonoBehaviour {

	public GameObject TorreBasica;
	public GameObject TorreSlow;
	public GameObject TorreSplash;

	public GameObject TipoTorre;
	public GameObject AuxTorre;
	
	public Vector3 posicao;

	public GameObject[] TorresJogo = null;

	// Use this for initialization
	void Start () {
		Console.Instance.RegisterCommand("CriaTorre", this, "criaTorre");
	}

	// Update is called once per frame
	void Update () {
	
	}

	[Help("Usage: Cria uma torre a partir dos parametros Tipo da Torre, Posiçao em X, Posiçao em Y\nTipo 1: Torre Basica\nTipo 2: Torre de Slow\nTipo 3: Torre de Splash")]
	void criaTorre (int tipo, float X, float Y)
	{
		switch (tipo) 
		{
		case 1: TipoTorre = TorreBasica; break;
		case 2: TipoTorre = TorreSlow; break;
		case 3: TipoTorre = TorreSplash; break;
		default: TipoTorre = TorreBasica; break;
		}

		posicao.x = X;
		posicao.y = Y;
		posicao.z = 0;

		AuxTorre = (GameObject) Instantiate(TipoTorre, posicao,Quaternion.identity);
	}
	
}
