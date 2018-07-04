using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class ChatService : IChatService
    {
        private readonly ISellbookDbContext context;

        public ChatService(ISellbookDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public int GetChatCountForPublication(Guid PublicationId)
        {
            return this.context.Chat.Where(x => x.PublicationId == PublicationId && x.IsDelеted != true).Count();
        }
    }
}
