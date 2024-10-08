
using System.Text.RegularExpressions;
using AhorcadoLibreria.Constants;

namespace AhorcadoLibreria
{
    public class Ahorcado
    {
        public string Palabra { get; set; } = string.Empty;

        public List<WrapperLetra> Adivinadas { get; set; }

        public Ahorcado(string palabra)
        {
            Palabra = palabra;
            Adivinadas = palabra.ToCharArray().Select(letra => new WrapperLetra(letra)).ToList();
        }

        public bool IngresarLetra(char letra)
        {
            var valido = Regex.IsMatch(letra.ToString(), FixedRegex.NoCaracteresEspecialesNumerosOTildes);

            if (!valido)
                return false;

            var encontro = Palabra.Contains(letra, StringComparison.OrdinalIgnoreCase);

            if (!encontro)
                return false;

            foreach (var l in Adivinadas)
            {
                if (!l.IsAdivinada)
                    l.IsAdivinada = l.Letra.ToString().Equals(letra.ToString(), StringComparison.OrdinalIgnoreCase);
            }

            return true;
        }



		public EnumResultados ArriesgarPalabra(string palabra)
		{
			var valido = Regex.IsMatch(palabra, FixedRegex.NoCaracteresEspecialesNumerosOTildes);

            if (!valido)
                return EnumResultados.NoEsUnaPalabraValida;

			if (palabra.Equals(Palabra, StringComparison.OrdinalIgnoreCase))
				return  EnumResultados.Ganaste;
			else
				return  EnumResultados.Perdiste;
		}

        public bool EstaTerminado()
        {
            return !Adivinadas.Any(letra => !letra.IsAdivinada);
        }
    }
}
