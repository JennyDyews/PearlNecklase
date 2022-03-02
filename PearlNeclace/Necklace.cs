﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace
{
    public class Necklace : INecklace
    {
        List<IPearl> _stringOfPearls = new List<IPearl>();  
        public IPearl this[int idx] => _stringOfPearls[idx];
        public decimal Price
        {
            get
            {
                var price = 0M;
                foreach (var p in _stringOfPearls)
                {
                    price += p.Price;
                }
                return price;   
            }
        }

        public int Count() => _stringOfPearls.Count;    

        public int Count(PearlType type)
        {
            int c = 0;
            foreach (var item in _stringOfPearls)
            {
                if (type == item.Type)  
                    c++;    
            }
           return c;
        }

        public override string ToString()
        {
            string sRet = $"Necklace has the following pearls:\n";
            foreach (var item in _stringOfPearls)
            {
                sRet += $"{item}\n";
            }
            return sRet;
        }


        public void Sort() => _stringOfPearls.Sort();
        public int IndexOf(IPearl pearl) => _stringOfPearls.IndexOf(pearl); 


        #region Class Factory for creating an instance filled with Random data
        internal static class Factory
        {
            internal static INecklace CreateRandomNecklace(int NrOfItems)
            {
                var necklace = new Necklace();
                for (int i = 0; i < NrOfItems; i++)
                {
                    necklace._stringOfPearls.Add(Pearl.Factory.CreateRandomPearl());
                }
                return necklace;    
            }
         }
        #endregion
    }
}
