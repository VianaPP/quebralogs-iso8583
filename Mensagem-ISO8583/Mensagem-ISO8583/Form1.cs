using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Mensagem_ISO8583
{
    public partial class FormISO : Form
    {

        

        public FormISO()
        {
            InitializeComponent();

        }


        private void btn_quebra_click(object sender, EventArgs e)
        {

            //vetor com bits ativos            
            ArrayList bitsAtivos = new ArrayList();

       
            txt_Log.Enabled = false;
            btn_quebra.Visible = false;
            btn_quebra.Enabled = false;
            btn_reinicia.Enabled = true;
            btn_reinicia.Visible = true;
            

            string Log = txt_Log.Text;
            string LogSemEspaço = Regex.Replace(Log, @"\s", "");

            if (txt_Log.Text.Length == 0)
            {
                txt_Log.Text = "Não pode Ser Vazio!";
            } else {

            string totalMsg = LogSemEspaço.Substring(0, 4);

            string tpdu = LogSemEspaço.Substring(4, 10);
            string tranparencia = LogSemEspaço.Substring(14, 2);
            string mti = LogSemEspaço.Substring(16, 4);
            string bitmap = LogSemEspaço.Substring(20, 16);


            txtResult.Text = "Tamanho Total Mensagem: " + totalMsg + "\r\n";
            txtResult.Text += "TPDU: " + tpdu + "\r\n";
            txtResult.Text += "Transparência: " + tranparencia + "\r\n";
            txtResult.Text += "MTI: " + mti + "\r\n";
            txtResult.Text += "Mapa de Bits: " + bitmap + "\r\n\r\n";

                
            int Verificacao = Convert.ToInt32(totalMsg, 16);
            Verificacao = Verificacao * 2;
            string ComprimetoLog = LogSemEspaço.Remove(0, 4);

            if (Verificacao != ComprimetoLog.Length)
            {
                txt_Log.Text = "Erro, A Log Não esta correta";
                btn_quebra.Enabled = false;
                btn_quebra.Visible = false;
                btn_reinicia.Enabled = true;
                btn_reinicia.Visible = true;
                txt_Log.Enabled = false;
            }
            else
            {

                bitmap = Convert.ToString(Convert.ToInt64(bitmap, 16), 2).PadLeft(64, '0');

                for (int i = 0; i < 64; i++)
                {
                    char a = bitmap[i];

                    if (a == '1')
                    {

                        bitsAtivos.Add(i + 1);

                    }

                }

                int tamanhoArray = bitsAtivos.Count;
                string resto_log = LogSemEspaço.Substring(36);

                for (int i = 0; i < tamanhoArray; i++)
                {
                    if (bitsAtivos[i].ToString() == "2")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 2: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "3")
                    {
                        string Campo = resto_log.Substring(0, 6);

                        txtResult.Text += "Bit 3: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 6);

                    }
                    else if (bitsAtivos[i].ToString() == "4")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 4: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 12);

                    }
                    else if (bitsAtivos[i].ToString() == "11")
                    {
                        string Campo = resto_log.Substring(0, 6);

                        txtResult.Text += "Bit 11: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 6);

                    }
                    else if (bitsAtivos[i].ToString() == "12")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 12: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 12);

                    }
                    else if (bitsAtivos[i].ToString() == "14")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 14: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 4);

                    }
                    else if (bitsAtivos[i].ToString() == "18")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 18: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 4);

                    }
                    else if (bitsAtivos[i].ToString() == "22")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 22: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 12);

                    }
                    else if (bitsAtivos[i].ToString() == "23")
                    {
                        string Campo = resto_log.Substring(0, 2);

                        txtResult.Text += "Bit 23: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 2);

                    }
                    else if (bitsAtivos[i].ToString() == "24")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 24: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 4);

                    }
                    else if (bitsAtivos[i].ToString() == "31")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);

                        for (int contador = 0; contador < Campo.Length; contador++)
                        {
                            Campo = Campo.Remove(contador, 1);
                        }


                        txtResult.Text += "Bit 31: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "34")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);
                        for (int contador = 0; contador < Campo.Length; contador++)
                        {
                            Campo = Campo.Remove(contador, 1);
                        }


                        txtResult.Text += "Bit 34: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "35")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 35: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "38")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 38: " + Campo + "\r\n\r\n";
                        for (int contador = 0; contador < Campo.Length; contador++)
                        {
                            Campo = Campo.Remove(contador, 1);
                        }


                        resto_log = resto_log.Remove(0, 12);

                    }
                    else if (bitsAtivos[i].ToString() == "39")
                    {
                        string Campo = resto_log.Substring(0, 6);
                        for (int contador = 0; contador < Campo.Length; contador++)
                        {
                            Campo = Campo.Remove(contador, 1);
                        }


                        txtResult.Text += "Bit 39: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 6);

                    }
                    else if (bitsAtivos[i].ToString() == "41")
                    {
                        string Campo = resto_log.Substring(0, 16);

                        for (int contador = 0; contador < Campo.Length; contador++)
                        {
                            Campo = Campo.Remove(contador, 1);
                        }

                        txtResult.Text += "Bit 41: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 16);

                    }
                    else if (bitsAtivos[i].ToString() == "42")
                    {
                        string Campo = resto_log.Substring(0, 16);

                        txtResult.Text += "Bit 42: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 16);

                    }
                    else if (bitsAtivos[i].ToString() == "43")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 43: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "45")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);
                        for (int contador = 0; contador < Campo.Length; contador++)
                        {
                            Campo = Campo.Remove(contador, 1);
                        }


                        txtResult.Text += "Bit 45: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "47")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

        

                        txtResult.Text += "Bit 47: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "49")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 49: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 4);

                    }
                    else if (bitsAtivos[i].ToString() == "52")
                    {
                        string Campo = resto_log.Substring(0, 16);

                        txtResult.Text += "Bit 52: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 16);

                    }
                    else if (bitsAtivos[i].ToString() == "53")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 53: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "54")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 54: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "55")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 55: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "57")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 57: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "60")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 60: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "61")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 61: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "62")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 62: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "63")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 63: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else
                    {
                        string Campo = resto_log.Substring(0, 16);

                        txtResult.Text += "Bit 64: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 16);

                    }

                }
            }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
       
        private void lbl_total_msg_Click(object sender, EventArgs e)
        {

        }

        private void FormISO_Load(object sender, EventArgs e)
        {

        }

        private void btn_reinicia_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Refresh();
            this.InitializeComponent();
        }


    }
}
