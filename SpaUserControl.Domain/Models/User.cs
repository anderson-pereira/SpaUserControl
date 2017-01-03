﻿using SpaUserControl.Common.Validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.Domain.Models
{
    public class User
    {
        public User(string name, string email)
        {
            this.Name = name;

            this.Email = email;
                
        }
        //Private set para que somente a classe user possa modificar seus atributos.
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public void  SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, "Senha inválida!");
            AssertionConcern.AssertArgumentNotNull(confirmPassword, "Confirmação de Senha inválida!");

            AssertionConcern.AssertArgumentNotEquals(password, confirmPassword, "As senhas digitadas não coincidem!");

            AssertionConcern.AssertArgumentLength(password, 6, 20, "Senha Inválida!");

            this.Password = PasswordAssertionConcern.Encrypt(password);
        }
    }
}
