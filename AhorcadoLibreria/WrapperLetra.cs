namespace AhorcadoLibreria
{
    public class WrapperLetra
    {
        public char Letra { get; set; }
        public bool IsAdivinada { get; set; } = false;

        public WrapperLetra() { }
        public WrapperLetra(char letra)
        {
            Letra = letra;
        }
    } 
}
