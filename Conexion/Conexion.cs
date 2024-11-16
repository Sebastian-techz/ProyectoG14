using Npgsql;

namespace ProyectoG14.Conexion
{
    public class ConexionPostgreSQL
    {
        private readonly string _cadenaConexion;

        /// <summary>
        /// Constructor que inicializa la cadena de conexión.
        /// </summary>
        public ConexionPostgreSQL()
        {
            // Reemplaza estos valores con los de tu servidor PostgreSQL
            _cadenaConexion = "Host=localhost;Port=5432;Database=Aeropuerto;Username=postgres;Password=admin123";
        }

        /// Devuelve una conexión abierta a PostgreSQL de forma asincrónica.
        /// <returns>Una conexión abierta.</returns>
        public async Task<NpgsqlConnection> ConectarAsync()
        {
            // Crear una nueva conexión
            var conexion = new NpgsqlConnection(_cadenaConexion);

            // Abrir la conexión de forma asincrónica
            await conexion.OpenAsync();

            // Retornar la conexión abierta
            return conexion;
        }
    }
}

