using ShowRank.Domain.EF.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Services.Interfaces
{
    public interface IAdminServices : IBaseServices
    {
        IAdminRepository AdminRepository { get; }
    }
}
