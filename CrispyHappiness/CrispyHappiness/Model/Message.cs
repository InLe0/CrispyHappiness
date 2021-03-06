﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CrispyHappiness.Model
{
    public class Message : BindableObject
    {
        private int id;
        public int Id {
            get { return id; }
            set { id = value; base.OnPropertyChanged(); }
        }
        public int ConversationId { get; set; }
        public int UserId { get; set; }

        private string username;
        public string Username { get { return username; } set { username = value; base.OnPropertyChanged(); } }

        private string text;
        public string Text { get { return text; } set { text = value; base.OnPropertyChanged(); } }

        public DateTime Date { get; set; }

        private bool incoming;

        public bool Incoming
        {
            get { return incoming; }
            set { incoming = value; }
        }

    }
}
