using AhorcadoLibreria;
using AhorcadoLibreria.Constants;
using FluentAssertions;
using Moq;

namespace AhocadoTest
{
    [TestClass]
    public class AhorcadoTest
    {
        public Ahorcado Sut { get; set; }
        
        public string PalabraCorrecta { get; set; }
        
        [TestInitialize]
        public void Inicializar()
        {
            // Inicializar
            PalabraCorrecta ="hola";
            Sut = new Ahorcado(PalabraCorrecta);
        }

		#region Test de ingresar letra
		[TestMethod]
        [TestCategory("Ingresar letra")]
		public void IngresaLetraVerificaNoValidezNumero()
        {
            // Act
            var resultado = Sut.IngresarLetra('2');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestCategory("Ingresar letra")]
        [TestMethod]
		public void IngresaLetraVerificaNoValidezLetraTilde()
        {
            // Act
            var resultado = Sut.IngresarLetra('é');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [TestCategory("Ingresar letra")]
		public void IngresaLetraVerificaNoValidezCaracteresEspeciales()
        {
            // Act
            var resultado = Sut.IngresarLetra('#');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [TestCategory("Ingresar letra")]
		public void IngresaLetraVerificaSiPerteneceAPalabra()
        {
            // Act
            var resultado = Sut.IngresarLetra('a');

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [TestCategory("Ingresar letra")]
		public void IngresaLetraVerificaNoPerteneceAPalabra()
        {
            // Act
            var resultado = Sut.IngresarLetra('w');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [TestCategory("Ingresar letra")]
		public void IngresaLetraVerificaSiPerteneceAPalabraAunSiendoMayuscula()
        {
            // Act
            var resultado = Sut.IngresarLetra('A');

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [TestCategory("Ingresar letra")]
		public void IngresaLetraMarcaComoAdivinadaSiPerteneceAPalabra()
        {
            // Arrange
            var expectedResult = new List<WrapperLetra>()
            {
                new WrapperLetra{ Letra = 'h', IsAdivinada = false },
                new WrapperLetra{ Letra = 'o', IsAdivinada = false },
                new WrapperLetra{ Letra = 'l', IsAdivinada = false },
                new WrapperLetra{ Letra = 'a', IsAdivinada = true },
            };

            // Act
            var resultado = Sut.IngresarLetra('a');

            // Assert
            Sut.Adivinadas.Should().BeEquivalentTo(expectedResult);
        }
        #endregion

        #region Test Arriesgar palabra
        [TestCategory("Arriesgar palabra")]
		[TestMethod]
		public void ArriesgarPalabraVerificaNoValidezNumero()
		{
			// Act
			var resultado = Sut.ArriesgarPalabra("7");

			// Assert
			Assert.AreEqual(EnumResultados.NoEsUnaPalabraValida, resultado);
		}

		[TestCategory("Arriesgar palabra")]
		[TestMethod]
		public void ArriesgarPalabraVerificaNoValidezCaracteresEspeciales()
		{
			// Act
			var resultado = Sut.ArriesgarPalabra("hola$");

			// Assert
			Assert.AreEqual(EnumResultados.NoEsUnaPalabraValida, resultado);
		}

		[TestCategory("Arriesgar palabra")]
		[TestMethod]
		public void ArriesgarPalabraVerificaNoValidezLetraTilde()
		{
			// Act
			var resultado = Sut.ArriesgarPalabra("hóla");

			// Assert
			Assert.AreEqual(EnumResultados.NoEsUnaPalabraValida, resultado);
		}

		[TestCategory("Arriesgar palabra")]
		[TestMethod]
		public void ArriesgarPalabraVerificaPalabraCorrecta()
		{
			// Act
			var resultado = Sut.ArriesgarPalabra(PalabraCorrecta);

			// Assert
			Assert.AreEqual(EnumResultados.Ganaste, resultado);
		}
        #endregion

        #region estaTerminado
        [TestMethod]
        [TestCategory("Ingresar letra")]
        public void IngresaLetraMarcaComoNoTerminaElJuegoSiQuedanLetrasPorAdivinar()
        {
            // Arrange
            var expectedResult = new List<WrapperLetra>()
            {
                new WrapperLetra{ Letra = 'h', IsAdivinada = false },
                new WrapperLetra{ Letra = 'o', IsAdivinada = false },
                new WrapperLetra{ Letra = 'l', IsAdivinada = false },
                new WrapperLetra{ Letra = 'a', IsAdivinada = true },
            };

            // Act
            var resultado = Sut.EstaTerminado();

            // Assert
            resultado.Should().Be(false);
        }

        [TestMethod]
        [TestCategory("Ingresar letra")]
        public void IngresaLetraMarcaComoTerminadoElJuegoSiNoQuedanLetrasPorAdivinar()
        {
            // Arrange
            Sut.Adivinadas = new List<WrapperLetra>()
            {
                new WrapperLetra{ Letra = 'h', IsAdivinada = true },
                new WrapperLetra{ Letra = 'o', IsAdivinada = true },
                new WrapperLetra{ Letra = 'l', IsAdivinada = true },
                new WrapperLetra{ Letra = 'a', IsAdivinada = true },
            };

            // Act
            var resultado = Sut.EstaTerminado();

            // Assert
            resultado.Should().Be(true);
        }


        #endregion

        #region Resultado
        [TestMethod]
        [TestCategory("Resultado")]
        public void ResultadoVerificaGanaste()
        {
            // Arrange
            Sut.IngresarLetra('h');
            Sut.IngresarLetra('o');
            Sut.IngresarLetra('l');
            Sut.IngresarLetra('a');

            // Act
            var resultado = Sut.Resultado;

            // Assert
            resultado.Should().Be(EnumResultados.Ganaste);
        }
        [TestMethod]
        [TestCategory("Resultado")]
        public void ResultadoVerificaPerdiste()
        {
            // Arrange
            Sut.IngresarLetra('w');
            Sut.IngresarLetra('x');
            Sut.IngresarLetra('y');
            Sut.IngresarLetra('z');
            Sut.IngresarLetra('q');
            Sut.IngresarLetra('r');

            // Act
            var resultado = Sut.Resultado;

            // Assert
            resultado.Should().Be(EnumResultados.Perdiste);
        }
        [TestMethod]
        [TestCategory("Resultado")]
        public void ResultadoVerificaEnJuego()
        {
            // Arrange
            Sut.IngresarLetra('h');
            Sut.IngresarLetra('o');
            Sut.IngresarLetra('l');

            // Act
            var resultado = Sut.Resultado;

            // Assert
            resultado.Should().Be(EnumResultados.EnJuego);
        }
        [TestMethod]
        [TestCategory("Resultado")]
        public void ResultadoArriesgarPalabraVerificaGanaste()
        {
            // Act
            var resultado = Sut.ArriesgarPalabra(PalabraCorrecta);

            // Assert
            resultado.Should().Be(EnumResultados.Ganaste);
        }
        [TestMethod]
        [TestCategory("Resultado")]
        public void ResultadoArriesgarPalabraVerificaPerdiste()
        {
            // Act
            var resultado = Sut.ArriesgarPalabra("chau");

            // Assert
            resultado.Should().Be(EnumResultados.Perdiste);
        }
        #endregion
    }
}