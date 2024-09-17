using AhorcadoLibreria;

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
			var resultado= Sut.IngresarLetra('2');

			// Assert
			Assert.IsFalse(resultado);

		}	
		
		[TestMethod]
		public void IngresaLetraVerificaNoValidezLetraTilde()
		{
		
			// Act
			var resultado= Sut.IngresarLetra('é');

			// Assert
			Assert.IsFalse(resultado);

		}
			
		[TestMethod]
		public void IngresaLetraVerificaNoValidezCaracteresEspeciales()
		{
		
			// Act
			var resultado= Sut.IngresarLetra('#');

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


	}
}