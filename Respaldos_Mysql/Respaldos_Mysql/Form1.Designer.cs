
namespace Respaldos_Mysql
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Crear_Respaldo = new Telerik.WinControls.UI.RadButton();
            this.Bar_Espera = new Telerik.WinControls.UI.RadWaitingBar();
            this.Btn_Comprimir = new Telerik.WinControls.UI.RadButton();
            this.Btn_Mantenimiento = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Crear_Respaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Espera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Comprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Mantenimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Crear_Respaldo
            // 
            this.Btn_Crear_Respaldo.Location = new System.Drawing.Point(24, 12);
            this.Btn_Crear_Respaldo.Name = "Btn_Crear_Respaldo";
            this.Btn_Crear_Respaldo.Size = new System.Drawing.Size(190, 91);
            this.Btn_Crear_Respaldo.TabIndex = 0;
            this.Btn_Crear_Respaldo.Text = "Crear respaldo";
            this.Btn_Crear_Respaldo.Click += new System.EventHandler(this.Btn_Crear_Respaldo_Click);
            // 
            // Bar_Espera
            // 
            this.Bar_Espera.Location = new System.Drawing.Point(236, 79);
            this.Bar_Espera.Name = "Bar_Espera";
            this.Bar_Espera.Size = new System.Drawing.Size(335, 24);
            this.Bar_Espera.TabIndex = 1;
            this.Bar_Espera.Text = "radWaitingBar1";
            // 
            // Btn_Comprimir
            // 
            this.Btn_Comprimir.Location = new System.Drawing.Point(24, 122);
            this.Btn_Comprimir.Name = "Btn_Comprimir";
            this.Btn_Comprimir.Size = new System.Drawing.Size(190, 91);
            this.Btn_Comprimir.TabIndex = 2;
            this.Btn_Comprimir.Text = "Comprimir";
            this.Btn_Comprimir.Click += new System.EventHandler(this.Btn_Comprimir_Click);
            // 
            // Btn_Mantenimiento
            // 
            this.Btn_Mantenimiento.Location = new System.Drawing.Point(24, 246);
            this.Btn_Mantenimiento.Name = "Btn_Mantenimiento";
            this.Btn_Mantenimiento.Size = new System.Drawing.Size(190, 86);
            this.Btn_Mantenimiento.TabIndex = 3;
            this.Btn_Mantenimiento.Text = "Mantenimiento";
            this.Btn_Mantenimiento.Click += new System.EventHandler(this.Btn_Mantenimiento_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Mantenimiento);
            this.Controls.Add(this.Btn_Comprimir);
            this.Controls.Add(this.Bar_Espera);
            this.Controls.Add(this.Btn_Crear_Respaldo);
            this.Name = "Form1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Crear_Respaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Espera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Comprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Mantenimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton Btn_Crear_Respaldo;
        private Telerik.WinControls.UI.RadWaitingBar Bar_Espera;
        private Telerik.WinControls.UI.RadButton Btn_Comprimir;
        private Telerik.WinControls.UI.RadButton Btn_Mantenimiento;
    }
}

