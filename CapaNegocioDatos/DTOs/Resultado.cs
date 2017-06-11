namespace CapaNegocioDatos.DTOs
{
    public class Resultado
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }

        public static Resultado CrearResultadoExitoso()
        {
            return new Resultado { Exito = true, Mensaje = string.Empty };
        }

        public static Resultado CrearResultadoError(string mensaje)
        {
            return new Resultado { Exito = false, Mensaje = mensaje };
        }
    }
}
