using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Infrastructure.Data.Entities;

namespace AskAMech.Infrastructure.Data.Entities
{
    public class ViewUserInfoEntity
    {
        public UserEntity userEntity { get; set; }
        public UserProfileEntity userProfile { get; set; }
    }
}
