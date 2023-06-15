using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Jackie_Stewart
{
    internal class Jackie
    {
        int year;
        int races;
        int wins;
        int podiums;
        int poles;
        int fastests;

        public Jackie(int year, int races, int wins, int podiums, int poles, int fastests)
        {
            this.year = year;
            this.races = races;
            this.wins = wins;
            this.podiums = podiums;
            this.poles = poles;
            this.fastests = fastests;
        }

        public int Year { get => year;  }
        public int Races { get => races;  }
        public int Wins { get => wins; }
        public int Podiums { get => podiums;  }
        public int Poles { get => poles;  }
        public int Fastests { get => fastests;  }
    }
}
