using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users_and_awards.Entities
{
    public interface IAwardsStorable
    {
        bool AddAward(Award award);
        Award GetAward(Guid id);
        void EditAward(Guid id, string Title, byte [] Image, bool flag_image);
        bool RemoveAward(Guid id);
        ICollection<Award> SelectAllAwards();
    }
}
