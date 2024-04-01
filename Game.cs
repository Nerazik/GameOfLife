using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Praktika11
{
	public partial class Game : Form
	{
        private Graphics Grafica;
        private int CellSize = 10;  
        private bool[,] RedCells;  
        private bool[,] BlueCells; 
        private int Rows; 
        private int Columns;
		private List<bool[,]> ArraysForCheckEquals = new List<bool[,]>() { null, null }; // Список для хранения предыдущих состояний

		public Game()
        {
            InitializeComponent();
			SwitchEnableButtons(false);
			sizeBox.SelectedIndex = 1;
		}

        private void StartGame()  //При начале игры запустить таймер
        {
			if (Timer.Enabled)
			{
				return;
			}
			Timer.Start();
			// Сохранение начального состояния
			ArraysForCheckEquals[0] = RedCells;
			ArraysForCheckEquals[1] = BlueCells;
		}
        private int CountNeighbors(int x, int y, bool[,] a)  //Подсчет кол-ва соседей клетки
        {
            int CountNeighbors = 0;  
            for (int i = -1; i < 2; i++)  //В циклах обрабатываем всех соседей
            {
                for (int j = -1; j < 2; j++)
                {
                    int NeighboringCol = (x + i + Columns) % Columns; //Нахождение соседних столбцов
                    int NeighboringRow = (y + j + Rows) % Rows; //Нахождение соседних строк
                    bool Samoproverka = NeighboringCol == x && NeighboringRow == y; //является ли проверка соседа самопроверкой
                    bool IsAlive = a[NeighboringCol, NeighboringRow];
                    if (IsAlive && !Samoproverka)  //Если клетка имеет жизнь и не самопроверка, увеличить кол-во соседей
                    {
                        CountNeighbors++; 
                    }
                }
            }
            return CountNeighbors;
        }

        private void NextGeneration()  //Просчет следующего поколения
        {
            Grafica.Clear(Color.White);  //Очистить поле
            var NewRedCells = new bool[Columns, Rows];
            var NewBlueCells = new bool[Columns, Rows];
            for (int x = 0; x < Columns; x++)  //2 цикла for для прохода по всем клеткам массивов 
            {
                for (int y = 0; y < Rows; y++)
                {
                    int NeighborsRed = CountNeighbors(x, y, RedCells);
                    bool IsAliveRed = RedCells[x, y];  
                    int NeighborsBlue = CountNeighbors(x, y, BlueCells); 
                    bool IsAliveBlue = BlueCells[x, y]; 
                    if (IsAliveRed && !IsAliveBlue && NeighborsBlue == 3) //если синяя клетка появляется там, где жива красная
                    {
                        NewRedCells[x, y] = false;
                        NewBlueCells[x, y] = true;
                        Grafica.FillRectangle(Brushes.Blue, x * CellSize, y * CellSize, CellSize - 1, CellSize - 1);
                        continue; 
                    }
                    if (IsAliveBlue && !IsAliveRed && NeighborsRed == 3)  //если красная клетка появляется там, где жива синяя 
                    {
                        NewRedCells[x, y] = true;
                        NewBlueCells[x, y] = false;
                        Grafica.FillRectangle(Brushes.Red, x * CellSize, y * CellSize, CellSize - 1, CellSize - 1);
                        continue;  
                    }
                    if ((!IsAliveRed && !IsAliveBlue) && (NeighborsRed == 3 && NeighborsBlue == 3))  //если синяя и красная на пустой
                    {
                        NewBlueCells[x, y] = true;  
                        Grafica.FillRectangle(Brushes.Red, x * CellSize, y * CellSize, CellSize - 1, CellSize - 1);
                        continue; 
                    }

                    if (!IsAliveRed && NeighborsRed == 3)  //если клетка пуста и 3 соседа красных 
                    {
                        NewRedCells[x, y] = true; 
                    }
                    else if (IsAliveRed && (NeighborsRed < 2 || NeighborsRed > 3)) //если красная жива и рядом меньше 2 или больше 3 соседей
                    {
                        NewRedCells[x, y] = false; 
                    }
                    else //Если ни одно условие не сработало, клетка остаётся такой же
                    {
                        NewRedCells[x, y] = RedCells[x, y];
                    }

                    if (!IsAliveBlue && NeighborsBlue == 3) //если клетка пуста и имеет 3 соседа синих
                    {
                        NewBlueCells[x, y] = true; 
                    }
                    else if (IsAliveBlue && (NeighborsBlue < 2 || NeighborsBlue > 3))  //если синяя клетка жива и рядом меньше 2 или больше 3 соседей
                    {
                        NewBlueCells[x, y] = false;
                    }
                    else //Если ни одно условие не сработало, клетка остаётся такой же
                    {
                        NewBlueCells[x, y] = BlueCells[x, y];
                    }

                    if (NewRedCells[x, y])  //Если клетка по координатам красная, то покрасить клетку
                    {
                        Grafica.FillRectangle(Brushes.Red, x * CellSize, y * CellSize, CellSize - 1, CellSize - 1);
                    }
                    else if (NewBlueCells[x, y])  //Если клетка по координатам синяя, то покрасить клетку
                    {
                        Grafica.FillRectangle(Brushes.Blue, x * CellSize, y * CellSize, CellSize - 1, CellSize - 1);
                    }
                }
            }
            RedCells = NewRedCells; //Новые поколения становятся текущими
            BlueCells = NewBlueCells;  
            GamePlace.Refresh();  //Отрисовываются изменения
        }

        private void TimerTick(object sender, EventArgs e)  //Каждый тик расчитывать новое поколение
        {
			NextGeneration();
			if (new Random().Next(10) == 1) // С 10% вероятностью сохранять текущее состояние для проверки
			{
				ArraysForCheckEquals[0] = RedCells;
				ArraysForCheckEquals[1] = BlueCells;
			}
			else
			{
				if (IsStateEquals()) // Проверка совпадения состояний с сохраненным
				{
					PauseClick(null, null);
					MessageBox.Show("Состояние повторилось. Игра окончена.");
				}
			}
		}

		private bool IsStateEquals() // Проверка текущего состояния с сохраненным
		{
			for (int x = 0; x < RedCells.GetLength(0); x++) // Сравнение красных
			{
				for (int y = 0; y < RedCells.GetLength(1); y++)
				{
					if (RedCells[x, y] != ArraysForCheckEquals[0][x, y]) // Если состояние клетки не совпало, значит есть различия
					{
						return false;
					}
				}
			}
			for (int x = 0; x < BlueCells.GetLength(0); x++) // Сравнение синих
			{
				for (int y = 0; y < BlueCells.GetLength(1); y++)
				{
					if (BlueCells[x, y] != ArraysForCheckEquals[1][x, y]) // Если состояние клетки не совпало, значит есть различия
					{
						return false;
					}
				}
			}
			return true;
		}

		private void PauseClick(object sender, EventArgs e)  //Пауза
        {
            Timer.Enabled = !Timer.Enabled;
            Bitmap bitmap = (Bitmap)GamePlace.Image;
            GamePlace.Image = bitmap;  //Создаём сетку игры 
            Grafica = Graphics.FromImage(GamePlace.Image);  //Переносим сетку в изображение
            for (int i = CellSize - 1; i < bitmap.Width; i += CellSize)
            {
                Grafica.DrawLine(Pens.Black, i, 0, i, bitmap.Height);
            }
            for (int i = CellSize - 1; i < bitmap.Height; i += CellSize)
            {
                Grafica.DrawLine(Pens.Black, 0, i, bitmap.Width, i);
            }
			SwitchEnableButtons(false);
		}

        private void PrintColor(object sender, MouseEventArgs e)  //Закрасить клетку
        {
            if (Timer.Enabled)  //Если таймер включен, то рисовать нельзя
            {
                return;
            }
            int MousePosX = e.Location.X / CellSize;  //координаты клика
            int MousePosY = e.Location.Y / CellSize;  

            if (ClickPositionCheck(MousePosX, MousePosY))  //если координата клетки в пределах поля
            {
                if (e.Button == MouseButtons.Left)  //если нажата ЛКМ
                {
                    if (RedCells[MousePosX, MousePosY])  //если клетка уже существует - стереть
                    {
                        RedCells[MousePosX, MousePosY] = false;  
                        Grafica.FillRectangle(Brushes.White, MousePosX * CellSize, MousePosY * CellSize, CellSize - 1, CellSize - 1);
                    }
                    else  //если клетки ещё не существует - создать
                    {
                        RedCells[MousePosX, MousePosY] = true;  
                        Grafica.FillRectangle(Brushes.Red, MousePosX * CellSize, MousePosY * CellSize, CellSize - 1, CellSize - 1);
                    }
                }
                if (e.Button == MouseButtons.Right)  //если нажата ПКМ
                {
                    if (BlueCells[MousePosX, MousePosY])  //если клетка уже существует - стереть
                    {
                        BlueCells[MousePosX, MousePosY] = false; 
                        Grafica.FillRectangle(Brushes.White, MousePosX * CellSize, MousePosY * CellSize, CellSize - 1, CellSize - 1);
                    }
                    else  //если клетки ещё не существует - создать
                    {
                        BlueCells[MousePosX, MousePosY] = true;
                        Grafica.FillRectangle(Brushes.Blue, MousePosX * CellSize, MousePosY * CellSize, CellSize - 1, CellSize - 1);
                    }
                }
            }
            GamePlace.Refresh();  //Отобразить изменения
        }

        private bool ClickPositionCheck(int MousePosX, int MousePosY)  //Проверка нахождение клика в границах поля
        {
            return MousePosX >= 0 && MousePosY >= 0 && MousePosX < Columns && MousePosY < Rows;  
        }

		private void SwitchEnableButtons(bool caseButton) //Отключение кнопки паузы или старта
        {
            PauseButton.Enabled = caseButton;
            StartButton.Enabled = !caseButton;
        }

        private void Start(object sender, EventArgs e) //Запустить игру при нажатии кнопки
        {
            StartGame();
			SwitchEnableButtons(true);

		}

        private void Exit(object sender, EventArgs e) //Закрыть приложение
        {
            Application.Exit(); 
        }

        private void StartCalcVariable(object sender, EventArgs e)
        {
			getCellSize();
			Rows = GamePlace.Height / CellSize; 
            Columns = GamePlace.Width / CellSize; 
            RedCells = new bool[Columns, Rows];  //Инициализируем новый размер массивов для 2-х цветов
            BlueCells = new bool[Columns, Rows];
            Bitmap bitmap = new Bitmap(GamePlace.Width, GamePlace.Height);
            GamePlace.Image = bitmap;  //Создаём сетку игры 
            Grafica = Graphics.FromImage(GamePlace.Image);  //Переносим сетку в изображение
            Grafica.Clear(Color.White);  //Заполняем графику белым цветом
            for (int i = CellSize - 1; i < bitmap.Width; i += CellSize)
            {
                Grafica.DrawLine(Pens.Black, i, 0, i, bitmap.Height);
            }
            for (int i = CellSize - 1; i < bitmap.Height; i += CellSize)
            {
                Grafica.DrawLine(Pens.Black, 0, i, bitmap.Width, i);
            }
        }

        private void ClearColors(object sender, EventArgs e) //Очистка игрового поля
        {
            Timer.Enabled = false;
			SwitchEnableButtons(false);
			StartCalcVariable(new object(), new EventArgs());

		}

        private void getCellSize() //Изменение размера размера одной клетки
        {
            switch (sizeBox.SelectedIndex)
            {
                case 2:
                    {
                        CellSize = 60;
						break;
                    }
				case 1:
					{
						CellSize = 40;
						break;
					}
				case 0:
					{
						CellSize = 15;
						break;
					}
			}

		}

		private void updateBitmap(object sender, EventArgs e)
		{
			StartCalcVariable(new object(), new EventArgs());
		}

        //События при нажатии подсказки
		private void HelpStart(object sender, HelpEventArgs hlpevent)
		{
            MessageBox.Show("Это кнопка начинает игру", "Подсазка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void HelpStop(object sender, HelpEventArgs hlpevent)
		{
			MessageBox.Show("Это кнопка заканчивает игру", "Подсазка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void HelpClean(object sender, HelpEventArgs hlpevent)
		{
			MessageBox.Show("Это кнопка очищает поле", "Подсазка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void HelpExit(object sender, HelpEventArgs hlpevent)
		{
			MessageBox.Show("Это кнопка выхода из игры", "Подсазка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void HelpSize(object sender, HelpEventArgs hlpevent)
		{
			MessageBox.Show("Это список, с помощью которого можно выбрать размер поля", "Подсазка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void HelpGamePlace(object sender, HelpEventArgs hlpevent)
		{
			MessageBox.Show("Это поле: клик левой мышью - красная клетка, правой - синяя, повтор клика - убить клетку", "Подсазка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
