namespace AnalogClock
{
    partial class MainForm
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
            this.analogClockControl2 = new AnalogClockControl.AnalogClockControl();
            this.SuspendLayout();
            // 
            // analogClockControl2
            // 
            this.analogClockControl2.Location = new System.Drawing.Point(32, 24);
            this.analogClockControl2.Name = "analogClockControl2";
            this.analogClockControl2.Size = new System.Drawing.Size(240, 213);
            this.analogClockControl2.TabIndex = 0;
            this.analogClockControl2.TimeZone = null;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.analogClockControl2);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AnalogClockControl.AnalogClockControl analogClockControl1;
        private AnalogClockControl.AnalogClockControl analogClockControl2;
    }
}

