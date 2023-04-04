using System;
using System.Linq;
using System.Collections.Generic;
using mtg_lib.Library.Models;

namespace mtg_lib.Library.Services
{
    public class ShoppingCartService
    {

        private Dictionary<String,List<Card>> shoppingCarts = new Dictionary<String,List<Card>>();

        private void checkNew(String userId){
            if(!this.shoppingCarts.ContainsKey(userId)){
                List<Card> userCollection = new List<Card>();
                this.shoppingCarts.Add(userId, userCollection);
            }
        }

        public List<Card> getShoppingCartFromId(String userId){
            this.checkNew(userId);

            return shoppingCarts[userId];
        }

        public void addToCart(String userId, Card card){
            this.checkNew(userId);

            List<Card> userShoppingCart = this.shoppingCarts[userId];
            userShoppingCart.Add(card);

            this.setShoppingCart(userId, userShoppingCart);
        }

        public void setShoppingCart(String userId, List<Card> shoppingCart){
            this.checkNew(userId);
            this.shoppingCarts[userId] = shoppingCart;
        }

        public void removeFromCart(String userId, Card card){
            if(!shoppingCarts.ContainsKey(userId)){
                return;
            }

            List<Card> userShoppingCart = this.shoppingCarts[userId];
            userShoppingCart.Remove(card);

            this.setShoppingCart(userId, userShoppingCart);

        }

        public void resetShoppingCart(String userId){
            this.setShoppingCart(userId, new List<Card>());
        }
    }
}
