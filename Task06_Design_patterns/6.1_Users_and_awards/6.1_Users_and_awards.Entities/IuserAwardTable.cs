using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users_and_awards.Entities
{
    public  interface IUserAwardTable
    {
        bool AddAwardUser(Guid UserId, Guid AwardId);
        List<Award> GetUserAward(Guid UserId);
    }
}
