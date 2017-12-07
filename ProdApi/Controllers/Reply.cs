using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace ProdApi.Controllers
{
    public class Reply
    {
        public ErrorCode ErrorCode;
        public string ErrorMessage;
        public List<ReplyDetail> Errors = new List<ReplyDetail>();

        public Reply(ErrorCode errorcode, string errormessage, List<ErrorDetails> errors)
        {
            ErrorCode = errorcode;
            ErrorMessage = errormessage;

            foreach (var value in errors)
            {
                if (value.Field.ToLower().Contains("confirm"))
                {
                    ReplyDetail temp = new ReplyDetail(ErrorCode.PasswordDoesNotMatch, value.Message);
                    Errors.Add(temp);
                }
                else if (value.Field.ToLower().Contains("username"))
                {
                    ReplyDetail temp = new ReplyDetail(ErrorCode.UserNameError, value.Message);
                    Errors.Add(temp);
                }
                else if (value.Field.ToLower().Contains("password"))
                {
                    ReplyDetail temp = new ReplyDetail(ErrorCode.PasswordShort, value.Message);
                    Errors.Add(temp);
                }
                
            }
            
        }
    }

    public class ReplyDetail
    {
        public ErrorCode ErrorCode;
        public string ErrorMessage;

        public ReplyDetail(ErrorCode errorcode, string errormessage)
        {
            ErrorCode = errorcode;
            ErrorMessage = errormessage;
        }
    }

    public class ErrorDetails
    {
        public string Field;
        public string Message;

        public ErrorDetails()
        { }

        public ErrorDetails(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
    public enum ErrorCode { OK = 0, FieldValidationError = 1, PasswordDoesNotMatch = 101, UserNameError = 102, PasswordShort = 103, UspecifyedError = 5 }

}