using Npgsql;
using System.Data;
using ProyectoG14.Conexion;
namespace ProyectoG14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos est�n llenos antes de intentar guardar
            if (string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                string.IsNullOrWhiteSpace(txtCapacidad.Text) ||
                cmbTipoDeNave.SelectedItem == null ||
                cmbModelo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear una instancia de la clase ConexionPostgreSQL
                var conexionPostgreSQL = new ConexionPostgreSQL();

                // Obtener una conexi�n abierta de forma asincr�nica
                using (var conexion = await conexionPostgreSQL.ConectarAsync())
                {
                    // Consulta SQL para insertar un nuevo registro
                    string query = "INSERT INTO aviones (modelo, tipodeNave, matricula, capacidadPasajeros) " +
                                   "VALUES (@modelo, @tipodeNave, @matricula, @capacidadPasajeros)";

                    // Crear un comando SQL
                    using (var cmd = new NpgsqlCommand(query, conexion))
                    {
                        // Asignar valores a los par�metros
                        cmd.Parameters.AddWithValue("@modelo", cmbModelo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@tipodeNave", cmbTipoDeNave.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@matricula", txtMatricula.Text);
                        cmd.Parameters.AddWithValue("@capacidadPasajeros", int.Parse(txtCapacidad.Text));

                        // Ejecutar el comando de forma asincr�nica
                        int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                        // Verificar si la operaci�n fue exitosa
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Avi�n guardado con �xito.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Recargar los datos en el DataGridView
                            await CargarDatosAsync();

                            // Limpiar los campos
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el avi�n. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrarlos al usuario
                MessageBox.Show("Error al guardar el avi�n: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrecargarComboBox()
        {
            cmbTipoDeNave.Items.Clear();
            cmbTipoDeNave.Items.Add("Comercial");
            cmbTipoDeNave.Items.Add("Privado");
            cmbTipoDeNave.Items.Add("Carga");
            cmbTipoDeNave.Items.Add("Militar");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            PrecargarComboBox();
            await CargarDatosAsync(); // Llama al m�todo para cargar los datos
        }
        private void cmbTipoDeNave_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoDeNaveSeleccionado = cmbTipoDeNave.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(tipoDeNaveSeleccionado))
                return;

            cmbModelo.Items.Clear(); // Limpia las opciones del ComboBox de Modelo

            switch (tipoDeNaveSeleccionado)
            {

                case "Comercial":
                    cmbModelo.Items.AddRange(new string[] { "Boeing 737", "Airbus A320", "Boeing 747", "McDonnell Douglas MD-80" });
                    break;

                case "Privado":
                    cmbModelo.Items.AddRange(new string[] { "Cessna Citation X", "Gulfstream G650", "Learjet 75", "Dassault Falcon 8X" });
                    break;

                case "Carga":
                    cmbModelo.Items.AddRange(new string[] { "Boeing 747-8F", "Antonov An-124", "Lockheed C-130 Hercules", "McDonnell Douglas DC-10F" });
                    break;

                case "Militar":
                    cmbModelo.Items.AddRange(new string[] { "F-16", "F-22", "J-20", "C-130" });
                    break;

                default:
                    MessageBox.Show("Tipo de Nave no reconocido.");
                    break;
            }

            cmbModelo.SelectedIndex = -1; // Desselecciona cualquier valor previo
        }
        private async Task CargarDatosAsync()
        {
            // Crear una instancia de la clase de conexi�n
            var conexionPostgreSQL = new ConexionPostgreSQL();

            // Obtener una conexi�n abierta de forma asincr�nica
            using (var conexion = await conexionPostgreSQL.ConectarAsync())
            {
                // Consulta SQL
                string query = "SELECT idAvion, modelo, tipodeNave, matricula, capacidadPasajeros FROM aviones";

                // Crear un comando SQL
                using (var cmd = new NpgsqlCommand(query, conexion))
                {
                    try
                    {
                        // Ejecutar la consulta y obtener los resultados
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            // Cargar los resultados en una tabla
                            var tablita = new DataTable();
                            tablita.Load(reader);

                            // Mostrar los datos en un DataGridView
                            dataGridView1.DataSource = tablita;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        MessageBox.Show("Error al cargar datos: " + ex.Message);
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            txtMatricula.Clear();
            txtCapacidad.Clear();
            cmbTipoDeNave.SelectedIndex = -1;
            cmbModelo.SelectedIndex = -1;
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Guardar cambios")
            {
                try
                {
                    // Validar que los campos no est�n vac�os
                    if (string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                        string.IsNullOrWhiteSpace(txtCapacidad.Text) ||
                        cmbTipoDeNave.SelectedItem == null ||
                        cmbModelo.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Obtener el ID del registro
                    int idAvion = (int)txtMatricula.Tag;

                    // Crear la conexi�n y actualizar los datos en la base de datos
                    var conexionPostgreSQL = new ConexionPostgreSQL();
                    using (var conexion = await conexionPostgreSQL.ConectarAsync())
                    {
                        string query = "UPDATE aviones SET modelo = @modelo, tipodeNave = @tipodeNave, matricula = @matricula, capacidadPasajeros = @capacidadPasajeros WHERE idAvion = @idAvion";

                        using (var cmd = new NpgsqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@modelo", cmbModelo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@tipodeNave", cmbTipoDeNave.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@matricula", txtMatricula.Text);
                            cmd.Parameters.AddWithValue("@capacidadPasajeros", int.Parse(txtCapacidad.Text));
                            cmd.Parameters.AddWithValue("@idAvion", idAvion);

                            int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Datos actualizados con �xito.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Recargar el DataGridView
                                await CargarDatosAsync();

                                // Limpiar los campos y resetear el bot�n
                                LimpiarCampos();
                                btnModificar.Text = "Modificar datos";
                            }
                            else
                            {
                                MessageBox.Show("No se pudieron actualizar los datos. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Verificar que hay una fila seleccionada
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un registro para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la fila seleccionada
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                txtMatricula.Text = filaSeleccionada.Cells["matricula"].Value.ToString();
                txtCapacidad.Text = filaSeleccionada.Cells["capacidadPasajeros"].Value.ToString();
                cmbTipoDeNave.SelectedItem = filaSeleccionada.Cells["tipodeNave"].Value.ToString();
                cmbModelo.SelectedItem = filaSeleccionada.Cells["modelo"].Value.ToString();

                // Guardar el ID del registro en una variable temporal
                txtMatricula.Tag = filaSeleccionada.Cells["idAvion"].Value;

                // Cambiar el texto del bot�n a "Guardar cambios"
                btnModificar.Text = "Guardar cambios";
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID del registro a eliminar
            var filaSeleccionada = dataGridView1.SelectedRows[0];
            int idAvion = Convert.ToInt32(filaSeleccionada.Cells["idAvion"].Value);

            // Confirmaci�n antes de eliminar
            var confirmacion = MessageBox.Show($"�Est� seguro de que desea eliminar el registro con ID {idAvion}?",
                                                "Confirmaci�n de eliminaci�n",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // Llamar al m�todo para eliminar el registro
                await EliminarAvionAsync(idAvion);

                // Recargar los datos en el DataGridView
                await CargarDatosAsync();

                MessageBox.Show("Registro eliminado con �xito.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async Task EliminarAvionAsync(int idAvion)
        {
            try
            {
                var conexionPostgreSQL = new ConexionPostgreSQL();
                using (var conexion = await conexionPostgreSQL.ConectarAsync())
                {
                    string query = "DELETE FROM aviones WHERE idAvion = @idAvion";

                    using (var cmd = new NpgsqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idAvion", idAvion);

                        int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                        if (filasAfectadas == 0)
                        {
                            MessageBox.Show("No se encontr� el registro a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
