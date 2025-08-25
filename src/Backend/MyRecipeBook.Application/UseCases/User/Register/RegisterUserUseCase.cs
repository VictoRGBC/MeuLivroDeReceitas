using FluentValidation.Results;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Exceptions.ExceptionsBase
using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {
            //Validar a request

            Validate(request);

            //Mapear a request para uma entidade

            //Criptografar a senha

            //Salvar a entidade no banco de dados

            return new ResponseRegisteredUserJson
            {
                Name = request.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();


                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
