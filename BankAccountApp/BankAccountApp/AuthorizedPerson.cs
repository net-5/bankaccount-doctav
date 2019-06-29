using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountApp
{
    class AuthorizedPerson : GeneralPerson
    {
        public enum ROLE { TUTOR, LEGAL_AUTHORIZED_PERSON}

        private ROLE role;

        public ROLE Role
        {
            get { return role; }
            set { role = value; }
        }

        public AuthorizedPerson(string pName,ROLE role):base(pName)
        {
            this.Role = role;
        }
    }
}
