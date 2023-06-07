namespace _20230530_HesapMakinesi
{
	public partial class Form1 : Form
	{
		double sayi1 = 0, sayi2 = 0, sonuc = 0;
		string islemTuru = string.Empty;
		bool commandExecuted = false;
		bool belirliIslemTuru = false;
		bool belirliSonuc = false;
		bool belirliSayi2 = false;
		public Form1()
		{
			InitializeComponent();
		}
		#region Events

		bool isDragging = false;
		Point lastLocation;
		private void btnClosed_MouseHover(object sender, EventArgs e)
		{
			btnClosed.BackColor = Color.Red;
			btnClosed.ForeColor = Color.White;
		}

		private void btnClosed_MouseLeave(object sender, EventArgs e)
		{
			btnClosed.ForeColor = Color.Black;
			btnClosed.BackColor = Color.FromArgb(224, 224, 224);
		}

		private void btnClosed_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void label2_MouseDown(object sender, MouseEventArgs e)
		{
			isDragging = true;
			lastLocation = e.Location;
		}

		private void label2_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragging)
			{
				this.Location = new Point(
						this.Location.X + (e.X - lastLocation.X),
						this.Location.Y + (e.Y - lastLocation.Y));
			}
		}
		private void label2_MouseUp(object sender, MouseEventArgs e)
		{
			isDragging = false;
		}





		#endregion

		

		private void SayilarveVirgulButonu(object sender)
		{
			Button btn = (Button)sender;
			string number = btn.Text;
			if (btn.Text == ",")
			{
				if (!lblPanel.Text.Contains(","))
				{
					lblPanel.Text += btn.Text;
				}
			}
			else if (btn.Text == "0")
			{
				if (!(lblPanel.Text == "0"))
				{
					lblPanel.Text += btn.Text;
				}
			}
			else
			{
				if (lblPanel.Text == "0")
				{
					lblPanel.Text = string.Empty;
				}
				lblPanel.Text += btn.Text;
			}
		}
		private void SayiveVirgul(object sender, EventArgs e)
		{
			if (sonuc == 0)
			{
				if (string.IsNullOrEmpty(islemTuru))
				{
					SayilarveVirgulButonu(sender);
				}
				else
				{
					if (!commandExecuted)
					{
						lblPanel.Text = "0";

						commandExecuted = true;
					}
					SayilarveVirgulButonu(sender);
				}
			}
			else
			{
				if (!belirliSonuc)
				{
					lblPanel.Text = "0";

					belirliSonuc = true;
				}
				SayilarveVirgulButonu(sender);
			}

		}



		private void btnBackSpace_Click(object sender, EventArgs e)
		{
			if (lblPanel.Text.Length > 1)
			{
				lblPanel.Text = lblPanel.Text.Substring(0, lblPanel.Text.Length - 1);
			}
			else if (lblPanel.Text.Length == 1)
			{
				lblPanel.Text = string.Empty;
				lblPanel.Text = "0";
			}
		}

		private void btnNegative_Click(object sender, EventArgs e)
		{
			if (!(lblPanel.Text == "0"))
			{
				if (lblPanel.Text.StartsWith("-"))
				{
					lblPanel.Text = lblPanel.Text.Substring(1);
				}
				else
				{
					lblPanel.Text = "-" + lblPanel.Text;
				}
			}
		}

		private void ClearEntry_Click(object sender, EventArgs e)
		{
			lblPanel.Text = "0";
		}

		private void btnEqual_Click(object sender, EventArgs e)
		{
			if (!belirliSayi2)
			{
				sayi2 = Convert.ToDouble(lblPanel.Text);
				switch (islemTuru)
				{
					case "+":
						sonuc = sayi1 + sayi2;
						break;
					case "-":
						sonuc = sayi1 - sayi2;
						break;
					case "x":
						sonuc = sayi1 * sayi2;
						break;
					case "÷":
						sonuc = sayi1 / sayi2;
						break;
				}
				if (sonuc % 1 == 0)
				{
					lblPanel.Text = sonuc.ToString("N0");
				}
				else
				{
					lblPanel.Text = sonuc.ToString("N");
				}
				belirliSayi2 = true;
			}
			else
			{
				double entrySayi = Convert.ToDouble(lblPanel.Text);
				switch (islemTuru)
				{
					case "+":
						sonuc = entrySayi + sayi2;
						break;
					case "-":
						sonuc = entrySayi - sayi2;
						break;
					case "x":
						sonuc = entrySayi * sayi2;
						break;
					case "÷":
						sonuc = entrySayi / sayi2;
						break;
				}
				if (sonuc % 1 == 0)
				{
					lblPanel.Text = sonuc.ToString("N0");
				}
				else
				{
					lblPanel.Text = sonuc.ToString("N");
				}
			}

		}

		private void Clear_Click(object sender, EventArgs e)
		{
			sayi1 = 0;
			sayi2 = 0;
			sonuc = 0;
			islemTuru = string.Empty;
			commandExecuted = false;
			belirliIslemTuru = false;
			belirliSonuc = false;
			belirliSayi2 = false;
			lblPanel.Text = "0";
		}

		private void Islemler(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if (string.IsNullOrEmpty(islemTuru))
			{
				islemTuru = btn.Text;
				sayi1 = Convert.ToDouble(lblPanel.Text);
			}
			else
			{
				if (!belirliIslemTuru)
				{
					sayi2 = Convert.ToDouble(lblPanel.Text);
					switch (islemTuru)
					{
						case "+":
							sonuc = sayi1 + sayi2;
							break;
						case "-":
							sonuc = sayi1 - sayi2;
							break;
						case "x":
							sonuc = sayi1 * sayi2;
							break;
						case "÷":
							sonuc = sayi1 / sayi2;
							break;
					}
					if (sonuc % 1 == 0)
					{
						lblPanel.Text = sonuc.ToString("N0");
					}
					else
					{
						lblPanel.Text = sonuc.ToString("N");
					}
					belirliIslemTuru = true;
				}

			}

		}
	}
}