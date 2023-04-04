using System;
using System.Linq;
using System.Collections.Generic;
using mtg_lib.Library.Models;

namespace mtg_lib.Library.Services
{
    public class CardService
    {
        mtgContext context = new mtgContext();
        
        public IEnumerable<Card> GetCardsFromIndex(int index)
        {
            return context.Cards
                .OrderBy(c => c.Id)
                .Where(c => c.Id > index * 100)
                .Take(100);
        }

        public IEnumerable<Card> GetCardsFromManaCostDirection(String direction)
        {   
            if (direction == "Ascending")
            {
                return context.Cards
                    .OrderBy(c => c.ManaCost)
                    .Take(100);
            }
            else
            {
                return context.Cards
                    .OrderByDescending(c => c.ManaCost) 
                    .Take(100);
            }
        }
        
        public IEnumerable<Card> GetCardsFromManaCost(String manacost)
        {   
                Console.Out.WriteLine(context.Cards);
                return context.Cards
                    .OrderBy(c => c.Id)
                    .Where(c => c.ConvertedManaCost == manacost)
                    .Take(100);
        }
        
        public IEnumerable<Card> GetCardsFromName(String name)
        {   
            if(name is null){
                return this.GetCardsFromIndex(0);
            }
            

            return context.Cards
                .Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }

        public long GetPagesAmount()
        {
            return AllCard().TakeLast(1).First().Id / 100;
        }
        
        public IEnumerable<Card> AllCard(){
            return context.Cards.OrderBy(c => c.Id);
        }
        
        public Card GetCardById(int id){
            return context.Cards.Where(c => c.Id == id).First();
        }
        
    }
}
