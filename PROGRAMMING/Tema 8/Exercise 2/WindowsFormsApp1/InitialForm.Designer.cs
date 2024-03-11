namespace Exercise_4
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
            this.btnIntroduceEquilateralTriangle = new System.Windows.Forms.Button();
            this.btnIntroduceRectangle = new System.Windows.Forms.Button();
            this.btnIntroduceRegularHexagon = new System.Windows.Forms.Button();
            this.btnShowAllRectangles = new System.Windows.Forms.Button();
            this.btnShowAllEquilateralTriangles = new System.Windows.Forms.Button();
            this.btnShowAllRegularHexagons = new System.Windows.Forms.Button();
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
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceRegularHexagon);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceRectangle);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceEquilateralTriangle);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceSquare);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceCircle);
            this.gbIntroduceFigures.Location = new System.Drawing.Point(12, 12);
            this.gbIntroduceFigures.Name = "gbIntroduceFigures";
            this.gbIntroduceFigures.Size = new System.Drawing.Size(382, 384);
            this.gbIntroduceFigures.TabIndex = 2;
            this.gbIntroduceFigures.TabStop = false;
            this.gbIntroduceFigures.Text = "Introduce";
            // 
            // gpShowFigures
            // 
            this.gpShowFigures.Controls.Add(this.btnShowAllRegularHexagons);
            this.gpShowFigures.Controls.Add(this.btnShowAllRectangles);
            this.gpShowFigures.Controls.Add(this.btnShowAllEquilateralTriangles);
            this.gpShowFigures.Controls.Add(this.btnShowAllSquares);
            this.gpShowFigures.Controls.Add(this.btnShowAllFigures);
            this.gpShowFigures.Controls.Add(this.btnShowAllCircles);
            this.gpShowFigures.Location = new System.Drawing.Point(12, 413);
            this.gpShowFigures.Name = "gpShowFigures";
            this.gpShowFigures.Size = new System.Drawing.Size(382, 446);
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
            this.btnShowAllSquares.Click += new System.EventHandler(this.btnShowAllSquares_Click);
            // 
            // btnShowAllFigures
            // 
            this.btnShowAllFigures.Location = new System.Drawing.Point(14, 30);
            this.btnShowAllFigures.Name = "btnShowAllFigures";
            this.btnShowAllFigures.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllFigures.TabIndex = 0;
            this.btnShowAllFigures.Text = "Shows All Figures";
            this.btnShowAllFigures.UseVisualStyleBackColor = true;
            this.btnShowAllFigures.Click += new System.EventHandler(this.btnShowAllFigures_Click);
            // 
            // btnShowAllCircles
            // 
            this.btnShowAllCircles.Location = new System.Drawing.Point(14, 97);
            this.btnShowAllCircles.Name = "btnShowAllCircles";
            this.btnShowAllCircles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllCircles.TabIndex = 1;
            this.btnShowAllCircles.Text = "Shows All Circles";
            this.btnShowAllCircles.UseVisualStyleBackColor = true;
            this.btnShowAllCircles.Click += new System.EventHandler(this.btnShowAllCircles_Click);
            // 
            // btnIntroduceEquilateralTriangle
            // 
            this.btnIntroduceEquilateralTriangle.Location = new System.Drawing.Point(15, 169);
            this.btnIntroduceEquilateralTriangle.Name = "btnIntroduceEquilateralTriangle";
            this.btnIntroduceEquilateralTriangle.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceEquilateralTriangle.TabIndex = 2;
            this.btnIntroduceEquilateralTriangle.Text = "Introduce Equilateral Triangle";
            this.btnIntroduceEquilateralTriangle.UseVisualStyleBackColor = true;
            this.btnIntroduceEquilateralTriangle.Click += new System.EventHandler(this.btnIntroduceEquilateralTriangle_Click);
            // 
            // btnIntroduceRectangle
            // 
            this.btnIntroduceRectangle.Location = new System.Drawing.Point(15, 238);
            this.btnIntroduceRectangle.Name = "btnIntroduceRectangle";
            this.btnIntroduceRectangle.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceRectangle.TabIndex = 3;
            this.btnIntroduceRectangle.Text = "Introduce Rectangle";
            this.btnIntroduceRectangle.UseVisualStyleBackColor = true;
            this.btnIntroduceRectangle.Click += new System.EventHandler(this.btnIntroduceRectangle_Click);
            // 
            // btnIntroduceRegularHexagon
            // 
            this.btnIntroduceRegularHexagon.Location = new System.Drawing.Point(15, 307);
            this.btnIntroduceRegularHexagon.Name = "btnIntroduceRegularHexagon";
            this.btnIntroduceRegularHexagon.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceRegularHexagon.TabIndex = 4;
            this.btnIntroduceRegularHexagon.Text = "Introduce Regular Hexagon";
            this.btnIntroduceRegularHexagon.UseVisualStyleBackColor = true;
            this.btnIntroduceRegularHexagon.Click += new System.EventHandler(this.btnIntroduceRegularHexagon_Click);
            // 
            // btnShowAllRectangles
            // 
            this.btnShowAllRectangles.Location = new System.Drawing.Point(14, 301);
            this.btnShowAllRectangles.Name = "btnShowAllRectangles";
            this.btnShowAllRectangles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllRectangles.TabIndex = 4;
            this.btnShowAllRectangles.Text = "Shows All Rectangles";
            this.btnShowAllRectangles.UseVisualStyleBackColor = true;
            this.btnShowAllRectangles.Click += new System.EventHandler(this.btnShowAllRectangles_Click);
            // 
            // btnShowAllEquilateralTriangles
            // 
            this.btnShowAllEquilateralTriangles.Location = new System.Drawing.Point(15, 233);
            this.btnShowAllEquilateralTriangles.Name = "btnShowAllEquilateralTriangles";
            this.btnShowAllEquilateralTriangles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllEquilateralTriangles.TabIndex = 3;
            this.btnShowAllEquilateralTriangles.Text = "Shows All Equilateral Triangles";
            this.btnShowAllEquilateralTriangles.UseVisualStyleBackColor = true;
            this.btnShowAllEquilateralTriangles.Click += new System.EventHandler(this.btnShowAllEquilateralTriangles_Click);
            // 
            // btnShowAllRegularHexagons
            // 
            this.btnShowAllRegularHexagons.Location = new System.Drawing.Point(15, 369);
            this.btnShowAllRegularHexagons.Name = "btnShowAllRegularHexagons";
            this.btnShowAllRegularHexagons.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllRegularHexagons.TabIndex = 5;
            this.btnShowAllRegularHexagons.Text = "Shows All Regular Hexagons";
            this.btnShowAllRegularHexagons.UseVisualStyleBackColor = true;
            this.btnShowAllRegularHexagons.Click += new System.EventHandler(this.btnShowAllRegularHexagons_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 880);
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
        private System.Windows.Forms.Button btnIntroduceRegularHexagon;
        private System.Windows.Forms.Button btnIntroduceRectangle;
        private System.Windows.Forms.Button btnIntroduceEquilateralTriangle;
        private System.Windows.Forms.Button btnShowAllRegularHexagons;
        private System.Windows.Forms.Button btnShowAllRectangles;
        private System.Windows.Forms.Button btnShowAllEquilateralTriangles;
    }
}

