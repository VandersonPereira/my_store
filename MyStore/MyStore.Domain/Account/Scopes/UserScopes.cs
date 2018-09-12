using DomainNotificationHelper.Validation;
using MyStore.Domain.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertLength(user.UserName, 6, 20, "O usuário tem que ter entre 6 e 20 caracteres."),
                    AssertionConcern.AssertLength(user.Password, 6, 20, "A senha deve conter entre 6 e 20 caracteres.")
                );
        }

        public static bool VerificationScopeIsValid(this User user, string verificationCode)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado."),
                    AssertionConcern.AssertTrue(user.Verified == false, "Aluno já verificado."),
                    AssertionConcern.AssertAreEquals(user.VerificationCode, verificationCode, "O código de verificação não confere.")
                );
        }

        public static bool ActivationScopeIsValid(this User user, string activationCode)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado."),
                    AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado."),
                    AssertionConcern.AssertTrue(user.Active == false, "Cadastro já verificado."),
                    AssertionConcern.AssertAreEquals(user.ActivationCode, activationCode, "O código de ativação não confere.")
                );
        }

        public static bool RequestLoginScopeIsValid(this User user, string userName)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado."),
                    AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado."),
                    AssertionConcern.AssertTrue(user.Active == true, "Cadastro já verificado."),
                    AssertionConcern.AssertAreEquals(user.UserName.ToLower(), userName.ToLower(), "Nome não confere."),
                    AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAuthorizationCodeRequest.AddMinutes(-5), DateTime.Now).ToString(), (-1).ToString(), "Um SMS já foi enviado. Aguarde 5 minutos para requisitar um novo login.")
                );
        }

        public static bool LoginScopeIsValid(this User user, string authorizationCode, string password)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user, "Nenhum usuário encontrado."),
                    AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado."),
                    AssertionConcern.AssertTrue(user.Active == true, "Cadastro já verificado."),
                    AssertionConcern.AssertAreEquals(user.AuthorizationCode.ToLower(), authorizationCode.ToLower(), "Código de autorização invalido."),
                    AssertionConcern.AssertAreEquals(user.Password, password, "Usuário ou senha invalidos."),
                    AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAuthorizationCodeRequest.AddMinutes(5), DateTime.Now).ToString(), (-1).ToString(), "Código de autenticação expirado.")
                );
        }

    }
}
