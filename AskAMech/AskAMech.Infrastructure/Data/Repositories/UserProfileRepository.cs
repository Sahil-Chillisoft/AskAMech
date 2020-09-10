using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Infrastructure.Data.Helpers;
using AutoMapper;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class UserProfileRepository: IUserProfileRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public UserProfileRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public UserProfile GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public void Create(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }
    }
}
