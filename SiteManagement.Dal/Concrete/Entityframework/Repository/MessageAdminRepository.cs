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
    public class MessageAdminRepository : GenericRepository<Message>, IMessageAdminRepository
    {
        public MessageAdminRepository(DbContext context) : base(context)
        {
        }

        public Message Add(Message item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);

            return item;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));//asagidaki delete
        }

        public bool Delete(Message item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
        }

        public List<Message> MessageSender(int Admin, int User)
        {
            return dbset.Where(x => x.MessageSender == Admin && x.MessageReceiver == User).ToList();
        }

        public Message Update(Message item)
        {
            dbset.Update(item);
            return item;
        }


    }
}
