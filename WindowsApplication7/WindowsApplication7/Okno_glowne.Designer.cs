namespace WindowsApplication7
{
    partial class Okno_glowne
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otworzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_polaczenia = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Baza = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.uzytkownik = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlPrzyciski = new System.Windows.Forms.Panel();
            this.cbCzujniki = new System.Windows.Forms.CheckBox();
            this.bttnLogowanie = new System.Windows.Forms.Button();
            this.pnlCzujniki = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.oracleConnection1 = new Devart.Data.Oracle.OracleConnection();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlPrzyciski.SuspendLayout();
            this.pnlCzujniki.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(809, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otworzToolStripMenuItem,
            this.toolStripSeparator1,
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otworzToolStripMenuItem
            // 
            this.otworzToolStripMenuItem.Name = "otworzToolStripMenuItem";
            this.otworzToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.otworzToolStripMenuItem.Text = "Zamknij";
            this.otworzToolStripMenuItem.Click += new System.EventHandler(this.otworzToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.status_polaczenia,
            this.toolStripStatusLabel2,
            this.Baza,
            this.toolStripStatusLabel3,
            this.uzytkownik});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel1.Text = "Status po³¹czenia:";
            // 
            // status_polaczenia
            // 
            this.status_polaczenia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.status_polaczenia.Name = "status_polaczenia";
            this.status_polaczenia.Size = new System.Drawing.Size(74, 17);
            this.status_polaczenia.Text = "Nieaktywne";
            this.status_polaczenia.ToolTipText = "Nieaktywne";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel2.Text = "Baza:";
            // 
            // Baza
            // 
            this.Baza.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Baza.Name = "Baza";
            this.Baza.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel3.Text = "U¿ytkownik:";
            // 
            // uzytkownik
            // 
            this.uzytkownik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.uzytkownik.Name = "uzytkownik";
            this.uzytkownik.Size = new System.Drawing.Size(0, 17);
            // 
            // pnlPrzyciski
            // 
            this.pnlPrzyciski.Controls.Add(this.cbCzujniki);
            this.pnlPrzyciski.Controls.Add(this.bttnLogowanie);
            this.pnlPrzyciski.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrzyciski.Location = new System.Drawing.Point(0, 24);
            this.pnlPrzyciski.Name = "pnlPrzyciski";
            this.pnlPrzyciski.Size = new System.Drawing.Size(809, 33);
            this.pnlPrzyciski.TabIndex = 7;
            // 
            // cbCzujniki
            // 
            this.cbCzujniki.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbCzujniki.AutoSize = true;
            this.cbCzujniki.Location = new System.Drawing.Point(88, 5);
            this.cbCzujniki.Name = "cbCzujniki";
            this.cbCzujniki.Size = new System.Drawing.Size(71, 23);
            this.cbCzujniki.TabIndex = 1;
            this.cbCzujniki.Text = "   Czujniki   ";
            this.cbCzujniki.UseVisualStyleBackColor = true;
            this.cbCzujniki.CheckedChanged += new System.EventHandler(this.cbCzujniki_CheckedChanged);
            // 
            // bttnLogowanie
            // 
            this.bttnLogowanie.Location = new System.Drawing.Point(7, 5);
            this.bttnLogowanie.Name = "bttnLogowanie";
            this.bttnLogowanie.Size = new System.Drawing.Size(75, 23);
            this.bttnLogowanie.TabIndex = 0;
            this.bttnLogowanie.Text = "Loguj";
            this.bttnLogowanie.UseVisualStyleBackColor = true;
            this.bttnLogowanie.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pnlCzujniki
            // 
            this.pnlCzujniki.Controls.Add(this.groupBox1);
            this.pnlCzujniki.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCzujniki.Location = new System.Drawing.Point(0, 57);
            this.pnlCzujniki.Name = "pnlCzujniki";
            this.pnlCzujniki.Size = new System.Drawing.Size(200, 330);
            this.pnlCzujniki.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Czujniki";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 49);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(194, 278);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 33);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pobierz liste czujników";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 57);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 330);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // oracleConnection1
            // 
            this.oracleConnection1.Name = "oracleConnection1";
            this.oracleConnection1.Owner = this;
            // 
            // Okno_glowne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 409);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlCzujniki);
            this.Controls.Add(this.pnlPrzyciski);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Okno_glowne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obs³uga czujników";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlPrzyciski.ResumeLayout(false);
            this.pnlPrzyciski.PerformLayout();
            this.pnlCzujniki.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otworzToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel status_polaczenia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.Panel pnlPrzyciski;
        private System.Windows.Forms.Button bttnLogowanie;
        private System.Windows.Forms.Panel pnlCzujniki;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox cbCzujniki;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel Baza;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel uzytkownik;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private Devart.Data.Oracle.OracleConnection oracleConnection1;




    }
}

