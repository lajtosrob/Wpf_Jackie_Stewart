using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Jackie_Stewart
{
    internal class JackieStewartStat
    {
        int year;
        int races;
        int wins;

        public JackieStewartStat(int year, int races, int wins)
        {
            this.year = year;
            this.races = races;
            this.wins = wins;
        }

        public int Year { get => year; set => year = value; }
        public int Races { get => races; set => races = value; }
        public int Wins { get => wins; set => wins = value; }
    }
}
