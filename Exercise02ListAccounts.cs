﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParatureSDK;
using ParatureSDK.ParaObjects;

namespace Exercises
{
    class Exercise02ListAccounts
    {
        //List all of the accounts
        public static ParaEntityList<ParatureSDK.ParaObjects.Account> getAllAccounts()
        {
            //Query object is a query string builder
            var accountQuery = new ParatureSDK.ModuleQuery.AccountQuery();
            accountQuery.RetrieveAllRecords = true; //Retrieve all records will maximize page size and make necessary additional calls to retrieve all pages

            var accounts = ParatureSDK.ApiHandler.Account.GetList(CredentialProvider.Creds, accountQuery);

            var apiResponse = accounts.ApiCallResponse; //API response is provided with object

            if (apiResponse.HasException)
            {  
                //Exception handling is a best practice
                Console.Write(apiResponse.ExceptionDetails);
                return null;
            }

            return accounts;
        }

        public static ParaEntityList<ParatureSDK.ParaObjects.Account> searchAccountsByName(string accountName)
        {
            var accountQuery = new ParatureSDK.ModuleQuery.AccountQuery();
            accountQuery.RetrieveAllRecords = true;
            
            //There is a difference between static fields and custom fields
            accountQuery.AddStaticFieldFilter(ParatureSDK.ModuleQuery.AccountQuery.AccountStaticFields.Accountname, ParatureSDK.ParaEnums.QueryCriteria.Equal, accountName);

            var accounts = ParatureSDK.ApiHandler.Account.GetList(CredentialProvider.Creds, accountQuery);

            return accounts;
        }

        public static ParaEntityList<ParatureSDK.ParaObjects.Account> searchAccountsByField(long fieldID, string fieldValue)
        {
            var accountQuery = new ParatureSDK.ModuleQuery.AccountQuery();
            accountQuery.RetrieveAllRecords = true;
            accountQuery.AddCustomFieldFilter(fieldID, ParatureSDK.ParaEnums.QueryCriteria.Equal, fieldValue);
            
            var accounts = ParatureSDK.ApiHandler.Account.GetList(CredentialProvider.Creds, accountQuery);

            return accounts;
        }

        //Overload for an option field
        public static ParaEntityList<ParatureSDK.ParaObjects.Account> searchAccountsByField(long fieldID, long fieldValue)
        {
            //field value would be option ID
            var accountQuery = new ParatureSDK.ModuleQuery.AccountQuery();
            accountQuery.RetrieveAllRecords = true;
            accountQuery.AddCustomFieldFilter(fieldID, ParaEnums.QueryCriteria.Equal, fieldValue);

            var accounts = ParatureSDK.ApiHandler.Account.GetList(CredentialProvider.Creds, accountQuery);

            return accounts;
        }

        public static ParaEntityList<ParatureSDK.ParaObjects.Account> getAccountsByView(long viewID)
        {
            //field value would be option ID
            var accountQuery = new ParatureSDK.ModuleQuery.AccountQuery();
            accountQuery.RetrieveAllRecords = true;
            accountQuery.View = viewID;

            var accounts = ParatureSDK.ApiHandler.Account.GetList(CredentialProvider.Creds, accountQuery);

            return accounts;
        }
    }

    
}
