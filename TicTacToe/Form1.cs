namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //oyun alaný tanýmlanýyor 3*3 matris þeklinde
        Button[,] oyunAlani = new Button[3, 3];

        //groupbox içine alalým
        GroupBox oyunbx=new GroupBox() { Size= new Size(340,340)};
        private void Form1_Load(object sender, EventArgs e)
        {
       

        //oyun butonlarý yerleþtiriliyor.

            for(int i=0; i<oyunAlani.GetLength(0); i++)
            {
                for(int j=0; j<oyunAlani.GetLength(1);j++)
                {

                    oyunAlani[i, j] = new Button() { Name = $"{i}-{j}", Location = new Point(j * 100 + 20, i * 100 + 20), Size = new Size(100, 100), TabStop = false };
                   //her tuþa ayný click event eklendi
                    (oyunAlani[i,j]).Click += new EventHandler(button1_Click);

                    this.oyunbx.Controls.Add(oyunAlani[i,j]);
                    this.Controls.Add(oyunbx);
                }
            }
        
        }


        int hamle=0;
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn= (Button)sender;
     // hamle üste tanýmlanýyor ve 0 atanýyor.
            btn.Text = oyuncu(hamle);
        //bir daha deðiþmemesi için enable false olmalý aksi halde üzerine basýldýðýnda tekrar deðiþicektir.
            btn.Enabled = false;
            
    //oyuncu deðiþimi burada yapýlýyor bir sonraki oyuncuyu seçiyoruz.
             hamle++;
            label2.Text = oyuncu(hamle);
//4 hamlede sonra kontrol ediyoruz. once kazanma þansý olmadýðýndan dolayý
            //if (hamle > 4)
            //{
                GameControl(oyunAlani);
            //}
        }


        private string oyuncu(int a)
        {
            if (a % 2 == 0)
                return "X";
            else
                return "O";
        }

        private void GameControl(Button [,] a)
        {

            if ( a[1,1].Text!="" )
            {
                if ((a[0, 0].Text == a[1, 1].Text && a[1, 1].Text == a[2, 2].Text)) {
                    MessageBox.Show($"Çapraz kazanan: {a[1,1].Text}");
                    //formu enabled false yapýyoruz oyuna devam ettirmiyoruz.
                    oyunbx.Enabled = false;
                }else if((a[0, 2].Text == a[1, 1].Text && a[1, 1].Text == a[2, 0].Text))
                {
                    MessageBox.Show($"Çapraz kazanan: {a[1, 1].Text}");
                    //formu enabled false yapýyoruz oyuna devam ettirmiyoruz.
                    oyunbx.Enabled = false;
                }
            }

            for (int i=0; i<3; i++)
            {
                if(a[0, i].Text !="" && a[1, i].Text !="" &&a[2, i].Text != "")
                    {
                    if (a[0, i].Text == a[1, i].Text && a[1, i].Text == a[2, i].Text)
                    {
                        //vertical-dikey kazanan burada belirlenecek...
                        MessageBox.Show($"Dikey kazanan {a[0, i].Text}");
                        //formu enabled false yapýyoruz oyuna devam ettirmiyoruz.
                        oyunbx.Enabled = false;

                    }
                }
                if (a[i, 0].Text != "" && a[i, 1].Text != "" && a[i, 2].Text != "")
                {
                    if (a[i, 0].Text == a[i, 1].Text && a[i, 1].Text == a[i, 2].Text)
                    {
                        //Horizontal yatay kazanan burada belirlenecek...
                        MessageBox.Show($"Yatay kazanan {a[i, 0].Text}");
                        //formu enabled false yapýyoruz oyuna devam ettirmiyoruz.
                        oyunbx.Enabled = false;

                    }
                }
                

            }
        }
    }
}