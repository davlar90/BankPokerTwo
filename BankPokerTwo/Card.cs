using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPokerTwo
{
    class Card
    {
        static string[] deck = {"ca","c2","c3","c4","c5","c6","c7","c8","c9","ct","cj","cq","ck",
                            "da","d2","d3","d4","d5","d6","d7","d8","d9","dt","dj","dq","dk",
                            "ha","h2","h3","h4","h5","h6","h7","h8","h9","ht","hj","hq","hk",
                            "sa","s2","s3","s4","s5","s6","s7","s8","s9","st","sj","sq","sk"};

        public static string[] getDeck()
        {
            return deck;
        }



    }
}
