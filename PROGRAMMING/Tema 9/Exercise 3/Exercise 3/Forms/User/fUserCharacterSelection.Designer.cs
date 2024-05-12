namespace Exercise_3.Forms.User
{
    partial class fUserCharacterSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectPrevious = new System.Windows.Forms.Button();
            this.btnSelectNext = new System.Windows.Forms.Button();
            this.gbCharacterSelection = new System.Windows.Forms.GroupBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pbCharacterSelected = new System.Windows.Forms.PictureBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.gbCharacterSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectPrevious
            // 
            this.btnSelectPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPrevious.Location = new System.Drawing.Point(23, 411);
            this.btnSelectPrevious.Name = "btnSelectPrevious";
            this.btnSelectPrevious.Size = new System.Drawing.Size(103, 41);
            this.btnSelectPrevious.TabIndex = 3;
            this.btnSelectPrevious.Text = "<----";
            this.btnSelectPrevious.UseVisualStyleBackColor = true;
            this.btnSelectPrevious.Click += new System.EventHandler(this.btnSelectPrevious_Click);
            // 
            // btnSelectNext
            // 
            this.btnSelectNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNext.Location = new System.Drawing.Point(264, 411);
            this.btnSelectNext.Name = "btnSelectNext";
            this.btnSelectNext.Size = new System.Drawing.Size(103, 41);
            this.btnSelectNext.TabIndex = 2;
            this.btnSelectNext.Text = "---->";
            this.btnSelectNext.UseVisualStyleBackColor = true;
            this.btnSelectNext.Click += new System.EventHandler(this.btnSelectNext_Click);
            // 
            // gbCharacterSelection
            // 
            this.gbCharacterSelection.Controls.Add(this.btnPlay);
            this.gbCharacterSelection.Controls.Add(this.pbCharacterSelected);
            this.gbCharacterSelection.Controls.Add(this.btnSelectNext);
            this.gbCharacterSelection.Controls.Add(this.btnSelectPrevious);
            this.gbCharacterSelection.Controls.Add(this.lblRecord);
            this.gbCharacterSelection.Controls.Add(this.lblCharacterName);
            this.gbCharacterSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCharacterSelection.Location = new System.Drawing.Point(12, 12);
            this.gbCharacterSelection.Name = "gbCharacterSelection";
            this.gbCharacterSelection.Size = new System.Drawing.Size(397, 474);
            this.gbCharacterSelection.TabIndex = 23;
            this.gbCharacterSelection.TabStop = false;
            this.gbCharacterSelection.Text = "CHARACTER SELECTION";
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(145, 411);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(103, 41);
            this.btnPlay.TabIndex = 12;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pbCharacterSelected
            // 
            this.pbCharacterSelected.Location = new System.Drawing.Point(23, 76);
            this.pbCharacterSelected.Name = "pbCharacterSelected";
            this.pbCharacterSelected.Size = new System.Drawing.Size(344, 316);
            this.pbCharacterSelected.TabIndex = 11;
            this.pbCharacterSelected.TabStop = false;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(169, 0);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(0, 20);
            this.lblRecord.TabIndex = 10;
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterName.Location = new System.Drawing.Point(142, 34);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(86, 29);
            this.lblCharacterName.TabIndex = 1;
            this.lblCharacterName.Text = "NAME";
            this.lblCharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fUserCharacterSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 502);
            this.Controls.Add(this.gbCharacterSelection);
            this.Name = "fUserCharacterSelection";
            this.Text = "Character Selection";
            this.Load += new System.EventHandler(this.fUserCharacterSelection_Load);
            this.gbCharacterSelection.ResumeLayout(false);
            this.gbCharacterSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterSelected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSelectPrevious;
        private System.Windows.Forms.Button btnSelectNext;
        private System.Windows.Forms.GroupBox gbCharacterSelection;
        private System.Windows.Forms.PictureBox pbCharacterSelected;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Button btnPlay;
    }
}