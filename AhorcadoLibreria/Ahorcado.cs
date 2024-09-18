
using System.Text.RegularExpressions;

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
            var valido = Regex.IsMatch(letra.ToString(), @"^[a-zA-Z]+$");

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
    }
}
