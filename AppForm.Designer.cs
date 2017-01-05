namespace FaceDetectionAndRecognition
{
    partial class FaceForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSaveFace = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.imgBoxCapturer = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCapturer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveFace
            // 
            this.btnSaveFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveFace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveFace.Location = new System.Drawing.Point(244, 340);
            this.btnSaveFace.Name = "btnSaveFace";
            this.btnSaveFace.Size = new System.Drawing.Size(165, 42);
            this.btnSaveFace.TabIndex = 3;
            this.btnSaveFace.Text = "Save";
            this.btnSaveFace.UseVisualStyleBackColor = true;
            this.btnSaveFace.Click += new System.EventHandler(this.btnSaveFace_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtName.Location = new System.Drawing.Point(12, 360);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(195, 22);
            this.txtName.TabIndex = 7;
            this.txtName.Tag = "Please type a name..";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 340);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name";
            // 
            // imgBoxCapturer
            // 
            this.imgBoxCapturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBoxCapturer.Location = new System.Drawing.Point(12, 12);
            this.imgBoxCapturer.Name = "imgBoxCapturer";
            this.imgBoxCapturer.Size = new System.Drawing.Size(397, 310);
            this.imgBoxCapturer.TabIndex = 4;
            this.imgBoxCapturer.TabStop = false;
            // 
            // FaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(423, 401);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnSaveFace);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.imgBoxCapturer);
            this.Name = "FaceForm";
            this.Text = "Face Detection and Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxCapturer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveFace;
        private Emgu.CV.UI.ImageBox imgBoxCapturer;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelName;
    }
}

