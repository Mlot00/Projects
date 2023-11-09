namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ESCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fieldsColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fieldsColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rookColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.oAutorzeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.krystianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.randomLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableRandLocationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.menuStrip2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(196, 145);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(8, 20);
			this.dateTimePicker1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(115, 81);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(644, 644);
			this.panel1.TabIndex = 2;
			this.panel1.TabStop = true;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
			// 
			// menuStrip2
			// 
			this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem,
            this.randomLocationToolStripMenuItem});
			this.menuStrip2.Location = new System.Drawing.Point(0, 0);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.Size = new System.Drawing.Size(884, 24);
			this.menuStrip2.TabIndex = 4;
			this.menuStrip2.Text = "menuStrip2";
			// 
			// MenuItem
			// 
			this.MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.ESCToolStripMenuItem,
            this.fieldsColorsToolStripMenuItem,
            this.fieldsColorToolStripMenuItem,
            this.rookColorToolStripMenuItem,
            this.oAutorzeToolStripMenuItem1});
			this.MenuItem.Name = "MenuItem";
			this.MenuItem.Size = new System.Drawing.Size(50, 20);
			this.MenuItem.Text = "Menu";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
			// 
			// ESCToolStripMenuItem
			// 
			this.ESCToolStripMenuItem.Checked = true;
			this.ESCToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ESCToolStripMenuItem.Name = "ESCToolStripMenuItem";
			this.ESCToolStripMenuItem.ShowShortcutKeys = false;
			this.ESCToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.ESCToolStripMenuItem.Text = "exit ESC";
			this.ESCToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ESCToolStripMenuItem_MouseDown);
			// 
			// fieldsColorsToolStripMenuItem
			// 
			this.fieldsColorsToolStripMenuItem.Name = "fieldsColorsToolStripMenuItem";
			this.fieldsColorsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.fieldsColorsToolStripMenuItem.Text = "1# fields color";
			this.fieldsColorsToolStripMenuItem.Click += new System.EventHandler(this.firstFieldsColorsToolStripMenuItem_Click);
			// 
			// fieldsColorToolStripMenuItem
			// 
			this.fieldsColorToolStripMenuItem.Name = "fieldsColorToolStripMenuItem";
			this.fieldsColorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.fieldsColorToolStripMenuItem.Text = "2# fields color";
			this.fieldsColorToolStripMenuItem.Click += new System.EventHandler(this.SecondFieldsColorToolStripMenuItem_Click);
			// 
			// rookColorToolStripMenuItem
			// 
			this.rookColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whiteToolStripMenuItem,
            this.blackToolStripMenuItem});
			this.rookColorToolStripMenuItem.Name = "rookColorToolStripMenuItem";
			this.rookColorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.rookColorToolStripMenuItem.Text = "rook color";
			// 
			// whiteToolStripMenuItem
			// 
			this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
			this.whiteToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.whiteToolStripMenuItem.Text = "white";
			this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
			// 
			// blackToolStripMenuItem
			// 
			this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
			this.blackToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.blackToolStripMenuItem.Text = "black";
			this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
			// 
			// oAutorzeToolStripMenuItem1
			// 
			this.oAutorzeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.krystianToolStripMenuItem});
			this.oAutorzeToolStripMenuItem1.Name = "oAutorzeToolStripMenuItem1";
			this.oAutorzeToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
			this.oAutorzeToolStripMenuItem1.Text = "author";
			// 
			// krystianToolStripMenuItem
			// 
			this.krystianToolStripMenuItem.Name = "krystianToolStripMenuItem";
			this.krystianToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.krystianToolStripMenuItem.Text = "Krystian Młot ";
			// 
			// randomLocationToolStripMenuItem
			// 
			this.randomLocationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableRandLocationMenuItem});
			this.randomLocationToolStripMenuItem.Name = "randomLocationToolStripMenuItem";
			this.randomLocationToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
			this.randomLocationToolStripMenuItem.Text = "Random location ";
			this.randomLocationToolStripMenuItem.MouseEnter += new System.EventHandler(this.randomLocationToolStripMenuItem_MouseEnter);
			// 
			// enableRandLocationMenuItem
			// 
			this.enableRandLocationMenuItem.Checked = true;
			this.enableRandLocationMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enableRandLocationMenuItem.Name = "enableRandLocationMenuItem";
			this.enableRandLocationMenuItem.Size = new System.Drawing.Size(109, 22);
			this.enableRandLocationMenuItem.Text = "Enable";
			this.enableRandLocationMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click_1);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(884, 25);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
			this.toolStripLabel1.Text = "toolStripLabel1";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(86, 22);
			this.toolStripLabel2.Text = "toolStripLabel2";
			// 
			// Form1
			// 
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(884, 861);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.menuStrip2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(900, 900);
			this.MinimumSize = new System.Drawing.Size(900, 900);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.menuStrip2.ResumeLayout(false);
			this.menuStrip2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAutorzeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ESCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem krystianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableRandLocationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldsColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldsColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rookColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
	}
}

