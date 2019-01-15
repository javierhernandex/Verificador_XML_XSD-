using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace verificacion_xml
{
    public partial class Form1 : Form
    {
        String nn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     

       

        private void label1_Click(object sender, EventArgs e)
        {




        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "txt files(*.xml*)|*.xml*";
            dia.FilterIndex = 1;
            dia.Multiselect = false;

            if (dia.ShowDialog() == DialogResult.OK) {


                textBox1.Text = dia.SafeFileName;
                nn = dia.FileName;
                
            }

            
        }
        private void button1_Click(object sender, EventArgs e)
        {


            textBox2.Text = "Datos Correctos!";


            XmlReaderSettings booksSettings = new XmlReaderSettings();
            booksSettings.Schemas.Add("http://www.sat.gob.mx/esquemas/controlesvolumetricos", "ControlesVolumetricos_v1.2.xsd");
            booksSettings.ValidationType = ValidationType.Schema;
            booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

            XmlReader books = XmlReader.Create(nn, booksSettings);

            while (books.Read()) { }

          

            // Console.ReadKey();



        }
        
        private void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
      
                if (e.Severity == XmlSeverityType.Error)
                {
                    textBox2.Text = "ERROR: " + e.Message;

           
            }

            














        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
