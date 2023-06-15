using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.NetworkInformation;

namespace Wpf_Jackie_Stewart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Jackie> jackies = new List<Jackie>();
        string[] lines;

        public MainWindow()
        {
            InitializeComponent();

            //2. Adatbeolvasás

            ReadData("DataSource\\jackie.txt");

            //3. 

            lblFeladat3.Content = $"3. feladat: {jackies.Count}";

            //4. 

            int legtobbNyerVerseny = jackies.OrderByDescending(x => x.Races).First().Year;

            lblFeladat4.Content = $"4. feladat: {legtobbNyerVerseny}";

            //5.

            Statistics();

            //.6

            // Adatok
            string name = "Jackie Stewart";
            string htmlFileName = "jackie.html";

            // HTML generálása
            string htmlContent = GenerateHtmlContent(name);

            // HTML mentése a fájlba
            SaveHtmlFile(htmlFileName, htmlContent);

            lblFeladat6.Content = $"6. feladat: {htmlFileName}";
        }

        public void ReadData(string filename)
        {
            string[] parts;
            lines = File.ReadAllLines(filename);

            for (var line = 1; line < lines.Length; line++)
            {
                parts = lines[line].Split('\t');

                int year = int.Parse(parts[0]);
                int races = int.Parse(parts[1]);
                int wins = int.Parse(parts[2]);
                int podiums = int.Parse(parts[3]);
                int poles = int.Parse(parts[4]);
                int fastests = int.Parse(parts[5]);

                Jackie jackiesLine = new(year, races, wins, podiums, poles, fastests);

                jackies.Add(jackiesLine);
            }
        }

        public void Statistics()
        {
            int hatvanas = 0;
            int hetvenes = 0;

            for (int index = 0; index < jackies.Count; index++)
            {
                if (jackies[index].Year >= 1960 && jackies[index].Year <= 1969)
                {
                    hatvanas += jackies[index].Wins;
                }
                else
                {
                    hetvenes += jackies[index].Wins;
                }
            }

            lblHatvanas.Content = $"\t60-as évek: {hatvanas} megnyert verseny";
            lblHetvenes.Content = $"\t70-as évek: {hetvenes} megnyert verseny";
        }

        public string GenerateHtmlContent(string name)
        {
            // HTML generálás
            string html = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Jackie Stewart statisztika</title>
                    <style>
                        table {{
                            border-collapse: collapse;
                        }}

                        table, th, td {{
                            border: 1px solid black;
                        }}

                        th, td {{
                            padding: 5px;
                        }}
                    </style>
                </head>
                <body>
                    <h1>{name}</h1>
                    <table>
                        <tr>
                            <th>Versenyzés éve</th>
                            <th>Versenyszám</th>
                            <th>Győzelmek száma</th>
                        </tr>";

                            // Adatok beillesztése a táblázatba
                            foreach (var stat in jackies)
                            {
                                html += $@"
                        <tr>
                            <td>{stat.Year}</td>
                            <td>{stat.Races}</td>
                            <td>{stat.Wins}</td>
                        </tr>";
                            }

                            // HTML zárása
                            html += @"
                    </table>
                </body>
                </html>";
            return html;
        }

        static void SaveHtmlFile(string fileName, string content)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(content);
            }
        }
    }
}