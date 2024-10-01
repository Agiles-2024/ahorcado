using AhorcadoLibreria;
using FluentAssertions;
using Moq;

namespace AhocadoTest
{
    [TestClass]
    public class AhorcadoTest
    {
        public Ahorcado Sut { get; set; }

        [TestInitialize]
        public void Inicializar()
        {
            // Inicializar
            Sut = new Ahorcado("hola");
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

        //[TestMethod]
        //public void IngresaLetraNoModificarLasYaAdivinadas()
        //{
        //    //Arrange
        //    var cantidadYaAdivinadas = Sut.Where(l => l.IsAdivinada && !l.letra.Equals('A', StringComparison.OrdinalIgnoreCase)).count;

        //    // Act
        //    var resultado = Sut.IngresarLetra('A');
        //    var cantidadYaAdivinadasPost = Sut.Where(l => l.IsAdivinada && !l.letra.Equals('A', StringComparison.OrdinalIgnoreCase)).count;

        //    // Assert
        //    Assert.Equal(cantidadYaAdivinadas, cantidadYaAdivinadasPost);
        //}

        [TestMethod]
        [TestCategory("Ingresar letra")]
		public void IngresaLetraMarcaComoAdivinadaSiPerteneceAPalabra()
        {
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
			var resultado = Sut.ArriesgarPalabra("hola");

			// Assert
			Assert.AreEqual(EnumResultados.Ganaste, resultado);

		}
		#endregion

	}
}