using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users_and_awards.Entities
{
    public interface IAwardsStorable
    {
        bool AddAward(Award award);
        Award GetAward(Guid id);
        ICollection<Award> SelectAllAwards();
    }
}
