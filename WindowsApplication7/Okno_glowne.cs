using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary_okno_logowania;
using System.Reflection;  // aby assembly byla widoczna 
using Oracle.DataAccess.Client; // dopolaczenia z baza oracle
using Oracle.DataAccess.Types; // do polaczenia z baza oracle 
using ClassLibrary3_polaczenie; // kalasa statyczna trzymajaca stringa 
using ClassLibrary3_formatki;// id formatki i id biblioteki  do otwaria przekazywane;
using System.Reflection; // reflekscja

namespace WindowsApplication7
{
    public partial class Okno_glowne : Form
    {

        bool polaczeni_z_baza = false; //na starcei ustawiona jako false
        klasa_okno_logowania okno; // okno logowania
        OracleConnection con;    //polacznie z baza
        string password = "", user = "", baza = "";

        //string biblioteka = "";
        //string formatka = "";
        int numer_biblioteki = 1;
        int numer_foramtki = 1;

        TreeNode biblioteka = null, formatka = null;

        
        

        public Okno_glowne()
        {
            InitializeComponent();
            inicjalizacja();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           

        }



        private void inicjalizacja()
        {
            cbCzujniki.Checked = false; // wartosc podczas inicjalizacji
            odsiez_panel();
            odswiez_status_polaczenia();
            cbCzujniki.Enabled = false; // wylaczenie przycisku

                 

        }

        private void cbCzujniki_CheckedChanged(object sender, EventArgs e)
        {
            odsiez_panel();
        }

        private void odsiez_panel()
        {
            pnlCzujniki.Visible = cbCzujniki.Checked; // gdy baton wciœniety wlasciwosc vivible jest taka sama jak buttona 
        }

        private void pobierz_czujniki()
        {

        }

        private void odswiez_status_polaczenia()
        {
            if (polaczeni_z_baza == true)  // flaga 
                status_polaczenia.Text = "Aktywne po³¹czenie";
            else
                status_polaczenia.Text = "Nieaktywne po³¹czenie";

        }

        //logowanie do  bazy 
        private void button1_Click_1(object sender, EventArgs e)
        { 
            /*okno logowania jest pobierane z dll  Okno_lologowania
             * */
            if (polaczeni_z_baza == false) // gdy nie mam polaczenia otwieram okno do polaczenia
            {
                //*1 metoda
                if (okno == null)
                {

                    okno = new klasa_okno_logowania(ref user, ref password, ref baza); // okno logowania 

                    okno.StartPosition = this.StartPosition; // okno logowania na sordku ekrany jak okno glowne aplikacji 

                    DialogResult result = okno.ShowDialog(); // co zostalo wcisniete 


                    if (result == DialogResult.OK) //przycisniecie loguj w oknie logowania 
                    {



                        try
                        {
                            con = new OracleConnection();
                            con.ConnectionString = "User ID =" + okno.txtBxUser.Text.ToUpper() + "; Password =" + okno.txtBxPassword.Text.ToUpper() + "; Data Source =" + okno.txtBxBaza.Text.ToUpper();
                            con.Open();
                            polaczeni_z_baza = true; // ustawiam flage polaczneia z baza 
                            odswiez_status_polaczenia();
                            Baza.Text = okno.txtBxBaza.Text.ToUpper();
                            uzytkownik.Text = okno.txtBxUser.Text.ToUpper();
                            cbCzujniki.Enabled = true;
                            bttnLogowanie.Text = "Wyloguj";
                            //ustawianie zmiennych logowania w this
                            this.user = okno.txtBxUser.Text.ToUpper();
                            this.password = okno.txtBxPassword.Text.ToUpper();
                            this.baza = okno.txtBxBaza.Text.ToUpper();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("B³¹d po³¹czenia \n" + ex);
                            okno = null;
                        }

                    }
                    if (result == DialogResult.Cancel) // gdy wcisnieto kancel  ustawiam referencje na null ; 
                    {
                        okno = null;

                    }
                }
            }
            else if  (polaczeni_z_baza == true)
            {

                con.Close(); // zamkniecie  po³¹czenia z baza
                inicjalizacja();
                polaczeni_z_baza = false;
                status_polaczenia.Text = "Nieaktywne po³¹czenie";
                Baza.Text = "";
                uzytkownik.Text = "";
                okno = null;
                bttnLogowanie.Text = "Loguj";


            }

            
            
            
            

            //* meodata
            /*
            Assembly myLib = Assembly.LoadFile(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Okno_logowania.dll");
            if (myLib != null)
            {
                Form frm = (Form)myLib.CreateInstance("ClassLibrary_okno_logowania.klasa_okno_logowania");   //podaæ pe³ne: namespace.klasa (MyLib.Form1)
                if (frm != null)
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                    MessageBox.Show("Nie mo¿na utworzyæ instancji formy");
            }
            else
            {
                MessageBox.Show("Nie uda³o siê za³adowaæ biblioteki");
            }

            */
        }

        // pobranie czujników i zaladowani drzewka 
        private void button1_Click_2(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear(); // czysci liczbe wezlow
            //Pobierz_czujniki_i_formatki();  // metoda 1
            Pobierz_liste_czujnikow(); // metoda 2 znacznie lepsza  pobiera biblioteki i formatki do bibliotek w we wlasnosci tag jest id formatki lub biblioteki 

        }

        private void Pobierz_czujniki_i_formatki()
        {
            String cmdQuery = "select bf.id,BF.NAZWA_BIBLIOTEKI,BF.OPIS_BIBLIOTEKI,BF.ID_czujnika from BIBLIOTEKI_FORMATEK bf order by bf.id";
            OracleDataAdapter ODA = new OracleDataAdapter(cmdQuery, con);
            DataSet DS = new DataSet(); // tworze ds
            ODA.Fill(DS);  // wypelniam dataseta
            DataRow DR; // wiersz danych 

            treeView1.Nodes.Clear(); // uzuwanie wszytskich wezlow z drzewa 

            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                DR = DS.Tables[0].Rows[i];
                //MessageBox.Show("id=" + DR[0].ToString());
                TreeNode tNode; // aktualny wezlem
                tNode = treeView1.Nodes.Add(DR[2].ToString()); // numer id plus nazwa skrocona  tworzy weza i wstawia go 
                #region formatki

                String cmdQuery1 = "select FC.ID,FC.ID_BIBLIOTEKI,FC.ID_CZUJNIKA,FC.OPIS_WYSWIETLANY from  FORMATKI_CZUJNIK fc where FC.ID_CZUJNIKA=" + DR[3].ToString();
                OracleDataAdapter ODA1 = new OracleDataAdapter(cmdQuery1, con);
                DataSet DS1 = new DataSet(); // tworze ds
                ODA1.Fill(DS1);  // wypelniam dataseta
                DataRow DR1; // wiersz danych 


                for (int j = 0; j < DS1.Tables[0].Rows.Count; j++)
                {
                    DR1 = DS1.Tables[0].Rows[j];
                    //MessageBox.Show("id=" + DR[0].ToString());
                    // aktualny wezlem z biblioteki 
                    tNode.Nodes.Add(DR1[3].ToString());
                }

                #endregion
            }
        }

        //ustawiam parametry zaznaczonego wezla 
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            biblioteka = null;
            formatka = null;

            TreeNode wezel = null;

            wezel = treeView1.SelectedNode;

            if (wezel.Parent != null) // ma rodzica to zaqznaczony elemenent to formatka (podwezel)
            {
                formatka = wezel;
                biblioteka = wezel.Parent;
            }
            else // to biblioteka nie jest null tzn jest biblioteka
            {
                
                biblioteka = wezel;
            }                
        }

  


        

        //pobiera liste bibliotek i powiazanych znia formatakmi
        private void Pobierz_liste_czujnikow()
        {
            //zerowanie numeru biblioteki 
            numer_biblioteki = 1;
            //The SQL UNION operator is used to combine the result sets of 2 or more SELECT statements. It removes duplicate rows between the various SELECT statements.
            String cmdQuery = "SELECT        ID, NAZWA_BIBLIOTEKI, ID_CZUJNIKA, OPIS_BIBLIOTEKI, CZY_BIBLIOTEKA " +
                              "FROM " +
                              "(SELECT        ID, NAZWA_BIBLIOTEKI, ID_CZUJNIKA, OPIS_BIBLIOTEKI, CZY_BIBLIOTEKA " +
                              "FROM            BIBLIOTEKI_FORMATEK " +
                              " UNION " +
                              " SELECT        ID_BIBLIOTEKI, NAZWA_FORMATKI, ID, OPIS_WYSWIETLANY, CZY_BIBLIOTEKA " +
                              "FROM            FORMATKI_CZUJNIK) TABELKA1 " +
                              "ORDER BY CZY_BIBLIOTEKA ";

            OracleDataAdapter ODA = new OracleDataAdapter(cmdQuery, con);
            DataSet DS = new DataSet(); // tworze ds
            ODA.Fill(DS);  // wypelniam dataseta

            TreeNode wezel, wezle1;
            DataRow DR;
            DataTable DT;
            DT = DS.Tables[0];

            //dodanie bibliotek 
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                DR = DT.Rows[i];


                if (DR.ItemArray[4].ToString() == "B") // dodaje wsyztskei biblioteki 
                {
                    wezel = treeView1.Nodes.Add(numer_biblioteki+"."+DR[3].ToString());
                    wezel.Tag = DR[0].ToString(); // USTAWIAM KLUCZ id biblioteki
                    wezel.Name = DR[1].ToString();   // "BIBLIOTEKI_FORMATEK";               // nazwa tabeli gdzie mam szukac     
                    numer_biblioteki++;

                }

            }


            // zew petla skacze po bibliotekach 
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {

                wezle1 = treeView1.Nodes[i]; // pobranie pierwszego wezla 
                //dodanie formatek
                for (int j = 0; j < DS.Tables[0].Rows.Count; j++)
                {

                    DR = DT.Rows[j]; // wyciagam jeden rekord z tabeli danych 
                    if ((wezle1.Tag.ToString() == DR.ItemArray[0].ToString()) && (DR.ItemArray[4].ToString() == "F")) // gdy id biblioteki pasuje i id formatki z biblioteki pasuje dodaje i jest dformatka 
                    {
                        wezel = wezle1.Nodes.Add(numer_foramtki+"."+DR.ItemArray[3].ToString());

                        //wezel = treeView1.Nodes[j]; 
                        wezel.Tag = DR[2].ToString(); // ustawienie id formatki 
                        wezel.Name = DR[1].ToString();  // nazwa klasy // "FORMATKI_CZUJNIK";  //nazwa tabeli z bazy gdzie mam szukac foramtki id jest w tag'u wezla
                        numer_foramtki++;
                    }
                }
                numer_foramtki = 1;
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
            //przekazanie do klasystatycznej
            Class1.Uzytkownik = this.user;
            Class1.Haslo = this.password;
            Class1.Baza = this.baza;
            
            string l_biblioteka = "", l_formatka = "", l_name_space = "";
            //MessageBox.Show("Biblioteka:" + biblioteka + "\n" + "Formatka:" + formatka);

            // gdy biblioteka i formatka sa zaznaczone moge otworzyc formê
            if ((biblioteka != null) && (formatka != null))
            {
                //ustawienie id_formatki i id biblioteki 
                Formatki.Id_biblioteki = this.biblioteka.Tag.ToString();
                Formatki.Id_formatki = this.formatka.Tag.ToString();
                
                // id czujnika ponizej ustawiam
                

                /*Pobranie nazwy  
                 * nazwa.dll
                 * name_space
                 * klasy formatki
                 * */
                #region formatka_czujnik  
                {
                    try
                    {
                        String cmdQuery = "select  BF.NAZWA_BIBLIOTEKI, FC.NAZWA_FORMATKI,FC.PRZESTRZEN_NAZW,FC.ID_CZUJNIKA " +
                            " from BIBLIOTEKI_FORMATEK BF,FORMATKI_CZUJNIK FC " +
                            "where BF.ID=FC.ID_biblioteki and BF.ID=" + biblioteka.Tag.ToString() + " and  FC.ID=" + formatka.Tag.ToString();

                        OracleDataAdapter ODA = new OracleDataAdapter(cmdQuery, con);
                        DataSet DS = new DataSet(); // tworze ds
                        ODA.Fill(DS);  // wypelniam dataseta

                        
                        DataRow DR;
                        DataTable DT;
                        DT = DS.Tables[0]; // tablica 0
                        DR = DT.Rows[0]; // pierwszy rekord
                        l_biblioteka = DR[0].ToString(); //nazwa biblioteki
                        l_formatka = DR[1].ToString(); //nazwa formatki 
                        l_name_space = DR[2].ToString(); // nazwa przestrzani nazw
                        Formatki.Id_czujnika = DR[3].ToString(); // ustawiam id czujnika :) 
                    }
                    catch
                    {
                        MessageBox.Show("B³ad region formatka_czujnik");
                    }

                }
                #endregion


                //* meodata

                
                //zaladowanie biblioteki biblioteki wg id 
                try
                {
                    Assembly myLib = Assembly.LoadFile(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\\" + l_biblioteka);

                    if (myLib != null)
                    {



                        //utworznie instancji formy  
                        //Form frm = (Form)myLib.CreateInstance(l_name_space+"."+l_formatka);   //podaæ pe³ne: namespace.klasa (MyLib.Form1)
                        //if (frm != null)
                        {


                            //frm.MdiParent = this;

                            Type[] tablica = myLib.GetTypes(); //tablica przechowujaca przetrzenienazw.klasa wyciaga wszystkie przestrzenie z dll w raz z klasami 

                            try
                            {
                                //wyszukanie odpowiedniej przestrzeni naz i wklasy 
                                foreach (Type t in tablica)
                                {

                                    if (t.FullName == l_name_space + "." + l_formatka) // w fullName jest przestrzen_nazw.klasa
                                    {
                                        MethodInfo M1 = t.GetMethod("Instance"); //wywo³anie metody  metoda statyczna implementujaca wzorzec singletona tylko jedna formatke mo¿emy odœwietliæ
                                        Form f1 = (Form)M1.Invoke(null, null); //wywolanie konstruktora lub metody danej klasy i rzutowanie go na odpowieni typ
                                        f1.MdiParent = this; // ustawienie rodzica bo aplikacja mdi
                                        f1.Show(); //pokazanie formy 
                                        
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Nie uda³o sie wywo³aæ formatki:" + ex.ToString());

                            }


                            //foreach (Type t in tablica)
                            //{
                            //MessageBox.Show( t+"   "+t.MemberType.ToString());

                            //MemberInfo[] info = t.GetMembers(); // pobiera metody 

                            // foreach (MemberInfo m in info)
                            // {
                            //     MessageBox.Show(String.Format( "{0} in {1} ",m, m.MemberType));
                            // }

                            //wlolanei wlasnosci 

                            //frm.Show();


                        }
                        //else
                        //    MessageBox.Show("Nie mo¿na utworzyæ instancji formy");
                    }
                    else
                    {
                        MessageBox.Show("Nie uda³o siê za³adowaæ biblioteki");
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show("Nie uda³o siê za³adowaæ biblioteki"+E.ToString());
                }

                

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            string l_biblioteka = "";
            string l_formatka = "";
            if (biblioteka != null) 
                l_biblioteka = biblioteka.Name;
            if (formatka != null)
                l_formatka = formatka.Name;

            MessageBox.Show(l_biblioteka + "\n" + l_formatka);
        }

     

   

 




    }
}