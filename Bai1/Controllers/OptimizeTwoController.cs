using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace Bai1.Controllers
{
    public class OptimizeTwoController : ApiController
    {
        [Route ("api/list")]

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "Chúc", "Du", "Dỳ" };
        }

        // GET api/values/5
        [Route ("api/custom/{id}")]
        public string[] Get(string id)
        {
            string[] words = id.Split(',');
            Array.Sort(words, new CardComparer());
            string[] myarr = words;
            //return myarr;
            List<string> paired = new List<string>(); //cho nhung phan tu bang nhau vao day
            string previousCard = null; //chuoi phia truoc
            List<string> tempPair = new List<string>();//cho nhung phan tu khong thoa man vao day va xet tiep


            foreach (string card in myarr)
            {
                if (previousCard != null)
                {

                    //if (GetValue(card) == GetValue(previousCard))
                    //{
                    //    paired.Add(card);
                        
                    //    //paired.Add(previousCard);
                    //}
                    //else
                    //{
                    //    tempPair.Add(card);
                    //}
                    if (GetSuit(card) == GetSuit(previousCard))
                    {
                        int space = GetValue(card) - GetValue(previousCard);
                        if (space == 1)
                        {
                            paired.Add(previousCard);
                            
                        }
                        else
                        {
                            tempPair.Add(card);
                        }
                    }
                }
                
                previousCard = card;
            }
            
            return paired.ToArray();
        }
        public class CardComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                int valueX = GetValue(x);
                int valueY = GetValue(y);
                
                int compareValueResult = valueX.CompareTo(valueY);
               
                return compareValueResult;

            }
            private int GetValue(string card)
            {
                switch (card[0])
                {
                    case 'A':
                        return 1;
                    case '2':
                        return 2;
                    case '3':
                        return 3;
                    case '4':
                        return 4;
                    case '5':
                        return 5;
                    case '6':
                        return 6;
                    case '7':
                        return 7;
                    case '8':
                        return 8;
                    case '9':
                        return 9;
                    case '1':
                        return 10; 
                    case 'J':
                        return 11;
                    case 'Q':
                        return 12;
                    case 'K':
                        return 13;
                    default:
                        return -1;
                }
            }
            
        }
        private int GetSuit(string card)
        {
            switch (card[card.Length - 1])
            {
                case '♥':
                    return 1;
                case '♦':
                    return 2;
                case '♣':
                    return 3;
                case '♠':
                    return 4;
                default:
                    return -1;

            }
        }
        private int GetValue(string card)
        {
            switch (card[0])
            {
                case 'A':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case '1':
                    return 10;
                case 'J':
                    return 11;
                case 'Q':
                    return 12;
                case 'K':
                    return 13;
                default:
                    return -1;
            }
        }


        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
