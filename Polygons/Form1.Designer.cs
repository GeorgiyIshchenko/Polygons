
namespace Polygons
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фигураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кругToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.квадратToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.треугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сравнениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.радиусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.цветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фигураToolStripMenuItem,
            this.алгоритмToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фигураToolStripMenuItem
            // 
            this.фигураToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кругToolStripMenuItem,
            this.квадратToolStripMenuItem,
            this.треугольникToolStripMenuItem});
            this.фигураToolStripMenuItem.Name = "фигураToolStripMenuItem";
            this.фигураToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.фигураToolStripMenuItem.Text = "Фигура";
            this.фигураToolStripMenuItem.Click += new System.EventHandler(this.фигураToolStripMenuItem_Click);
            // 
            // кругToolStripMenuItem
            // 
            this.кругToolStripMenuItem.Checked = true;
            this.кругToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.кругToolStripMenuItem.Name = "кругToolStripMenuItem";
            this.кругToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.кругToolStripMenuItem.Text = "Круг";
            this.кругToolStripMenuItem.Click += new System.EventHandler(this.кругToolStripMenuItem_Click);
            // 
            // квадратToolStripMenuItem
            // 
            this.квадратToolStripMenuItem.Name = "квадратToolStripMenuItem";
            this.квадратToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.квадратToolStripMenuItem.Text = "Квадрат";
            this.квадратToolStripMenuItem.Click += new System.EventHandler(this.квадратToolStripMenuItem_Click);
            // 
            // треугольникToolStripMenuItem
            // 
            this.треугольникToolStripMenuItem.Name = "треугольникToolStripMenuItem";
            this.треугольникToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.треугольникToolStripMenuItem.Text = "Треугольник";
            this.треугольникToolStripMenuItem.Click += new System.EventHandler(this.треугольникToolStripMenuItem_Click);
            // 
            // алгоритмToolStripMenuItem
            // 
            this.алгоритмToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commonToolStripMenuItem,
            this.jarvisToolStripMenuItem,
            this.сравнениеToolStripMenuItem});
            this.алгоритмToolStripMenuItem.Name = "алгоритмToolStripMenuItem";
            this.алгоритмToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.алгоритмToolStripMenuItem.Text = "Алгоритм";
            // 
            // commonToolStripMenuItem
            // 
            this.commonToolStripMenuItem.Name = "commonToolStripMenuItem";
            this.commonToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.commonToolStripMenuItem.Text = "По определению";
            this.commonToolStripMenuItem.Click += new System.EventHandler(this.commonToolStripMenuItem_Click);
            // 
            // jarvisToolStripMenuItem
            // 
            this.jarvisToolStripMenuItem.Name = "jarvisToolStripMenuItem";
            this.jarvisToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.jarvisToolStripMenuItem.Text = "Джарвис";
            this.jarvisToolStripMenuItem.Click += new System.EventHandler(this.jarvisToolStripMenuItem_Click);
            // 
            // сравнениеToolStripMenuItem
            // 
            this.сравнениеToolStripMenuItem.Name = "сравнениеToolStripMenuItem";
            this.сравнениеToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.сравнениеToolStripMenuItem.Text = "Сравнение";
            this.сравнениеToolStripMenuItem.Click += new System.EventHandler(this.сравнениеToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.радиусToolStripMenuItem,
            this.цветToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // радиусToolStripMenuItem
            // 
            this.радиусToolStripMenuItem.Name = "радиусToolStripMenuItem";
            this.радиусToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.радиусToolStripMenuItem.Text = "Радиус";
            this.радиусToolStripMenuItem.Click += new System.EventHandler(this.радиусToolStripMenuItem_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(800, 443);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 27);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(800, 19);
            this.progressBar1.TabIndex = 2;
            // 
            // цветToolStripMenuItem
            // 
            this.цветToolStripMenuItem.Name = "цветToolStripMenuItem";
            this.цветToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.цветToolStripMenuItem.Text = "Цвет";
            this.цветToolStripMenuItem.Click += new System.EventHandler(this.цветToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chart1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фигураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кругToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem квадратToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem треугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сравнениеToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem радиусToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветToolStripMenuItem;
    }
}

