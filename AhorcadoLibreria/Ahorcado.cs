
using System.Text.RegularExpressions;

namespace AhorcadoLibreria
{
	public class Ahorcado
	{

		public Ahorcado(string palabra)
		{
			Palabra = palabra;
			Adivinadas = new bool[palabra.Length];
		}

		public string Palabra { get; set; } = string.Empty;

		public bool[] Adivinadas { get; set; }

		public bool IngresarLetra(char letra)
		{
			var valido = Regex.IsMatch(letra.ToString(), @"^[a-zA-Z]+$");

			if (!valido)
				return false;

			var encontro = Palabra.Contains(letra,StringComparison.OrdinalIgnoreCase);

			return encontro;
		}
	}
}
