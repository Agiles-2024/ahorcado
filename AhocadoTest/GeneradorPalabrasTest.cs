using AhorcadoLibreria;
using AhorcadoLibreria.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AhocadoTest
{
    [TestClass]
    public class GeneradorPalabrasTest
    {
        public GeneradorPalabras Sut {  get; set; }

        public GeneradorPalabrasTest()
        {
            Sut = new GeneradorPalabras();
        }

        [TestMethod]
        [TestCategory("Generar palabra")]
        public void GenerarPalabraDevuelveUnaSolaPalabra()
        {
            // Act
            var resultado = Sut.GenerarPalabra();
            
            // Assert
            Assert.IsFalse(resultado.Contains(' '));
        }

        [TestMethod]
        [TestCategory("Generar palabra")]
        public void GenerarPalabraDevuelvePalabraValida()
        {
            // Act
            var resultado = Sut.GenerarPalabra();

            // Assert
            Assert.IsTrue(Regex.IsMatch(resultado, FixedRegex.NoCaracteresEspecialesNumerosOTildes));
        }
    }
}
