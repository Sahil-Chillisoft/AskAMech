using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.UseCases.Requests
{
    public class EditUserProfileRequest
    {
        public UserProfile userProfile { get; set; }
    }
}
