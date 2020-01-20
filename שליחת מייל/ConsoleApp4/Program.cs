using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace mysendemail
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread thr = new Thread(sendAnEamil);
            thr.Start();
           
            Console.WriteLine("Main Thread Ends!!");
            


        }
        public static void sendAnEamil()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("zimmerisrael123@gmail.com", "Aa12345678910"),
                EnableSsl = true
            };
           
                client.Send("srayapash@gmail.com", "srayapash@gmail.com", "hi behrooz, how was your nohrooz?", "this is a messege from your iranian friend. \n messege number: ");
                Console.WriteLine("Sent");
        

            Console.ReadLine();
        }
    }

   
    }

