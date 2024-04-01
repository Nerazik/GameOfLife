
namespace Praktika11
{
    partial class Game
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
			this.components = new System.ComponentModel.Container();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.ExitButton = new System.Windows.Forms.Button();
			this.CleanButton = new System.Windows.Forms.Button();
			this.PauseButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.GamePlace = new System.Windows.Forms.PictureBox();
			this.sizeBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.GamePlace)).BeginInit();
			this.SuspendLayout();
			// 
			// Timer
			// 
			this.Timer.Interval = 120;
			this.Timer.Tick += new System.EventHandler(this.TimerTick);
			// 
			// ExitButton
			// 
			this.ExitButton.BackColor = System.Drawing.Color.White;
			this.ExitButton.Location = new System.Drawing.Point(24, 181);
			this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(100, 28);
			this.ExitButton.TabIndex = 1;
			this.ExitButton.Text = "Выход";
			this.ExitButton.UseVisualStyleBackColor = false;
			this.ExitButton.Click += new System.EventHandler(this.Exit);
			this.ExitButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.HelpExit);
			// 
			// CleanButton
			// 
			this.CleanButton.BackColor = System.Drawing.Color.White;
			this.CleanButton.Location = new System.Drawing.Point(24, 130);
			this.CleanButton.Margin = new System.Windows.Forms.Padding(4);
			this.CleanButton.Name = "CleanButton";
			this.CleanButton.Size = new System.Drawing.Size(100, 28);
			this.CleanButton.TabIndex = 3;
			this.CleanButton.Text = "Заново";
			this.CleanButton.UseVisualStyleBackColor = false;
			this.CleanButton.Click += new System.EventHandler(this.ClearColors);
			this.CleanButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.HelpClean);
			// 
			// PauseButton
			// 
			this.PauseButton.BackColor = System.Drawing.Color.White;
			this.PauseButton.Location = new System.Drawing.Point(24, 80);
			this.PauseButton.Margin = new System.Windows.Forms.Padding(4);
			this.PauseButton.Name = "PauseButton";
			this.PauseButton.Size = new System.Drawing.Size(100, 28);
			this.PauseButton.TabIndex = 2;
			this.PauseButton.Text = "Стоп";
			this.PauseButton.UseVisualStyleBackColor = false;
			this.PauseButton.Click += new System.EventHandler(this.PauseClick);
			this.PauseButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.HelpStop);
			// 
			// StartButton
			// 
			this.StartButton.BackColor = System.Drawing.Color.White;
			this.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.StartButton.Location = new System.Drawing.Point(24, 30);
			this.StartButton.Margin = new System.Windows.Forms.Padding(4);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(100, 28);
			this.StartButton.TabIndex = 0;
			this.StartButton.Text = "Старт";
			this.StartButton.UseVisualStyleBackColor = false;
			this.StartButton.Click += new System.EventHandler(this.Start);
			this.StartButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.HelpStart);
			// 
			// GamePlace
			// 
			this.GamePlace.BackColor = System.Drawing.Color.White;
			this.GamePlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.GamePlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.GamePlace.Location = new System.Drawing.Point(148, 30);
			this.GamePlace.Margin = new System.Windows.Forms.Padding(4);
			this.GamePlace.Name = "GamePlace";
			this.GamePlace.Size = new System.Drawing.Size(900, 550);
			this.GamePlace.TabIndex = 0;
			this.GamePlace.TabStop = false;
			this.GamePlace.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.HelpGamePlace);
			this.GamePlace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PrintColor);
			// 
			// sizeBox
			// 
			this.sizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sizeBox.FormattingEnabled = true;
			this.sizeBox.Items.AddRange(new object[] {
            "Малый",
            "Средний",
            "Большой"});
			this.sizeBox.Location = new System.Drawing.Point(24, 234);
			this.sizeBox.Name = "sizeBox";
			this.sizeBox.Size = new System.Drawing.Size(100, 24);
			this.sizeBox.TabIndex = 4;
			this.sizeBox.SelectedIndexChanged += new System.EventHandler(this.updateBitmap);
			this.sizeBox.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.HelpSize);
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(1082, 603);
			this.Controls.Add(this.sizeBox);
			this.Controls.Add(this.GamePlace);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.CleanButton);
			this.Controls.Add(this.PauseButton);
			this.Controls.Add(this.StartButton);
			this.HelpButton = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1100, 650);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1100, 650);
			this.Name = "Game";
			this.Text = "Игра \"Жизнь\"";
			((System.ComponentModel.ISupportInitialize)(this.GamePlace)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox GamePlace;
		private System.Windows.Forms.ComboBox sizeBox;
	}
}

