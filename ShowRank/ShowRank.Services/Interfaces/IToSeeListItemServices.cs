using ShowRank.Domain.EF.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Services.Interfaces
{
    public interface IToSeeListItemServices : IBaseServices
    {
        IToSeeListItemRepository ToSeeListItemRepository { get; }
    }
}
