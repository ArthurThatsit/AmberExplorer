using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	[SerializeField] int min, seg; // Minutos y segundos iniciales configurables desde el Inspector
	[SerializeField] Text tiempo; // Referencia al componente de texto para mostrar el tiempo
	[SerializeField] Canvas gameOverCanvas; // Arrastra el Canvas de Game Over desde el Inspector

	private float restante; // Tiempo restante en segundos
	private bool enMarcha; // Indica si el contador de tiempo está en marcha

	private void Awake()
	{
		// Calcula el tiempo restante en segundos
		restante = (min * 60) + seg;

		// Inicializa el contador de tiempo como en marcha
		enMarcha = true;

		// Asegura que el Canvas de Game Over esté desactivado al inicio
		if (gameOverCanvas != null)
		{
			gameOverCanvas.gameObject.SetActive(false);
		}
	}

	void Update()
	{
		if (enMarcha)
		{
			restante -= Time.deltaTime;
			if (restante <= 0)
			{
				// El tiempo ha llegado a cero
				enMarcha = false;
				restante = 0;

				// Desactiva el Canvas del reloj
				tiempo.gameObject.SetActive(false);

				// Activa el Canvas de Game Over
				if (gameOverCanvas != null)
				{
					gameOverCanvas.gameObject.SetActive(true);
				}

				// Pausa el juego
				Time.timeScale = 0f;
			}
		}

		// Resto del código para mostrar el tiempo
		int tempmin = Mathf.FloorToInt(restante / 60);
		int tempSeg = Mathf.FloorToInt(restante % 60);
		tiempo.text = string.Format("{00:00}:{01:00}", tempmin, tempSeg);
	}
}
