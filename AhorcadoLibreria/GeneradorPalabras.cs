using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoLibreria
{
    public class GeneradorPalabras
    {
        private List<string> palabras;

        public GeneradorPalabras()
        {
            palabras = new List<string>()
            {
                "casa",
                "perro",
                "libro",
                "coche",
                "playa",
                "amigo",
                "sol",
                "luna",
                "comida",
                "agua",
                "ciudad",
                "musica",
                "arte",
                "montana",
                "bosque",
                "risa",
                "viaje",
                "tiempo",
                "trabajo",
                "suero",
            };
        }

        public string GenerarPalabra()
        {
            Random random = new Random();

            int index = random.Next(palabras.Count());

            return (string)palabras[index];
        }
    }
}
