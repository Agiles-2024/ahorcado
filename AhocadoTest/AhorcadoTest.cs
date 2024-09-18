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

        [TestMethod]
        public void IngresaLetraVerificaNoValidezNumero()
        {
            // Act
            var resultado = Sut.IngresarLetra('2');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void IngresaLetraVerificaNoValidezLetraTilde()
        {
            // Act
            var resultado = Sut.IngresarLetra('é');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void IngresaLetraVerificaNoValidezCaracteresEspeciales()
        {
            // Act
            var resultado = Sut.IngresarLetra('#');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void IngresaLetraVerificaSiPerteneceAPalabra()
        {
            // Act
            var resultado = Sut.IngresarLetra('a');

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void IngresaLetraVerificaNoPerteneceAPalabra()
        {
            // Act
            var resultado = Sut.IngresarLetra('w');

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
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

    }
}