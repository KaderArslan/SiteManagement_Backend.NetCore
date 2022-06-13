using Microsoft.EntityFrameworkCore;
using SiteManagement.Dal.Abstract;
using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Dal.Concrete.Entityframework.Repository
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {
        }

        public Message Add(Message item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);

            return item;
        }

        public List<Message> MessageSender(int Admin, int User)
        {
            return dbset.Where(x => x.MessageSender == User && x.MessageReceiver == Admin).ToList();
        }


    }
}
