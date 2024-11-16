namespace ProyectoG14
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMatricula = new TextBox();
            txtCapacidad = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnGuardar = new Button();
            dataGridView1 = new DataGridView();
            btnModificar = new Button();
            btnEliminar = new Button();
            cmbTipoDeNave = new ComboBox();
            cmbModelo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(147, 66);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(151, 27);
            txtMatricula.TabIndex = 2;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(452, 69);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(117, 27);
            txtCapacidad.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 24);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 4;
            label1.Text = "Modelo de Avión:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 24);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 5;
            label2.Text = "Tipo de Avión:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 66);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 6;
            label3.Text = "Matrícula:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(361, 69);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 7;
            label4.Text = "Capacidad:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(575, 67);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(128, 29);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Datos";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 135);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(609, 245);
            dataGridView1.TabIndex = 9;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(663, 135);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(128, 29);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar Datos";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(663, 170);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(128, 29);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar Datos";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cmbTipoDeNave
            // 
            cmbTipoDeNave.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDeNave.FormattingEnabled = true;
            cmbTipoDeNave.Location = new Point(147, 21);
            cmbTipoDeNave.Name = "cmbTipoDeNave";
            cmbTipoDeNave.Size = new Size(151, 28);
            cmbTipoDeNave.TabIndex = 12;
            cmbTipoDeNave.SelectedIndexChanged += cmbTipoDeNave_SelectedIndexChanged;
            // 
            // cmbModelo
            // 
            cmbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelo.FormattingEnabled = true;
            cmbModelo.Location = new Point(450, 21);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(151, 28);
            cmbModelo.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 389);
            Controls.Add(cmbModelo);
            Controls.Add(cmbTipoDeNave);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(dataGridView1);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCapacidad);
            Controls.Add(txtMatricula);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtMatricula;
        private TextBox txtCapacidad;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnGuardar;
        private DataGridView dataGridView1;
        private Button btnModificar;
        private Button btnEliminar;
        private ComboBox cmbTipoDeNave;
        private ComboBox cmbModelo;
    }
}
