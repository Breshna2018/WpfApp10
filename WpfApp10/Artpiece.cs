using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace WpfApp10
{
    public enum ArtStyle
    {
        Epressionism,
        Surrealism,
        Impressionism,
        Neoclassicism
    }
    internal class ArtPiece
    {
        DateTime _date;
        string _name;
        string _artist;
        string _body;
        string _filePath;
        BitmapImage _art;
        ArtStyle _artStyle;

        public ArtPiece(DateTime date, string name, string artist, string body, string filePath, ArtStyle style)
        {
            Date = date;
            Name = name;
            Artist = artist;
            Body = body;
            FilePath = filePath;
            ArtStyle = style;
        }

        public DateTime Date { get => _date; set => _date = value; }
        public string Name { get => _name; set => _name = value; }
        public string Artist { get => _artist; set => _artist = value; }
        public string Body { get => _body; set => _body = value; }
        public string FilePath { get => _filePath; set => _filePath = value; }
        public BitmapImage Art { get => _art; set => _art = value; }
        public ArtStyle ArtStyle { get => _artStyle; set => _artStyle = value; }
    }
}
