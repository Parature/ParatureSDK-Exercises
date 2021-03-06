﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParatureSDK;
using ParatureSDK.ParaObjects;

namespace Exercises
{
    class Exercise03ListCustomers
    {
        //Customers by account and date
        public static ParaEntityList<Customer> getCustomersByAccountAndDate(long acccountID, DateTime date)
        {
            var customerQuery = new ParatureSDK.ModuleQuery.CustomerQuery();
            customerQuery.RetrieveAllRecords = true;
            customerQuery.AddStaticFieldFilter(ParatureSDK.ModuleQuery.CustomerQuery.CustomerStaticFields.AccountID, ParaEnums.QueryCriteria.Equal, acccountID.ToString());
            //Use a custom filter if correct enums aren't available
            customerQuery.AddCustomFilter(String.Format("Date_Created_max_={0}/{1}/{2}", date.Month, date.Day, date.Year));

            var customers = ParatureSDK.ApiHandler.Customer.GetList(CredentialProvider.Creds, customerQuery);

            return customers;
        }

        public static ParaEntityList<Customer> getCustomersByEmail(string email)
        {
            var customerQuery = new ParatureSDK.ModuleQuery.CustomerQuery();
            customerQuery.RetrieveAllRecords = true;
            customerQuery.AddStaticFieldFilter(ParatureSDK.ModuleQuery.CustomerQuery.CustomerStaticFields.CustomerEmail, ParaEnums.QueryCriteria.Equal, email);

            var customers = ParatureSDK.ApiHandler.Customer.GetList(CredentialProvider.Creds, customerQuery);

            return customers;
        }

        public static ParaEntityList<Customer> getCustomersByStatus(long statusID)
        {
            var customerQuery = new ParatureSDK.ModuleQuery.CustomerQuery();
            customerQuery.RetrieveAllRecords = true;
            customerQuery.AddStaticFieldFilter(ParatureSDK.ModuleQuery.CustomerQuery.CustomerStaticFields.Status, ParaEnums.QueryCriteria.Equal, statusID.ToString());

            var customers = ParatureSDK.ApiHandler.Customer.GetList(CredentialProvider.Creds, customerQuery);

            return customers;
        }

        public static ParaEntityList<Customer> getCustomersAndOrderByLastName()
        {
            var customerQuery = new ParatureSDK.ModuleQuery.CustomerQuery();
            customerQuery.RetrieveAllRecords = true;
            customerQuery.AddSortOrder(ParatureSDK.ModuleQuery.CustomerQuery.CustomerStaticFields.LastName, ParaEnums.QuerySortBy.Asc);

            var customers = ParatureSDK.ApiHandler.Customer.GetList(CredentialProvider.Creds, customerQuery);

            return customers;
        }
    }
}
