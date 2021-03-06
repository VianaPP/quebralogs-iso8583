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

                        txtResult.Text += "Bit 2: " + "\r\n" + "Número do cartão: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "3")
                    {
                        string Campo = resto_log.Substring(0, 6);

                        txtResult.Text += "Bit 3: " + "\r\n" + "Código Processamento: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 6);

                    }
                    else if (bitsAtivos[i].ToString() == "4")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 4: " + "\r\n" + "Valor total da transação: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 12);

                    }
                    else if (bitsAtivos[i].ToString() == "11")
                    {
                        string Campo = resto_log.Substring(0, 6);

                        txtResult.Text += "Bit 11: " + "\r\n" + "Número do documento: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 6);

                    }
                    else if (bitsAtivos[i].ToString() == "12")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 12: " + "\r\n" + "Data e hora local: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 12);

                    }
                    else if (bitsAtivos[i].ToString() == "14")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 14: " + "\r\n" + "Data de validade do cartão: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 4);

                    }
                    else if (bitsAtivos[i].ToString() == "18")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 18: " + "\r\n" + "Código MCC: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 4);

                    }
                    else if (bitsAtivos[i].ToString() == "22")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 22: " + "\r\n" + "Modo de entrada: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 12);

                    }
                    else if (bitsAtivos[i].ToString() == "23")
                    {
                        string Campo = resto_log.Substring(0, 2);

                        txtResult.Text += "Bit 23: " + "\r\n" + "Número sequencial do cartão: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 2);

                    }
                    else if (bitsAtivos[i].ToString() == "24")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 24: " + "\r\n" + "Solução de autorização: " + Campo + "\r\n\r\n";

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


                        txtResult.Text += "Bit 31: " + "\r\n" + "Identificação do cartão: " + Campo + "\r\n\r\n";

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


                        txtResult.Text += "Bit 34: " + "\r\n" + "Código de Segurança: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "35")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 35: " + "\r\n" + "Trilha 2: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "38")
                    {
                        string Campo = resto_log.Substring(0, 12);

                        txtResult.Text += "Bit 38: " + "\r\n" + "Código de autorização: " + Campo + "\r\n\r\n";
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


                        txtResult.Text += "Bit 39: " + "\r\n" + "Código de resposta: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 6);

                    }
                    else if (bitsAtivos[i].ToString() == "41")
                    {
                        string Campo = resto_log.Substring(0, 16);

                        for (int contador = 0; contador < Campo.Length; contador++)
                        {
                            Campo = Campo.Remove(contador, 1);
                        }

                        txtResult.Text += "Bit 41: " + "\r\n" + "Número Lógico do Terminal: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 16);

                    }
                    else if (bitsAtivos[i].ToString() == "42")
                    {
                        string Campo = resto_log.Substring(0, 16);

                        txtResult.Text += "Bit 42: " + "\r\n" + "Código do estabelecimento para Venda: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 16);

                    }
                    else if (bitsAtivos[i].ToString() == "43")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 43: " + "\r\n" + "Código do estabbelecimento Físico: " + Campo + "\r\n\r\n";

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


                        txtResult.Text += "Bit 45: " + "\r\n" + "Trilha 1: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "47")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 47: \r\n";
                        string logSubs = Campo;

                        for (int c = 0; c < logSubs.Length; c++ )
                        {

                            string subCampo = logSubs.Substring(0, 4);
                            int subInt = Int32.Parse(subCampo);
                            int tamanhoSub = subInt * 2;
                            txtResult.Text += "SubCampo: " + subCampo;
                            logSubs = logSubs.Remove(0, 4);
                            
                            string idSub = logSubs.Substring(0, 2);
                            txtResult.Text += "\r\n ID: " + idSub;

                            string restoSub = logSubs.Substring(0, tamanhoSub);
                            txtResult.Text += "\r\n" + restoSub + "\r\n\r\n";
                            logSubs = logSubs.Remove(0, tamanhoSub);
                        }
                    
                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "49")
                    {
                        string Campo = resto_log.Substring(0, 4);

                        txtResult.Text += "Bit 49: " + "\r\n" + "Código da Moeda: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 4);

                    }
                    else if (bitsAtivos[i].ToString() == "52")
                    {
                        string Campo = resto_log.Substring(0, 16);

                        txtResult.Text += "Bit 52: " + "\r\n" + "PIN BLOCK: " + Campo + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, 16);

                    }
                    else if (bitsAtivos[i].ToString() == "53")
                    {
                        string Campo = resto_log.Substring(0, 2);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 2);
                        Campo = resto_log.Substring(0, restoCampo);
                        string TDC = Campo.Substring(0, 2);
                        string KNS = Campo.Substring(2);

                        txtResult.Text += "Bit 53: " + "\r\n";
                        txtResult.Text += "Tipo de Criptografia: " + TDC + "\r\n";
                        txtResult.Text += "KNS: " + KNS + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "54")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);
                        string CDV = Campo.Substring(0, 2);
                        string VRC = Campo.Substring(2);

                        txtResult.Text += "Bit 54: " + "\r\n";
                        txtResult.Text += "Código do Valor: " + CDV + "\r\n";
                        txtResult.Text += "Valor referente ao código: " + VRC + "\r\n\r\n";

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "55")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 55: \r\n";
                        string logSubs = Campo;

                        for (int c = 0; c < logSubs.Length; c++)
                        {

                            string subCampo = logSubs.Substring(0, 4);
                            int subInt = Int32.Parse(subCampo);
                            int tamanhoSub = subInt * 2;
                            txtResult.Text += "SubCampo: " + subCampo;
                            logSubs = logSubs.Remove(0, 4);

                            string idSub = logSubs.Substring(0, 2);
                            txtResult.Text += "\r\n ID: " + idSub;

                            string restoSub = logSubs.Substring(0, tamanhoSub);
                            txtResult.Text += "\r\n" + restoSub + "\r\n\r\n";
                            logSubs = logSubs.Remove(0, tamanhoSub);
                        }


                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "57")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 57: \r\n";
                        string logSubs = Campo;

                        for (int c = 0; c < logSubs.Length; c++)
                        {

                            string subCampo = logSubs.Substring(0, 4);
                            int subInt = Int32.Parse(subCampo);
                            int tamanhoSub = subInt * 2;
                            txtResult.Text += "SubCampo: " + subCampo;
                            logSubs = logSubs.Remove(0, 4);

                            string idSub = logSubs.Substring(0, 2);
                            txtResult.Text += "\r\n ID: " + idSub;

                            string restoSub = logSubs.Substring(0, tamanhoSub);
                            txtResult.Text += "\r\n" + restoSub + "\r\n\r\n";
                            logSubs = logSubs.Remove(0, tamanhoSub);
                        }

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "60")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 60: \r\n";
                        string logSubs = Campo;

                        for (int c = 0; c < logSubs.Length; c++)
                        {

                            string subCampo = logSubs.Substring(0, 4);
                            int subInt = Int32.Parse(subCampo);
                            int tamanhoSub = subInt * 2;
                            txtResult.Text += "SubCampo: " + subCampo;
                            logSubs = logSubs.Remove(0, 4);

                            string idSub = logSubs.Substring(0, 2);
                            txtResult.Text += "\r\n ID: " + idSub;

                            string restoSub = logSubs.Substring(0, tamanhoSub);
                            txtResult.Text += "\r\n" + restoSub + "\r\n\r\n";
                            logSubs = logSubs.Remove(0, tamanhoSub);
                        }

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "61")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 61: \r\n";
                        string logSubs = Campo;

                        for (int c = 0; c < logSubs.Length; c++)
                        {

                            string subCampo = logSubs.Substring(0, 4);
                            int subInt = Int32.Parse(subCampo);
                            int tamanhoSub = subInt * 2;
                            txtResult.Text += "SubCampo: " + subCampo;
                            logSubs = logSubs.Remove(0, 4);

                            string idSub = logSubs.Substring(0, 2);
                            txtResult.Text += "\r\n ID: " + idSub;

                            string restoSub = logSubs.Substring(0, tamanhoSub);
                            txtResult.Text += "\r\n" + restoSub + "\r\n\r\n";
                            logSubs = logSubs.Remove(0, tamanhoSub);
                        }

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "62")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 62: \r\n";
                        string logSubs = Campo;

                        for (int c = 0; c < logSubs.Length; c++)
                        {

                            string subCampo = logSubs.Substring(0, 4);
                            int subInt = Int32.Parse(subCampo);
                            int tamanhoSub = subInt * 2;
                            txtResult.Text += "SubCampo: " + subCampo;
                            logSubs = logSubs.Remove(0, 4);

                            string idSub = logSubs.Substring(0, 2);
                            txtResult.Text += "\r\n ID: " + idSub;

                            string restoSub = logSubs.Substring(0, tamanhoSub);
                            txtResult.Text += "\r\n" + restoSub + "\r\n\r\n";
                            logSubs = logSubs.Remove(0, tamanhoSub);
                        }

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else if (bitsAtivos[i].ToString() == "63")
                    {
                        string Campo = resto_log.Substring(0, 4);
                        int campoInt = Int32.Parse(Campo);
                        int restoCampo = campoInt * 2;

                        resto_log = resto_log.Remove(0, 4);
                        Campo = resto_log.Substring(0, restoCampo);

                        txtResult.Text += "Bit 63: \r\n";
                        string logSubs = Campo;

                        for (int c = 0; c < logSubs.Length; c++)
                        {

                            string subCampo = logSubs.Substring(0, 4);
                            int subInt = Int32.Parse(subCampo);
                            int tamanhoSub = subInt * 2;
                            txtResult.Text += "SubCampo: " + subCampo;
                            logSubs = logSubs.Remove(0, 4);

                            string idSub = logSubs.Substring(0, 2);
                            txtResult.Text += "\r\n ID: " + idSub;

                            string restoSub = logSubs.Substring(0, tamanhoSub);
                            txtResult.Text += "\r\n" + restoSub + "\r\n\r\n";
                            logSubs = logSubs.Remove(0, tamanhoSub);
                        }

                        resto_log = resto_log.Remove(0, restoCampo);

                    }
                    else
                    {
                        string Campo = resto_log.Substring(0, 16);

                        txtResult.Text += "Bit 64: " + "\r\n" + "MAC: " + Campo + "\r\n\r\n";

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
