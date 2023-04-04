using System;
using System.Linq;
using System.Collections.Generic;
using mtg_lib.Library.Models;

namespace mtg_lib.Library.Services
{
    public class CollectionService
    {
        private Dictionary<String,List<Card>> savedCollections = new Dictionary<String,List<Card>>();

        private void checkNew(String userId){
            if(!this.savedCollections.ContainsKey(userId)){
                List<Card> userCollection = new List<Card>();
                this.savedCollections.Add(userId, userCollection);
            }
        }

        public List<Card> getCollectionFromId(String userId){
            this.checkNew(userId);

            return this.savedCollections[userId];

        }

        public void setCollection(String userId, List<Card> collection){
            this.checkNew(userId);

            this.savedCollections[userId] = collection;
        }

        public void addToCollection(String userId, Card card){
            this.checkNew(userId);

            List<Card> userCollection = this.savedCollections[userId];
            if(!userCollection.Contains(card)){
                userCollection.Add(card);
            }

            setCollection(userId, userCollection);
        }

        public void removeFromCollection(String userId, Card card){
            this.checkNew(userId);

            List<Card> userCollection = this.savedCollections[userId];
            if(userCollection.Contains(card)){
                userCollection.Remove(card);
            }

            setCollection(userId, userCollection);
        }

        public bool collectionContains(String userId, Card card){
            this.checkNew(userId);
            List<Card> userCollection = this.savedCollections[userId];
            return userCollection.Contains(card);
        }


    }

   

}