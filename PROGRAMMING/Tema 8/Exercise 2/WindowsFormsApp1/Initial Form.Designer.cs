namespace Exercise_2
{
    partial class InitialForm
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
            this.btnIntroduceSquare = new System.Windows.Forms.Button();
            this.btnIntroduceCircle = new System.Windows.Forms.Button();
            this.gbIntroduceFigures = new System.Windows.Forms.GroupBox();
            this.gpShowFigures = new System.Windows.Forms.GroupBox();
            this.btnShowAllSquares = new System.Windows.Forms.Button();
            this.btnShowAllFigures = new System.Windows.Forms.Button();
            this.btnShowAllCircles = new System.Windows.Forms.Button();
            this.gbIntroduceFigures.SuspendLayout();
            this.gpShowFigures.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIntroduceSquare
            // 
            this.btnIntroduceSquare.Location = new System.Drawing.Point(14, 30);
            this.btnIntroduceSquare.Name = "btnIntroduceSquare";
            this.btnIntroduceSquare.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceSquare.TabIndex = 0;
            this.btnIntroduceSquare.Text = "Introduce Square";
            this.btnIntroduceSquare.UseVisualStyleBackColor = true;
            this.btnIntroduceSquare.Click += new System.EventHandler(this.btnIntroduceSquareData_Click);
            // 
            // btnIntroduceCircle
            // 
            this.btnIntroduceCircle.Location = new System.Drawing.Point(14, 97);
            this.btnIntroduceCircle.Name = "btnIntroduceCircle";
            this.btnIntroduceCircle.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceCircle.TabIndex = 1;
            this.btnIntroduceCircle.Text = "Introduce Circle\r\n";
            this.btnIntroduceCircle.UseVisualStyleBackColor = true;
            this.btnIntroduceCircle.Click += new System.EventHandler(this.btnIntroduceCircleData_Click);
            // 
            // gbIntroduceFigures
            // 
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceSquare);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceCircle);
            this.gbIntroduceFigures.Location = new System.Drawing.Point(12, 12);
            this.gbIntroduceFigures.Name = "gbIntroduceFigures";
            this.gbIntroduceFigures.Size = new System.Drawing.Size(382, 175);
            this.gbIntroduceFigures.TabIndex = 2;
            this.gbIntroduceFigures.TabStop = false;
            this.gbIntroduceFigures.Text = "Introduce";
            // 
            // gpShowFigures
            // 
            this.gpShowFigures.Controls.Add(this.btnShowAllSquares);
            this.gpShowFigures.Controls.Add(this.btnShowAllFigures);
            this.gpShowFigures.Controls.Add(this.btnShowAllCircles);
            this.gpShowFigures.Location = new System.Drawing.Point(13, 193);
            this.gpShowFigures.Name = "gpShowFigures";
            this.gpShowFigures.Size = new System.Drawing.Size(382, 236);
            this.gpShowFigures.TabIndex = 3;
            this.gpShowFigures.TabStop = false;
            this.gpShowFigures.Text = "Show";
            // 
            // btnShowAllSquares
            // 
            this.btnShowAllSquares.Location = new System.Drawing.Point(13, 165);
            this.btnShowAllSquares.Name = "btnShowAllSquares";
            this.btnShowAllSquares.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllSquares.TabIndex = 2;
            this.btnShowAllSquares.Text = "Shows All Squares";
            this.btnShowAllSquares.UseVisualStyleBackColor = true;
            // 
            // btnShowAllFigures
            // 
            this.btnShowAllFigures.Location = new System.Drawing.Point(14, 30);
            this.btnShowAllFigures.Name = "btnShowAllFigures";
            this.btnShowAllFigures.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllFigures.TabIndex = 0;
            this.btnShowAllFigures.Text = "Shows All Figures";
            this.btnShowAllFigures.UseVisualStyleBackColor = true;
            // 
            // btnShowAllCircles
            // 
            this.btnShowAllCircles.Location = new System.Drawing.Point(14, 97);
            this.btnShowAllCircles.Name = "btnShowAllCircles";
            this.btnShowAllCircles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllCircles.TabIndex = 1;
            this.btnShowAllCircles.Text = "Shows All CirclesForm";
            this.btnShowAllCircles.UseVisualStyleBackColor = true;
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 445);
            this.Controls.Add(this.gpShowFigures);
            this.Controls.Add(this.gbIntroduceFigures);
            this.Name = "InitialForm";
            this.Text = "Initial Form";
            this.Load += new System.EventHandler(this.InitialForm_Load);
            this.gbIntroduceFigures.ResumeLayout(false);
            this.gpShowFigures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIntroduceSquare;
        private System.Windows.Forms.Button btnIntroduceCircle;
        private System.Windows.Forms.GroupBox gbIntroduceFigures;
        private System.Windows.Forms.GroupBox gpShowFigures;
        private System.Windows.Forms.Button btnShowAllSquares;
        private System.Windows.Forms.Button btnShowAllFigures;
        private System.Windows.Forms.Button btnShowAllCircles;
    }
}

