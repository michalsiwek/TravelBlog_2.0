using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class Contact
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        private void NormalizeMessage()
        {
            var output = Message.Trim();
            while (output.Contains("\r\n\r\n\r\n"))
                output = output.Replace("\r\n\r\n\r\n", "\r\n\r\n");
            Message = output;
        }

        public string GetMessage()
        {
            NormalizeMessage();
            var paragraphTemplate = "<p>{0}</p>";

            var message = Message.Replace("\r\n\r\n", "|").Trim();
            string[] paragraphs = message.Split('|');
            message = "";

            foreach (var p in paragraphs)
                message = message + string.Format(paragraphTemplate, p);

            return message;
        }
    }
}