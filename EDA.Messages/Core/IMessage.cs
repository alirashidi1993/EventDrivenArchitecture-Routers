using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDA.Messages.Core
{
    public interface IMessage
    {
        public Guid MessageId { get; }
    }
}
