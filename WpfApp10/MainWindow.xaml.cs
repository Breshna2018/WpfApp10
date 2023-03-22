using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filepath;
        List<ArtPiece> artList = new List<ArtPiece>();
        FlowDocument fddisplay = new FlowDocument();

        public MainWindow()
        {
            //breshna naim finall one 03/21/23

            InitializeComponent();
            Paragraph pet = new Paragraph();

           // DateTime date = DateTime.Now;
            DateTime now = timepicker.DisplayDate;//show time i could not find how to show only year
        }




    

        private void pickimagebt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();//this for pick picture
            string filePath = "";
            if (image.ShowDialog() == true)
            {
                filePath = image.FileName;
                imtextbox.Text = filePath;
            }
        }




            public BitmapImage GenerateBitMapImage(string filePath)
            {

                return new BitmapImage(new Uri(filePath));
            
            }

        private void submitbt_Click(object sender, RoutedEventArgs e)
        {
            bool sytle1 = radio1.IsChecked.Value;//string for radiobotton
            bool sytle2 = radio2.IsChecked.Value;
            bool style3 = radio3.IsChecked.Value;
            bool style4 = radio4.IsChecked.Value;

            ArtStyle style;


            if (sytle1)
            {
                style = ArtStyle.Epressionism;//this is enum show 
            }
            else if (sytle2)
            {
                style = ArtStyle.Impressionism;
            }
            else if (style3)
            {
                style = ArtStyle.Surrealism;
            }
            else
            {
                style = ArtStyle.Neoclassicism;
            }

            string artName = textboxartname.Text;//this is main botton run each text botton and datepicker first make string then runin class
            string artistName = artistnametextbox.Text;
            DateTime dateTime = timepicker.SelectedDate.Value;
            string notes = advincerichtext.Text;
            string filepath = imtextbox.Text;

            ArtPiece art = new ArtPiece(dateTime, artName, artistName, notes, filepath, style);// run on my class structure here class is alike bone
            //of bodyand this code is alike muscle
            artList.Add(art);
            listview.Items.Add(art);
        }

        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArtPiece selected = (ArtPiece)listview.SelectedItem;

            imageshow.Source = GenerateBitMapImage(selected.FilePath);
            // advincerichtextbox. = selected.Body;

            FlowDocument flowDocument = new FlowDocument();// here is build advince richtext 
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(runmethod(selected.Name));//what we want to run in ad rich text
            paragraph.Inlines.Add("\n");
            paragraph.Inlines.Add("\n");
            paragraph.Inlines.Add(bodymethod(selected.Body));
            
            flowDocument.Blocks.Add(paragraph);
            advincerichtextbox.Document = flowDocument;
        }

        public Run runmethod(string headerline)
        {
            Run newrun = new Run(headerline);
            newrun.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            newrun.FontStyle = FontStyles.Italic;
            Run runnynew = new Run(headerline);
            runnynew.FontSize = 40;

            return newrun;
        }
        public Run bodymethod(string body)
        {
            Run runnynew = new Run(body);
            runnynew.FontSize = 21;
            runnynew.Foreground = new SolidColorBrush(Colors.DeepPink);
            Run runnewbody = new Run(body);
            runnewbody.FontSize = 26;
            return runnynew;
        }
        public Paragraph mothedparagraph(string hl)
        {

            string headerline = textboxartname.Text;
            string artistname=artistnametextbox.Text;
            string body = advincerichtext.Text;
            Run newrun = runmethod(headerline);
            Run runnewbody = bodymethod(body);


            //paragraph newparagrap = new paragraph();
            Paragraph newparagrap = new Paragraph();
            newparagrap.Inlines.Add(newrun);
            newparagrap.Inlines.Add("\n");
            newparagrap.Inlines.Add(runnewbody);
            fddisplay.Blocks.Add(newparagrap);



            return newparagrap;
        }

    }
}

