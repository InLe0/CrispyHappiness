using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CrispyHappiness.Model
{
    public class Conversation : BindableObject
    {
        private int id;
        public int Id {
            get {
                return id;
            }
            set {
                id = value;
                OnPropertyChanged();
            }
        }
        public int UserId { get; set; }


        private String username;
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string LastMessage { get; set; }

        public string MyId { get; set; }
    }
}
