using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class Chat
    {
        private ICollection<Message> messages;

        public Chat()
        {
            this.messages = new HashSet<Message>();
        }

        public Guid Id { get; set; }

        public Guid PublicationId { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        [Required]
        public bool IsFavourite { get; set; }

        [Required]
        public bool IsDelеted { get; set; }

        public ICollection<Message> Messages
        {
            get
            {
                return this.Messages;
            }
            set
            {
                this.messages = value;
            }
        }
    }
}
