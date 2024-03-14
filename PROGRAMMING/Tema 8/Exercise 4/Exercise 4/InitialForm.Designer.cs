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
            this.btnIntroduceRegularHexagon = new System.Windows.Forms.Button();
            this.btnIntroduceRectangle = new System.Windows.Forms.Button();
            this.btnIntroduceEquilateralTriangle = new System.Windows.Forms.Button();
            this.gpShowFigures = new System.Windows.Forms.GroupBox();
            this.btnShowAllRegularHexagons = new System.Windows.Forms.Button();
            this.btnShowAllRectangles = new System.Windows.Forms.Button();
            this.btnShowAllEquilateralTriangles = new System.Windows.Forms.Button();
            this.btnShowAllSquares = new System.Windows.Forms.Button();
            this.btnShowAllFigures = new System.Windows.Forms.Button();
            this.btnShowAllCircles = new System.Windows.Forms.Button();
            this.btnIntroduceIsoscelesTriangle = new System.Windows.Forms.Button();
            this.btnIntroduceScaleneTriangle = new System.Windows.Forms.Button();
            this.btnShowAllIsoscelesTriangles = new System.Windows.Forms.Button();
            this.btnShowAllScaleneTriangles = new System.Windows.Forms.Button();
            this.btnShowAllTriangles = new System.Windows.Forms.Button();
            this.gbIntroduceFigures.SuspendLayout();
            this.gpShowFigures.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIntroduceSquare
            // 
            this.btnIntroduceSquare.Location = new System.Drawing.Point(15, 30);
            this.btnIntroduceSquare.Name = "btnIntroduceSquare";
            this.btnIntroduceSquare.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceSquare.TabIndex = 0;
            this.btnIntroduceSquare.Text = "Introduce Square";
            this.btnIntroduceSquare.UseVisualStyleBackColor = true;
            this.btnIntroduceSquare.Click += new System.EventHandler(this.btnIntroduceSquareData_Click);
            // 
            // btnIntroduceCircle
            // 
            this.btnIntroduceCircle.Location = new System.Drawing.Point(399, 30);
            this.btnIntroduceCircle.Name = "btnIntroduceCircle";
            this.btnIntroduceCircle.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceCircle.TabIndex = 1;
            this.btnIntroduceCircle.Text = "Introduce Circle\r\n";
            this.btnIntroduceCircle.UseVisualStyleBackColor = true;
            this.btnIntroduceCircle.Click += new System.EventHandler(this.btnIntroduceCircleData_Click);
            // 
            // gbIntroduceFigures
            // 
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceScaleneTriangle);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceIsoscelesTriangle);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceRegularHexagon);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceRectangle);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceEquilateralTriangle);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceSquare);
            this.gbIntroduceFigures.Controls.Add(this.btnIntroduceCircle);
            this.gbIntroduceFigures.Location = new System.Drawing.Point(12, 12);
            this.gbIntroduceFigures.Name = "gbIntroduceFigures";
            this.gbIntroduceFigures.Size = new System.Drawing.Size(770, 301);
            this.gbIntroduceFigures.TabIndex = 2;
            this.gbIntroduceFigures.TabStop = false;
            this.gbIntroduceFigures.Text = "Introduce";
            // 
            // btnIntroduceRegularHexagon
            // 
            this.btnIntroduceRegularHexagon.Location = new System.Drawing.Point(15, 96);
            this.btnIntroduceRegularHexagon.Name = "btnIntroduceRegularHexagon";
            this.btnIntroduceRegularHexagon.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceRegularHexagon.TabIndex = 4;
            this.btnIntroduceRegularHexagon.Text = "Introduce Regular Hexagon";
            this.btnIntroduceRegularHexagon.UseVisualStyleBackColor = true;
            this.btnIntroduceRegularHexagon.Click += new System.EventHandler(this.btnIntroduceRegularHexagon_Click);
            // 
            // btnIntroduceRectangle
            // 
            this.btnIntroduceRectangle.Location = new System.Drawing.Point(399, 96);
            this.btnIntroduceRectangle.Name = "btnIntroduceRectangle";
            this.btnIntroduceRectangle.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceRectangle.TabIndex = 3;
            this.btnIntroduceRectangle.Text = "Introduce Rectangle";
            this.btnIntroduceRectangle.UseVisualStyleBackColor = true;
            this.btnIntroduceRectangle.Click += new System.EventHandler(this.btnIntroduceRectangle_Click);
            // 
            // btnIntroduceEquilateralTriangle
            // 
            this.btnIntroduceEquilateralTriangle.Location = new System.Drawing.Point(15, 162);
            this.btnIntroduceEquilateralTriangle.Name = "btnIntroduceEquilateralTriangle";
            this.btnIntroduceEquilateralTriangle.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceEquilateralTriangle.TabIndex = 2;
            this.btnIntroduceEquilateralTriangle.Text = "Introduce Equilateral Triangle";
            this.btnIntroduceEquilateralTriangle.UseVisualStyleBackColor = true;
            this.btnIntroduceEquilateralTriangle.Click += new System.EventHandler(this.btnIntroduceEquilateralTriangle_Click);
            // 
            // gpShowFigures
            // 
            this.gpShowFigures.Controls.Add(this.btnShowAllTriangles);
            this.gpShowFigures.Controls.Add(this.btnShowAllScaleneTriangles);
            this.gpShowFigures.Controls.Add(this.btnShowAllIsoscelesTriangles);
            this.gpShowFigures.Controls.Add(this.btnShowAllRegularHexagons);
            this.gpShowFigures.Controls.Add(this.btnShowAllRectangles);
            this.gpShowFigures.Controls.Add(this.btnShowAllEquilateralTriangles);
            this.gpShowFigures.Controls.Add(this.btnShowAllSquares);
            this.gpShowFigures.Controls.Add(this.btnShowAllFigures);
            this.gpShowFigures.Controls.Add(this.btnShowAllCircles);
            this.gpShowFigures.Location = new System.Drawing.Point(12, 319);
            this.gpShowFigures.Name = "gpShowFigures";
            this.gpShowFigures.Size = new System.Drawing.Size(770, 378);
            this.gpShowFigures.TabIndex = 3;
            this.gpShowFigures.TabStop = false;
            this.gpShowFigures.Text = "Show";
            // 
            // btnShowAllRegularHexagons
            // 
            this.btnShowAllRegularHexagons.Location = new System.Drawing.Point(15, 235);
            this.btnShowAllRegularHexagons.Name = "btnShowAllRegularHexagons";
            this.btnShowAllRegularHexagons.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllRegularHexagons.TabIndex = 5;
            this.btnShowAllRegularHexagons.Text = "Shows All Regular Hexagons";
            this.btnShowAllRegularHexagons.UseVisualStyleBackColor = true;
            this.btnShowAllRegularHexagons.Click += new System.EventHandler(this.btnShowAllRegularHexagons_Click);
            // 
            // btnShowAllRectangles
            // 
            this.btnShowAllRectangles.Location = new System.Drawing.Point(15, 168);
            this.btnShowAllRectangles.Name = "btnShowAllRectangles";
            this.btnShowAllRectangles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllRectangles.TabIndex = 4;
            this.btnShowAllRectangles.Text = "Shows All Rectangles";
            this.btnShowAllRectangles.UseVisualStyleBackColor = true;
            this.btnShowAllRectangles.Click += new System.EventHandler(this.btnShowAllRectangles_Click);
            // 
            // btnShowAllEquilateralTriangles
            // 
            this.btnShowAllEquilateralTriangles.Location = new System.Drawing.Point(399, 101);
            this.btnShowAllEquilateralTriangles.Name = "btnShowAllEquilateralTriangles";
            this.btnShowAllEquilateralTriangles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllEquilateralTriangles.TabIndex = 3;
            this.btnShowAllEquilateralTriangles.Text = "Shows All Equilateral Triangles";
            this.btnShowAllEquilateralTriangles.UseVisualStyleBackColor = true;
            this.btnShowAllEquilateralTriangles.Click += new System.EventHandler(this.btnShowAllEquilateralTriangles_Click);
            // 
            // btnShowAllSquares
            // 
            this.btnShowAllSquares.Location = new System.Drawing.Point(15, 101);
            this.btnShowAllSquares.Name = "btnShowAllSquares";
            this.btnShowAllSquares.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllSquares.TabIndex = 2;
            this.btnShowAllSquares.Text = "Shows All Squares";
            this.btnShowAllSquares.UseVisualStyleBackColor = true;
            this.btnShowAllSquares.Click += new System.EventHandler(this.btnShowAllSquares_Click);
            // 
            // btnShowAllFigures
            // 
            this.btnShowAllFigures.Location = new System.Drawing.Point(16, 305);
            this.btnShowAllFigures.Name = "btnShowAllFigures";
            this.btnShowAllFigures.Size = new System.Drawing.Size(738, 50);
            this.btnShowAllFigures.TabIndex = 0;
            this.btnShowAllFigures.Text = "Shows All Figures";
            this.btnShowAllFigures.UseVisualStyleBackColor = true;
            this.btnShowAllFigures.Click += new System.EventHandler(this.btnShowAllFigures_Click);
            // 
            // btnShowAllCircles
            // 
            this.btnShowAllCircles.Location = new System.Drawing.Point(15, 33);
            this.btnShowAllCircles.Name = "btnShowAllCircles";
            this.btnShowAllCircles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllCircles.TabIndex = 1;
            this.btnShowAllCircles.Text = "Shows All Circles";
            this.btnShowAllCircles.UseVisualStyleBackColor = true;
            this.btnShowAllCircles.Click += new System.EventHandler(this.btnShowAllCircles_Click);
            // 
            // btnIntroduceIsoscelesTriangle
            // 
            this.btnIntroduceIsoscelesTriangle.Location = new System.Drawing.Point(399, 162);
            this.btnIntroduceIsoscelesTriangle.Name = "btnIntroduceIsoscelesTriangle";
            this.btnIntroduceIsoscelesTriangle.Size = new System.Drawing.Size(354, 50);
            this.btnIntroduceIsoscelesTriangle.TabIndex = 5;
            this.btnIntroduceIsoscelesTriangle.Text = "Introduce Isosceles Triangle";
            this.btnIntroduceIsoscelesTriangle.UseVisualStyleBackColor = true;
            this.btnIntroduceIsoscelesTriangle.Click += new System.EventHandler(this.btnIntroduceIsoscelesTriangle_Click);
            // 
            // btnIntroduceScaleneTriangle
            // 
            this.btnIntroduceScaleneTriangle.Location = new System.Drawing.Point(16, 228);
            this.btnIntroduceScaleneTriangle.Name = "btnIntroduceScaleneTriangle";
            this.btnIntroduceScaleneTriangle.Size = new System.Drawing.Size(737, 50);
            this.btnIntroduceScaleneTriangle.TabIndex = 6;
            this.btnIntroduceScaleneTriangle.Text = "Introduce Scalene Triangle";
            this.btnIntroduceScaleneTriangle.UseVisualStyleBackColor = true;
            this.btnIntroduceScaleneTriangle.Click += new System.EventHandler(this.btnIntroduceScaleneTriangle_Click);
            // 
            // btnShowAllIsoscelesTriangles
            // 
            this.btnShowAllIsoscelesTriangles.Location = new System.Drawing.Point(399, 168);
            this.btnShowAllIsoscelesTriangles.Name = "btnShowAllIsoscelesTriangles";
            this.btnShowAllIsoscelesTriangles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllIsoscelesTriangles.TabIndex = 6;
            this.btnShowAllIsoscelesTriangles.Text = "Shows All Isosceles Triangles";
            this.btnShowAllIsoscelesTriangles.UseVisualStyleBackColor = true;
            this.btnShowAllIsoscelesTriangles.Click += new System.EventHandler(this.btnShowAllIsoscelesTriangles_Click);
            // 
            // btnShowAllScaleneTriangles
            // 
            this.btnShowAllScaleneTriangles.Location = new System.Drawing.Point(399, 235);
            this.btnShowAllScaleneTriangles.Name = "btnShowAllScaleneTriangles";
            this.btnShowAllScaleneTriangles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllScaleneTriangles.TabIndex = 7;
            this.btnShowAllScaleneTriangles.Text = "Shows All Scalene Triangles";
            this.btnShowAllScaleneTriangles.UseVisualStyleBackColor = true;
            this.btnShowAllScaleneTriangles.Click += new System.EventHandler(this.btnShowAllScaleneTriangles_Click);
            // 
            // btnShowAllTriangles
            // 
            this.btnShowAllTriangles.Location = new System.Drawing.Point(399, 33);
            this.btnShowAllTriangles.Name = "btnShowAllTriangles";
            this.btnShowAllTriangles.Size = new System.Drawing.Size(354, 50);
            this.btnShowAllTriangles.TabIndex = 8;
            this.btnShowAllTriangles.Text = "Shows All Triangles";
            this.btnShowAllTriangles.UseVisualStyleBackColor = true;
            this.btnShowAllTriangles.Click += new System.EventHandler(this.btnShowAllTriangles_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 718);
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
        private System.Windows.Forms.Button btnIntroduceScaleneTriangle;
        private System.Windows.Forms.Button btnIntroduceIsoscelesTriangle;
        private System.Windows.Forms.Button btnShowAllTriangles;
        private System.Windows.Forms.Button btnShowAllScaleneTriangles;
        private System.Windows.Forms.Button btnShowAllIsoscelesTriangles;
    }
}

