namespace FlightSystemWinForm
{
    partial class MainForm
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
            changeStatusBtn = new Button();
            flightsLbl = new Label();
            flightStatusLbl = new Label();
            flightsComboBox = new ComboBox();
            flightStatusComboBox = new ComboBox();
            SuspendLayout();
            // 
            // changeStatusBtn
            // 
            changeStatusBtn.Location = new Point(12, 77);
            changeStatusBtn.Name = "changeStatusBtn";
            changeStatusBtn.Size = new Size(83, 28);
            changeStatusBtn.TabIndex = 0;
            changeStatusBtn.Text = "Change";
            changeStatusBtn.UseVisualStyleBackColor = true;
            changeStatusBtn.Click += changeStatusBtn_Click;
            // 
            // flightsLbl
            // 
            flightsLbl.AutoSize = true;
            flightsLbl.Location = new Point(12, 9);
            flightsLbl.Name = "flightsLbl";
            flightsLbl.Size = new Size(45, 15);
            flightsLbl.TabIndex = 1;
            flightsLbl.Text = "Flights:";
            // 
            // flightStatusLbl
            // 
            flightStatusLbl.AutoSize = true;
            flightStatusLbl.Location = new Point(12, 51);
            flightStatusLbl.Name = "flightStatusLbl";
            flightStatusLbl.Size = new Size(75, 15);
            flightStatusLbl.TabIndex = 2;
            flightStatusLbl.Text = "Flight Status:";
            // 
            // flightsComboBox
            // 
            flightsComboBox.FormattingEnabled = true;
            flightsComboBox.Location = new Point(90, 6);
            flightsComboBox.Name = "flightsComboBox";
            flightsComboBox.Size = new Size(121, 23);
            flightsComboBox.TabIndex = 3;
            // 
            // flightStatusComboBox
            // 
            flightStatusComboBox.FormattingEnabled = true;
            flightStatusComboBox.Location = new Point(90, 48);
            flightStatusComboBox.Name = "flightStatusComboBox";
            flightStatusComboBox.Size = new Size(121, 23);
            flightStatusComboBox.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flightStatusComboBox);
            Controls.Add(flightsComboBox);
            Controls.Add(flightStatusLbl);
            Controls.Add(flightsLbl);
            Controls.Add(changeStatusBtn);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button changeStatusBtn;
        private Label flightsLbl;
        private Label flightStatusLbl;
        private ComboBox flightsComboBox;
        private ComboBox flightStatusComboBox;
    }
}
